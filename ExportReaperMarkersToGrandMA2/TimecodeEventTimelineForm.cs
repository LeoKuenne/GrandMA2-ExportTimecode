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
    public partial class TimecodeEventTimelineForm : Form
    {

        public TimelineFormat timelineFormat;
        public FPS baseFramerate;

        public TimecodeEventTimelineForm(string exampleTimestamp)
        {
            InitializeComponent();
            timelineFormat = TimelineFormat.HH_MM_SS_FF;
            lblExampleFrame.Text = exampleTimestamp;
        }

        private void TimecodeEventTimelineForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(TimelineFormat));
            comboBox2.DataSource = Enum.GetValues(typeof(FPS));

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            timelineFormat = (TimelineFormat) comboBox1.SelectedValue;
            baseFramerate = (FPS) comboBox2.SelectedValue;
            
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((TimelineFormat) comboBox1.SelectedValue)
            {
                case TimelineFormat.HH_MM_SS_FF:
                    comboBox2.Enabled = true;
                    break;
                case TimelineFormat.MM_SS:
                    comboBox2.Enabled = false;
                    break;
                default:
                    break;

            }
        }
    }
}
