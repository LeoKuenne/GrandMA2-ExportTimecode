using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportReaperMarkersToGrandMA2
{
    static class Program
    {
        public static string version = "1.4";

        [STAThread]
        static void Main()
        {
            string response = "";
            using (WebClient webClient = new WebClient())
            {
                response = webClient.DownloadString("https://raw.githubusercontent.com/Hawk141198/GrandMA2-ExportTimecode/master/version");
            }

            response = response.Replace("\n", "");

            if (float.Parse(response) > float.Parse(version))
            {
                MessageBox.Show("Sie verwenden eine alte Version (" + version + ")!\n"+
                    "Die Version " + response + " ist bereits verfügbar!\n"+
                    "Sie können unter 'Updates' in der Menüleiste die neue Version herunterladen!", "Neue Version verfügbar!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
