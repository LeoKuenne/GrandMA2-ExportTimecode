using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportReaperMarkersToGrandMA2
{
    public partial class FormTime : Form
    {
        public int time;
        private int fps;

        public FormTime(int time, int fps)
        {
            InitializeComponent();

            this.time = time;
            this.fps = fps;
            num_Frames.Maximum = fps;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            int Frames = (int) num_Frames.Value;
            int Seconds = (int) num_Seconds.Value * fps;
            int Minutes = (int) num_Minutes.Value * fps * 60;
            int Hours = (int) num_Hours.Value * fps * 60 * 60;
            time = Frames + Seconds + Minutes + Hours;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormTime_Load(object sender, EventArgs e)
        {
            this.num_Hours.Value = time / (60 * 60 * fps);
            
            time = time - (int)this.num_Hours.Value * fps * 60 * 60;
            this.num_Minutes.Value = (time) / (60 * fps);

            time = time - (int)this.num_Minutes.Value * 60 * fps;
            this.num_Seconds.Value = (time) / fps;

            time = time - (int)this.num_Seconds.Value * fps;
            this.num_Frames.Value = time;
        }
    }
}
