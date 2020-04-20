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
    public partial class HelpDialog : Form
    {
        public HelpDialog()
        {
            InitializeComponent();

            webBrowser1.Navigate("http://download.lightemotions.net/ExportReaperMarkersToGrandMA2/Help.html");
        }
    }
}
