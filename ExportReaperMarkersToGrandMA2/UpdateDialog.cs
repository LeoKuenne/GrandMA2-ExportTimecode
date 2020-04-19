using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportReaperMarkersToGrandMA2
{
    public partial class UpdateDialog : Form
    {
        public UpdateDialog()
        {
            InitializeComponent();

            lbl_DownloadInfo.Text = "";
            button1.Enabled = false;
        }

        private void UpdateDialog_Load(object sender, EventArgs e)
        {
            string[] response;
            string Changelog = "";
            using (WebClient webClient = new WebClient())
            {
                string file = webClient.DownloadString("https://raw.githubusercontent.com/Hawk141198/GrandMA2-ExportTimecode/master/version");
                response = file.Split(new[] { "\n" }, StringSplitOptions.None);
            }

            for (int i = 2; i < response.Length; i++)
            {
                Changelog += response[i] + "\n";
            }

            if (float.Parse(response[1]) > float.Parse(Program.Version.ToString()))
            {
                lblInfo.Text = "Sie benutzten eine alte Version! Es ist bereits eine aktuellere Version verfügbar!" +
                    "\n" +
                    "Ihre Version: " + Program.Version + "\n" +
                    "Neue Version: " + response[1] + "\n" +
                    "Wollen Sie die neue Version herunterladen?";
                richTextBox1.Text = Changelog;
                button1.Enabled = true;
            }
            else if(float.Parse(response[1]) <= float.Parse(Program.Version.ToString()))
            {
                lblInfo.Text = "Sie benutzen die aktuellste Verison!";
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            WebClient d = new WebClient();
            d.DownloadProgressChanged += DownloadProgressChanged;
            d.DownloadFileCompleted += DownloadFileCompleted;
            d.DownloadFileAsync(new Uri("https://github.com/Hawk141198/GrandMA2-ExportTimecode/raw/master/GrandMA2-ExportTimecode.exe"), "GrandMA2-ExportTimecode.exe");
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lbl_DownloadInfo.Text = "Download abgeschlossen! Die aktuelle Version liegt in dem selben Ordner wie diese Version!";
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lbl_DownloadInfo.Text = e.BytesReceived + " Bytes / " + e.TotalBytesToReceive + " Bytes";
        }
    }
}
