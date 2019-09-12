using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Environment;

namespace ExportReaperMarkersToGrandMA2
{
    public partial class Form1 : Form
    {
        Timecode timecode;

        public Form1()
        {
            InitializeComponent();

            this.Text = "GrandMA2-ExportTimecode | Version:" + Program.version;
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            string defaultPath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV-Files(*.csv) | *.csv";
            openFileDialog.FilterIndex = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                defaultPath = openFileDialog.FileName;
                
                StreamReader sr = new StreamReader(defaultPath);
                string temp = sr.ReadLine();
                List<string> csv = new List<string>();
                while (temp != null)
                {
                    csv.Add(temp);
                    temp = sr.ReadLine();
                }
                
                timecode = new Timecode((int) num_ExecPage.Value, (int) num_ExecItem.Value, (int) num_SeqItem.Value, txt_SeqName.Text, (int) num_TcItem.Value, txt_TcName.Text, (int) num_TcFrameRate.Value, "Go");
                if (!timecode.ParseCSV(csv.ToArray()))
                {
                    MessageBox.Show("Die ausgewählte Datei entspricht nicht dem erwarteten Format!\n" +
                        "Folgende Punkte müssen beachtet werden:\n\n" +
                        "- Es muss eine von Reaper erstellte Datei ausgewählt werden\n" +
                        "- Die Timeline muss auf dem Format:\n" +
                        "\t 'Hours:Minutes:Seconds:Frames' \n" +
                        "  stehen(Rechtsklick auf die Timeline)", "Fehler beim lesen der Datei!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sr.Close();
                    return;
                }

                gB_Save.Visible = true;
                gB_Timecode.Visible = true;
                txt_Open.Text = defaultPath;

                extensionsToolStripMenuItem.Enabled = true;
                networkuploadToolStripMenuItem.Enabled = true;

                dataGridView1.DataSource = timecode.timecodeEvents.ToList();
                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                
                sr.Close();
            }

            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = txt_Save.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txt_Save.Text = folderBrowserDialog.SelectedPath;

                if (!Directory.Exists(folderBrowserDialog.SelectedPath + "\\importexport"))
                {
                    Directory.CreateDirectory(folderBrowserDialog.SelectedPath + "\\importexport");
                }
                if (!Directory.Exists(folderBrowserDialog.SelectedPath + "\\macros"))
                {
                    Directory.CreateDirectory(folderBrowserDialog.SelectedPath + "\\macros");
                }


                timecode.saveTimecodeXMLToFile(folderBrowserDialog.SelectedPath + "\\importexport");
                timecode.saveMacroXML(folderBrowserDialog.SelectedPath + "\\macros");

                MessageBox.Show("Datei gespeichert!", "Speichern", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        #region Eventhandler
        private void num_SeqItem_ValueChanged(object sender, EventArgs e)
        {
            timecode.SetSeq((int) num_SeqItem.Value);
            dataGridView1.DataSource = timecode.timecodeEvents.ToList();
        }

        private void txt_SeqName_TextChanged(object sender, EventArgs e)
        {
            timecode.SetSeqName(txt_SeqName.Text);
        }

        private void num_ExecPage_ValueChanged(object sender, EventArgs e)
        {
            timecode.SetPage((int) num_ExecPage.Value);
        }

        private void num_ExecItem_ValueChanged(object sender, EventArgs e)
        {
            timecode.SetExec((int) num_ExecItem.Value);
        }

        private void num_TcItem_ValueChanged(object sender, EventArgs e)
        {
            timecode.SetTc((int) num_TcItem.Value);
        }

        private void num_TcFrameRate_ValueChanged(object sender, EventArgs e)
        {
            timecode.SetFrameRate((int) num_TcFrameRate.Value);
            dataGridView1.DataSource = timecode.timecodeEvents.ToList();
        }

        private void txt_TcName_TextChanged(object sender, EventArgs e)
        {
            timecode.SetTcName(txt_TcName.Text);
        }
        
        private void cB_TcDefaultTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cB_TcDefaultTrigger.SelectedIndex)
            {
                case 0:
                    timecode.SetDefaultTrigger("Goto");
                    dataGridView1.DataSource = timecode.timecodeEvents.ToList();
                    break;
                case 1:
                    timecode.SetDefaultTrigger("Go");
                    dataGridView1.DataSource = timecode.timecodeEvents.ToList();
                    break;
                default:break;
            }
        }
        #endregion

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.SelectedCells[0].ColumnIndex == 1)
            {
                using (var form = new FormTime(timecode.timecodeEvents[dataGridView1.SelectedCells[0].RowIndex].Time, (int) num_TcFrameRate.Value))
                {
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        timecode.timecodeEvents[dataGridView1.SelectedCells[0].RowIndex].Time = form.time;
                    }
                }

                dataGridView1.EndEdit();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpDialog help = new HelpDialog();
            help.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkTransmitDialog dia = new NetworkTransmitDialog(timecode);
            dia.Show();
        }

        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDialog updateDialog = new UpdateDialog();
            updateDialog.Show();
        }
    }
}
