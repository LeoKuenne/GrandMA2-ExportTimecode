using ExportReaperMarkersToGrandMA2;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telnet {

    public enum TelnetProgressEvent
    {
        Send = 1,
        Recieve = 2,
        Finished = 3,
    }

    public enum TelnetConnectionStatus
    {
        Connecting = 1,
        Connected = 2,
        Timeout = 3,
        LoginNeeded = 4,
        Disabled = 5
    }
    
    public class TelnetInterface
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

        public TelnetInterface(string host, string[] commands, string user, string password)
        {

            this.Host = host;
            this.Commands = commands;
            this.User = user;
            this.Password = password;

            OnCommandSend = null;
            ex = null;

            Port = 30000;

        }

        public async Task Connect()
        {
            try
            {
                Connected = false;
                OnConnectionChange(this, new TelnetConnectEventArgs("", TelnetConnectionStatus.Connecting));
                Socket = new TcpClient();
                await Socket.ConnectAsync(Host, Port);
                Connected = true;
                NetworkStream = Socket.GetStream();
                InputStream = new StreamReader(NetworkStream);
                OutputStream = new StreamWriter(NetworkStream);
                
                this.OnFeedbackRecieved += new EventHandler<TelnetProgressEventArgs>(onFeedbackRecieved);
                RecieveFeedback();

                OnConnectionChange(this, new TelnetConnectEventArgs("", TelnetConnectionStatus.Connected));
            }
            catch (SocketException)
            {
                OnConnectionChange(this, new TelnetConnectEventArgs("", TelnetConnectionStatus.Timeout));
                throw new TelnetConnectionException(TelnetConnectionStatus.Timeout);
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

            OnProgressFinished(this, new TelnetProgressEventArgs("", TelnetProgressEvent.Finished));
        }

        private void SendCommand(string cmd)
        {
            OutputStream.WriteLine(cmd);
            OutputStream.Flush();

            OnCommandSend(this, new TelnetProgressEventArgs(cmd, TelnetProgressEvent.Send));

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

            OnFeedbackRecieved(this, new TelnetProgressEventArgs(line, TelnetProgressEvent.Recieve));

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
            if (e.Command.Contains("LOGIN NEEDED") || e.Command.Contains("Login incorrect"))
            {
                throw new TelnetConnectionException(TelnetConnectionStatus.LoginNeeded);
            }

            if (e.Command.Contains("Remote commandline disabled"))
            {
                throw new TelnetConnectionException(TelnetConnectionStatus.Disabled);
            }

            if (e.Command.Contains("Error #")) ex = new MA2CommandNotExecutedException(e.Command);
        }
    }


    public class TelnetProgressEventArgs : EventArgs
    {
        public string Command { get; set; }
        public TelnetProgressEvent State { get; set; }

        
        public TelnetProgressEventArgs(string cmd, TelnetProgressEvent state)
        {
            this.Command = cmd;
            this.State = state;
        }
    }

    public class TelnetConnectEventArgs : EventArgs
    {
        public string Message { get; set; }
        public TelnetConnectionStatus State { get; set; }


        public TelnetConnectEventArgs(string message, TelnetConnectionStatus state)
        {
            this.Message = message;
            this.State = state;
        }
    }
}