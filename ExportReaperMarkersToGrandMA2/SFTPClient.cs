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
    public enum SFTPConnectionStatus
    {
        Undefinded = 0,
        Connecting = 1,
        Connected = 2,
        Refused = 3,
        Timeout = 4,
        Disconnected = 5,
        Refused_CredentialsWrong = 6
    }
    
    public enum SFTPProgressStatus
    {
        Uploading = 1,
        Uploaded = 2,
        Refused = 3,
    }

    

    public class SFTPClient
    {
        
        private string Host;
        private string Username;
        private string Password;

        private Timecode Timecode;

        private SftpClient client;

        private Exception exception;

        public event EventHandler<FTPClientConnectionEventArgs> OnConnectionChanged;
        public event EventHandler<FTPClientProgressEventArgs> OnProgressChanged;

        public SFTPClient(string host, string username, string password, Timecode timecode)
        {
            this.Host = host;
            this.Username = username;
            this.Password = password;
            this.Timecode = timecode;
        }

        public async Task Connect() { 
            try
            {
                OnConnectionChanged(this, new FTPClientConnectionEventArgs("", SFTPConnectionStatus.Connecting));

                ConnectionInfo info = new ConnectionInfo(this.Host, "sftp", new PasswordAuthenticationMethod(this.Username, this.Password));

                client = new SftpClient(info);
                
                client.ErrorOccurred += Client_ErrorOccurred;
                client.HostKeyReceived += Client_HostKeyReceived;
                
                await ClientConnect();

                if (exception != null)
                {
                    throw exception;
                }

                OnConnectionChanged(this, new FTPClientConnectionEventArgs("", SFTPConnectionStatus.Connected));
            }
            catch (SocketException)
            {
                OnConnectionChanged(this, new FTPClientConnectionEventArgs("", SFTPConnectionStatus.Refused));
                throw new SFTPConnectionException(SFTPConnectionStatus.Timeout);
            }
            catch (SshAuthenticationException)
            {
                OnConnectionChanged(this, new FTPClientConnectionEventArgs("", SFTPConnectionStatus.Refused));
                throw new SFTPConnectionException(SFTPConnectionStatus.Refused_CredentialsWrong);
            }
            catch (SshException)
            {
                OnConnectionChanged(this, new FTPClientConnectionEventArgs("", SFTPConnectionStatus.Undefinded));
                throw new SFTPConnectionException(SFTPConnectionStatus.Undefinded);
            }

        }

        private async Task ClientConnect()
        {
            await Task.Run(() => {
                try
                {
                    client.Connect();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });
        }

        public void Run()
        {
            StreamReader stream = Timecode.GetTimecodeXMLStream();
            stream.BaseStream.Position = 0;
            stream.BaseStream.Flush();
                
            client.BufferSize = 4 * 1024;
            //client.ChangeDirectory("/actual/gma2/importexport");


            OnProgressChanged(this, new FTPClientProgressEventArgs("", SFTPProgressStatus.Uploading));

            client.UploadFile(stream.BaseStream, Timecode.GetTcName() + ".xml", true);

            Thread.Sleep(1000);

            OnProgressChanged(this, new FTPClientProgressEventArgs("", SFTPProgressStatus.Uploaded));
        
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
        public SFTPConnectionStatus State { get; set; }
        public string Message { get; set; }

        public FTPClientConnectionEventArgs(string message, SFTPConnectionStatus status)
        {
            this.Message = message;
            this.State = status;
        }
    }

    public class FTPClientProgressEventArgs : EventArgs
    {
        public SFTPProgressStatus State { get; set; }
        public string Message { get; set; }

        public FTPClientProgressEventArgs(string message, SFTPProgressStatus status)
        {
            this.Message = message;
            this.State = status;
        }
    }
}
