using ExportReaperMarkersToGrandMA2;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Telnet
{

    private enum Verbs
    {
        WILL = 251,
        WONT = 252,
        DO = 253,
        DONT = 254,
        IAC = 255
    }

    private enum Options
    {
        SGA = 3
    }

    private enum NewLineChars
    {
        CR = 13,
        LF = 10
    }

    public event EventHandler<TelnetProgressEventArgs> OnCommandSend;
    public event EventHandler<TelnetProgressEventArgs> OnFeedbackRecieved;
    public event EventHandler<TelnetProgressEventArgs> OnProgressFinished;
    public event EventHandler<TelnetConnectEventArgs> OnConnectionChange;

    private MA2CommandNotExecutedException ex;

    private int Port;
    private TcpClient Socket;

    private NetworkStream NetworkStream;
    private StreamReader InputStream;
    private StreamWriter OutputStream;

    private string Host;
    private string[] Commands;
    private string User;
    private string Password;

    public bool Connected { get; set; }

    public Telnet(string host, string[] commands, string user, string password)
    {

        this.Host = host;
        this.Commands = commands;
        this.User = user;
        this.Password = password;

        OnCommandSend = null;
        ex = null;

        Port = 30000;

    }

    public async void Connect()
    {
        try
        {
            Connected = false;
            OnConnectionChange(this, new TelnetConnectEventArgs("", TelnetConnectEventArgs.Connecting));
            Socket = new TcpClient();
            await Socket.ConnectAsync(Host, Port);
            Connected = true;
            NetworkStream = Socket.GetStream();
            InputStream = new StreamReader(NetworkStream);
            OutputStream = new StreamWriter(NetworkStream);


            this.OnFeedbackRecieved += new EventHandler<TelnetProgressEventArgs>(onFeedbackRecieved);

            OnConnectionChange(this, new TelnetConnectEventArgs("", TelnetConnectEventArgs.Connected));
        }
        catch (SocketException)
        {
            OnConnectionChange(this, new TelnetConnectEventArgs("", TelnetConnectEventArgs.Timeout));
            throw new TelnetConnectionException(TelnetConnectionException.Refused);
        }
    }

    public void Run()
    {

        while (!Socket.Connected) { }
        Thread.Sleep(200);
        while (Socket.Available > 0) NetworkStream.ReadByte();


        SendCommand(string.Format("login {0} {1}", User, Password));

        RecieveFeedback();


        foreach (string s in Commands)
        {
            SendCommand(s);

            RecieveFeedback();

            if (ex != null)
            {
                ex.command = s;
                break;
            }
        }
        
        InputStream.Close();
        OutputStream.Close();

        if (ex != null)
        {
            throw ex;
        }

        OnProgressFinished(this, new TelnetProgressEventArgs("", TelnetProgressEventArgs.Finished));
    }

    private void SendCommand(string cmd)
    {
        OutputStream.WriteLine(cmd);
        OutputStream.Flush();

        OnCommandSend(this, new TelnetProgressEventArgs(cmd, TelnetProgressEventArgs.Send));

        Thread.Sleep(100);
    }

    private string RecieveFeedback()
    {
        StringBuilder sb = new StringBuilder();

        do
        {
            ParseTelnet(sb);
            System.Threading.Thread.Sleep(100);
        } while (Socket.Available > 0);

        string line = Regex.Replace(sb.ToString(), @"\e\[(\d+;)*(\d+)?[ABCDHJKfmsu]","");
        line = line.Replace("\n [Fixture]>", "");

        OnFeedbackRecieved(this, new TelnetProgressEventArgs(line, TelnetProgressEventArgs.Recieve));

        return line;
    }

    private void ParseTelnet(StringBuilder sb)
    {
        while (Socket.Available > 0)
        {
            int input = NetworkStream.ReadByte();
            switch (input)
            {
                case -1:
                    break;
                case (int)Verbs.IAC:
                    // interpret as command
                    int inputverb = NetworkStream.ReadByte();
                    if (inputverb == -1) break;
                    switch (inputverb)
                    {
                        case (int)Verbs.IAC:
                            //literal IAC = 255 escaped, so append char 255 to string
                            sb.Append(inputverb);
                            break;
                        case (int)Verbs.DO:
                        case (int)Verbs.DONT:
                        case (int)Verbs.WILL:
                        case (int)Verbs.WONT:
                            // reply to all commands with "WONT", unless it is SGA (suppres go ahead)
                            int inputoption = NetworkStream.ReadByte();
                            if (inputoption == -1) break;
                            NetworkStream.WriteByte((byte)Verbs.IAC);
                            if (inputoption == (int)Options.SGA)
                                NetworkStream.WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL : (byte)Verbs.DO);
                            else
                                NetworkStream.WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT);
                            NetworkStream.WriteByte((byte)inputoption);
                            break;
                        default:
                            break;
                    }
                    break;
                case (int)NewLineChars.CR:
                    break;
                case (int)NewLineChars.LF:
                    sb.Append("\n");
                    break;
                default:
                    sb.Append((char)input);
                    break;
            }
        }
    }
           

    private void onFeedbackRecieved(object sender, TelnetProgressEventArgs e)
    {
        if (e.command.Contains("LOGIN NEEDED") || e.command.Contains("Login incorrect"))
        {
            throw new TelnetConnectionException(TelnetConnectionException.LOGIN_INCORRECT);
        }

        if (e.command.Contains("Error #")) ex = new MA2CommandNotExecutedException(e.command);
    }
}


public class TelnetProgressEventArgs : EventArgs
{
    public string command { get; set; }
    public int state { get; set; }

    public const int Send = 1;
    public const int Recieve = 2;
    public const int Finished = 3;

    public TelnetProgressEventArgs(string cmd, int state)
    {
        this.command = cmd;
        this.state = state;
    }
}

public class TelnetConnectEventArgs : EventArgs
{
    public string message { get; set; }
    public int state { get; set; }

    public const int Connecting = 1;
    public const int Connected = 2;
    public const int Timeout = 3;

    public TelnetConnectEventArgs(string message, int state)
    {
        this.message = message;
        this.state = state;
    }
}