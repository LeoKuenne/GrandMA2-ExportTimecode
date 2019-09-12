using ExportReaperMarkersToGrandMA2;
using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFTP
{
    public enum FTPConnectionStatus
    {
        Connecting = 1,
        Connected = 2,
        Refused = 3,
        Timeout = 4,
        Disconnected = 5
    }
    
    public enum FTPProgressStatus
    {
        Uploading = 1,
        Uploaded = 2,
        Refused = 3,
    }

    

    public class FTPClient
    {
        
        private string Host;
        private string Username;
        private string Password;

        private Timecode Timecode;

        private SftpClient client;


        public event EventHandler<FTPClientConnectionEventArgs> OnConnectionChanged;
        public event EventHandler<FTPClientProgressEventArgs> OnProgressChanged;

        public FTPClient(string host, string username, string password, Timecode timecode)
        {
            this.Host = host;
            this.Username = username;
            this.Password = password;
            this.Timecode = timecode;
        }

        public async Task Connect() { 
            try
            {
                OnConnectionChanged(this, new FTPClientConnectionEventArgs("", FTPConnectionStatus.Connecting));

                client = new SftpClient(Host, Username, Password);

                client.ErrorOccurred += Client_ErrorOccurred;
                client.HostKeyReceived += Client_HostKeyReceived;
                
                await client.Connect();

                OnConnectionChanged(this, new FTPClientConnectionEventArgs("", FTPConnectionStatus.Connected));
            }
            catch (SocketException ex)
            {
                OnConnectionChanged(this, new FTPClientConnectionEventArgs("", FTPConnectionStatus.Refused));
                throw new SFTPConnectionException(FTPConnectionStatus.Timeout);
            }

        }

        public void Run()
        {
            StreamReader stream = Timecode.GetTimecodeXMLStream();
            stream.BaseStream.Position = 0;
            stream.BaseStream.Flush();
                
            client.BufferSize = 4 * 1024;
            client.ChangeDirectory("/actual/gma2/importexport");


            OnProgressChanged(this, new FTPClientProgressEventArgs("", FTPProgressStatus.Uploading));

            client.UploadFile(stream.BaseStream, Timecode.GetTcName() + ".xml", true, new Action<ulong>(callback));

            Thread.Sleep(1000);

            OnProgressChanged(this, new FTPClientProgressEventArgs("", FTPProgressStatus.Uploaded));
        
        }

        private void callback(ulong obj)
        {
            Console.WriteLine(obj);
        }

        private void Client_HostKeyReceived(object sender, HostKeyEventArgs e)
        {
            e.CanTrust = true;
        }

        private void Client_ErrorOccurred(object sender, Renci.SshNet.Common.ExceptionEventArgs e)
        {
            Console.WriteLine("Error in SshNet:" + e.Exception);
        }
        
    }

    public class FTPClientConnectionEventArgs : EventArgs
    {
        public FTPConnectionStatus State { get; set; }
        public string Message { get; set; }

        public FTPClientConnectionEventArgs(string message, FTPConnectionStatus status)
        {
            this.Message = message;
            this.State = status;
        }
    }

    public class FTPClientProgressEventArgs : EventArgs
    {
        public FTPProgressStatus State { get; set; }
        public string Message { get; set; }

        public FTPClientProgressEventArgs(string message, FTPProgressStatus status)
        {
            this.Message = message;
            this.State = status;
        }
    }
}
