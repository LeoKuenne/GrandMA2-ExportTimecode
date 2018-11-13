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

                timecode = new Timecode(num_SeqPage.Value+"."+num_SeqItem.Value, txt_SeqName.Text,(int) num_TcFrameRate.Value);
                timecode.parseCSV(csv.ToArray());

                gB_Save.Visible = true;
                gB_Timecode.Visible = true;
            }

            
        }
    }
}
