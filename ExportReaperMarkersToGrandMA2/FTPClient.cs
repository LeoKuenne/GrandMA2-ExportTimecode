using ExportReaperMarkersToGrandMA2;
using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP
{
    class FTPClient
    {
        private string Sshkey = "ssh-rsa AAAAB3NzaC1yc2EAAAABJQAAAQEAkI7KAhkYvRM41NIzJc5KoB/bF7kIYdMFhUFnHtZIw3b0OZ2vsFNpG1bxltAUNW4NLG2eAFcLrbAg41q+IsOkd71IrGOBUJ0Qoipheydpyp/J67stvYFcVTqapkuDek0diVuBUIDgyo+aLHkckU9VrqyFqURzU6M1tW3RPUYYr839QwlBHfG91hXlHcyyjUEBHzzlN54Y0pfHNxLCYQb1T/UnSAJ+0D0XdnDd5YVoJ819j8Tnhj9neWGW2BURO7k1vv49YLpLYC3SBgEPVSt2gSx2dnodO2e/rXqGp5wixEK3yZmUlNBsEjKLDjIXo1hpWH1qLI3UhHEDRRbYNfigEw== rsa-key-20190912";

        private string Host;
        private string Username;
        private string Password;

        private Timecode Timecode;

        private SftpClient client;


        public event EventHandler on;


        public FTPClient(string host, string username, string password, Timecode timecode)
        {
            this.Host = host;
            this.Username = username;
            this.Password = password;
            this.Timecode = timecode;
        }

        public void Run()
        {
        
            client = new SftpClient(Host, Username, Password);
            client.ErrorOccurred += Client_ErrorOccurred;
            client.HostKeyReceived += Client_HostKeyReceived;

            StreamReader stream = Timecode.GetTimecodeXMLStream();
            stream.BaseStream.Position = 0;
            stream.BaseStream.Flush();

            client.Connect();

            client.BufferSize = 4 * 1024;
            client.ChangeDirectory("/actual/gma2/importexport");
            
            client.UploadFile(stream.BaseStream, Timecode.GetTcName() + ".xml", true, new Action<ulong>(callback));
            Thread.Sleep(1000);
            client.Disconnect();
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

        public ConnectionInfo getSftpConnection(string host, string username, int port)
        {
            return new ConnectionInfo(host, port, username, privateKeyObject(username));
        }

        private AuthenticationMethod[] privateKeyObject(string username)
        {

            StreamWriter sw = new StreamWriter(new MemoryStream());

            sw.WriteLine(Sshkey);

            PrivateKeyFile privateKeyFile = new PrivateKeyFile(sw.BaseStream, "GrandMA2");
            PrivateKeyAuthenticationMethod privateKeyAuthenticationMethod = new PrivateKeyAuthenticationMethod(username, privateKeyFile);
            return new AuthenticationMethod[] { privateKeyAuthenticationMethod };
        }

        private byte[] StringToByteArray(string str)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetBytes(str);
        }

    }
}
