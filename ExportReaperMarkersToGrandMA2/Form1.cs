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

namespace ExportReaperMarkersToGrandMA2
{
    public partial class Form1 : Form
    {
        Timecode timecode;

        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            string defaultPath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.csv|*.*";
            openFileDialog.FilterIndex = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                defaultPath = openFileDialog.FileName;
                txt_Open.Text = defaultPath;
                StreamReader sr = new StreamReader(defaultPath);
                string temp = sr.ReadLine();
                List<string> csv = new List<string>();
                while (temp != null)
                {
                    csv.Add(temp);
                    temp = sr.ReadLine();
                }
                
                timecode = new Timecode((int) num_ExecPage.Value, (int) num_ExecItem.Value, (int) num_SeqItem.Value, txt_SeqName.Text, (int) num_TcItem.Value, txt_TcName.Text, (int) num_TcFrameRate.Value);
                timecode.ParseCSV(csv.ToArray());

                gB_Save.Visible = true;
                gB_Timecode.Visible = true;
            }

            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txt_Save.Text = folderBrowserDialog.SelectedPath;
                timecode.writeXML(folderBrowserDialog.SelectedPath);
            }

        }

        private void num_SeqItem_ValueChanged(object sender, EventArgs e)
        {
            timecode.SetSeq((int) num_SeqItem.Value);
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
        }

        private void txt_TcName_TextChanged(object sender, EventArgs e)
        {
            timecode.SetTcName(txt_TcName.Text);
        }
    }
}
