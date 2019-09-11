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
    public partial class NetworkTransmitDialog : Form
    {
        private Timecode Timecode;
        private Telnet TelnetInterface;
        private string[] Cmds;
        

        public NetworkTransmitDialog(Timecode tc)
        {
            InitializeComponent();
            
            this.Timecode = tc;
            this.cB_Mode.SelectedIndex = 0;
            this.TelnetInterface = null;
        }

        private void cB_TransmitType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cB_Mode.SelectedIndex)
                {
                    case 0:
                        Cmds = Timecode.getMacroLines();
                        
                        TelnetInterface = new Telnet(txt_ip.Text, Cmds, txt_username.Text, txt_password.Text);
                        TelnetInterface.OnConnectionChange += new EventHandler<TelnetConnectEventArgs>(OnTelnetConnectionChange);
                        await TelnetInterface.Connect();
                       
                        break;

                    default:
                        MessageBox.Show("Der selektierte Übertragungsmodus ist nicht verfügbar. Bitte wählen Sie einen verfügbaren Modus aus!", "Übertragungsmodus nicht verfügbar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

            }
            catch (MA2CommandNotExecutedException eMA)
            {
                ConsoleOutput("GrandMA2 Kommando konnte nicht ausgeführt werden!\n", Color.Red, FontStyle.Bold);
                progressBar1.Value = 0;
                MessageBox.Show("Ein Fehler ist aufgetreten beim ausführen des folgenden Kommando:\t" + eMA.command + "\nFehlermeldung:\t" + eMA.error, "GrandMA2 Command wurde nicht ausgeführt!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TelnetConnectionException eTel)
            {
                switch (eTel.state)
                {
                    case TelnetConnectionException.Refused:
                        ConsoleOutput("Telnet Verbindung nicht möglich!\n", Color.Red, FontStyle.Bold);
                        MessageBox.Show("Die Telnet-Verbindung zur angegebenen GrandMA2-Konsole kann nicht hergestellt werden!\n" +
                            "Folgende Punkte müssen beachtet werden:\n\n" +
                            "- Setup -> Global Settings -> Telnet muss auf 'Login Enabled' stehen\n" +
                            "- Dieser PC muss mit dem MA-Net verbunden sein und mit ihm kommunizieren können. " +
                            "Mehr dazu unter 'Networking' des GrandMA2 User-Manuals. \n", "Fehler beim verbinden zur GrandMA2-Konsole!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case TelnetConnectionException.LOGIN_INCORRECT:
                        ConsoleOutput("Telnet Verbindung nicht möglich! Falsche Anmeldedaten!\n", Color.Red, FontStyle.Bold);
                        progressBar1.Value = 0;
                        MessageBox.Show("Die Telnet-Verbindung zur angegebenen GrandMA2-Konsole kann nicht hergestellt werden!\n\n" +
                            "Der angegebene Benutzername oder Passwort ist falsch. Bitte überprüfen Sie ihre Eingabe!", "Fehler beim verbinden zur GrandMA2-Konsole!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        break;
                }
                
            }

        }

        private void Telnet_OnConnectionChange(object sender, TelnetConnectEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txt_ip_Leave(object sender, EventArgs e)
        {
            IPAddress address;
            if (!IPAddress.TryParse(txt_ip.Text, out address))
            {
                MessageBox.Show("Die angegebene IP-Adresse ist keine gültige IP-Adresse. Bitte geben Sie eine gültige IPv4-Adresse ein!", "Fehler bei der Eingabe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void OnCommandSend(object sender, TelnetProgressEventArgs e)
        {
            progressBar1.PerformStep();
            ConsoleOutput("Send:", Color.Green, FontStyle.Bold);
            ConsoleOutput(" \t" + e.command + "\n");
        }

        private void OnFeedbackRecieve(object sender, TelnetProgressEventArgs e)
        {

            ConsoleOutput("Recieve:", Color.Green, FontStyle.Bold);
            ConsoleOutput(" " + e.command + "\n");
        }

        private void OnProgressFinished(object sender, TelnetProgressEventArgs e)
        {
            ConsoleOutput("Sucessfull finished!\n", Color.Green, FontStyle.Bold);
        }


        private void OnTelnetConnectionChange(object sender, TelnetConnectEventArgs e)
        {
            switch (e.state)
            {
                case TelnetConnectEventArgs.Connecting:
                    ConsoleOutput("Verbindung nach " + txt_ip.Text + " wird aufgebaut... Bitte warten...\n", Color.Black, FontStyle.Bold);
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    progressBar1.Value = 0;
                    btn_send.Enabled = false;
                    txt_ip.Enabled = false;
                    txt_password.Enabled = false;
                    txt_username.Enabled = false;
                    break;

                case TelnetConnectEventArgs.Connected:

                    progressBar1.Style = ProgressBarStyle.Continuous;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = Cmds.Length + 1; //+1 is Login Command
                    progressBar1.Step = 1;
                    progressBar1.Value = 0;


                    TelnetInterface.OnCommandSend += new EventHandler<TelnetProgressEventArgs>(this.OnCommandSend);
                    TelnetInterface.OnFeedbackRecieved += new EventHandler<TelnetProgressEventArgs>(this.OnFeedbackRecieve);
                    TelnetInterface.OnProgressFinished += new EventHandler<TelnetProgressEventArgs>(this.OnProgressFinished);

                    TelnetInterface.Run();

                    btn_send.Enabled = true;
                    txt_ip.Enabled = true;
                    txt_password.Enabled = true;
                    txt_username.Enabled = true;
                    break;
                case TelnetConnectEventArgs.Timeout:
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    progressBar1.Value = 0;
                    btn_send.Enabled = true;
                    txt_ip.Enabled = true;
                    txt_password.Enabled = true;
                    txt_username.Enabled = true;
                    break;
            }

        }

        private void ConsoleOutput(string text)
        {
            richTextBox1.AppendText(text);
            richTextBox1.Update();
        }

        private void ConsoleOutput(string text, Color c)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;

            richTextBox1.SelectionColor = c;

            richTextBox1.AppendText(text);
            richTextBox1.Update();

            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        }

        private void ConsoleOutput(string text, Color c, FontStyle style)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;

            richTextBox1.SelectionColor = c;
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, style);

            richTextBox1.AppendText(text);
            richTextBox1.Update();

            richTextBox1.SelectionColor = richTextBox1.ForeColor;
            richTextBox1.SelectionFont = richTextBox1.Font;

        }
    }
}
