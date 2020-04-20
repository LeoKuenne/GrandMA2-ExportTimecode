using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            this.cB_TcDefaultTrigger.DataSource = Enum.GetValues(typeof(TimecodeEventTrigger));
            this.cB_TcDefaultTrigger.SelectedIndexChanged += new System.EventHandler(this.cB_TcDefaultTrigger_SelectedIndexChanged);

            this.cB_TcFrameRate.DataSource = Enum.GetValues(typeof(FPS));
            this.cB_TcFrameRate.SelectedIndexChanged += new System.EventHandler(this.cB_TcFrameRate_SelectedIndexChanged);

            this.Text = "GrandMA2-ExportTimecode | Version:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
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
                
                if(csv.Count < 2)
                {
                    MessageBox.Show("Die ausgewählte Datei entspricht nicht dem erwarteten Format!\n" +
                        "Die Datei enthält keine Markerinformationen.",
                        "Fehler beim lesen der Datei!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sr.Close();
                    return;
                }

                TimelineFormat timelineFormat = TimelineFormat.HH_MM_SS;
                FPS baseFramerate = FPS.FPS25;

                using (var form = new TimecodeEventTimelineForm(csv.ToArray()[1]))
                {
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        timelineFormat = form.timelineFormat;
                        baseFramerate = form.baseFramerate;

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        sr.Close();
                        return;
                    }
                }
                                
                timecode = new Timecode((int) num_ExecPage.Value, (int) num_ExecItem.Value, (int) num_SeqItem.Value, txt_SeqName.Text, (int) num_TcItem.Value, txt_TcName.Text, (FPS) cB_TcFrameRate.SelectedItem, timelineFormat, TimecodeEventTrigger.Go);

                try
                {
                    timecode.ParseCSV(csv.ToArray(), baseFramerate);
                }catch(TimelineFormatMatchException ex)
                {
                    MessageBox.Show("Die ausgewählte Datei entspricht nicht dem erwarteten Format!\n" +
                        "Erwartetes Format: " + ex.Excepted + "\n" +
                        "Gelesenes Format: " + ex.ActualTimeline,
                        "Fehler beim lesen der Datei!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sr.Close();
                    return;
                }catch(Exception ex)
                {
                    MessageBox.Show("Es ist ein Fehler aufgetreten beim lesen der Datei!\n" +
                          ex.Message + "\n" + ex.StackTrace,
                          "Fehler beim lesen der Datei!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    sr.Close();
                    return;
                }

            
                gB_Save.Visible = true;
                gB_Timecode.Visible = true;
                txt_Open.Text = defaultPath;

                extensionsToolStripMenuItem.Enabled = true;
                networkuploadToolStripMenuItem.Enabled = true;

                dataGridView1.DataSource = timecode.TimecodeEvents.ToList();
                dataGridView1.AllowUserToResizeColumns = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                
                DataGridViewComboBoxColumn triggerColumn = new DataGridViewComboBoxColumn();
                var triggerTypes = Enum.GetValues(typeof(TimecodeEventTrigger));
                triggerColumn.DataSource = triggerTypes;
                triggerColumn.HeaderText = "Trigger";
                triggerColumn.DataPropertyName = "Trigger";

                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count-1);
                dataGridView1.Columns.Add(triggerColumn);

                timecode.TimelineFormat = TimelineFormat.HH_MM_SS;

                updateTimelineFormat(timecode.TimelineFormat);

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
            dataGridView1.Refresh();
        }

        private void txt_SeqName_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txt_SeqName.Text, @"[^A-Za-z0-9\s]"))
            {
                timecode.SetSeqName(txt_SeqName.Text);
            }
            else
            {
                MessageBox.Show("Es dürfen keine Sonderzeichen verwendet werden!\n", "Fehler bei der Eingabe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void cB_TcFrameRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            timecode.SetFrameRate((FPS) cB_TcFrameRate.SelectedValue);
            dataGridView1.Refresh();
        }

        private void txt_TcName_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txt_SeqName.Text, @"[^A-Za-z0-9\s]"))
            {
                timecode.SetTcName(txt_TcName.Text);
            }
            else
            {
                MessageBox.Show("Es dürfen keine Sonderzeichen verwendet werden!\n", "Fehler bei der Eingabe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void cB_TcDefaultTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((TimecodeEventTrigger) cB_TcDefaultTrigger.SelectedItem)
            {
                case TimecodeEventTrigger.Goto:
                    timecode.SetDefaultTrigger(TimecodeEventTrigger.Goto);
                    break;
                case TimecodeEventTrigger.Go:
                    timecode.SetDefaultTrigger(TimecodeEventTrigger.Go);
                    break;
                default:break;
            }

            dataGridView1.Refresh();
        }
        #endregion

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
        
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string name = (string)e.FormattedValue;

            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Name": //Cue Name

                    if(!Regex.IsMatch(name, @"[^A-Za-z0-9\s]"))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        MessageBox.Show("Es dürfen keine Sonderzeichen verwendet werden!\n", "Fehler bei der Eingabe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }

                    break;

                case "Time":

                    try
                    {
                        Timestamp.parseTimestamp(e.FormattedValue.ToString(), timecode.TimelineFormat, timecode.Framerate);
                    }
                    catch (TimelineFormatMatchException ex)
                    {
                        MessageBox.Show("Die Eingabe entspricht nicht dem Zeitformat!\n" +
                            "Erwartetes Format: " + ex.Excepted + "\n", "Fehler bei der Eingabe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        break;
                    }
                    catch (Exception) { };

                    e.Cancel = false;
                    break;

                case "Seq":
                    if (!Regex.IsMatch(name, @"[^0-9]") && int.Parse(name) > 0 )
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        MessageBox.Show("Es dürfen nur Ziffern verwendet werden! Der Wert muss größer als 0 sein.\n", "Fehler bei der Eingabe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    break;

                case "Cue":
                    if (!Regex.IsMatch(name, @"[^0-9]") && int.Parse(name) > 0)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        MessageBox.Show("Es dürfen nur Ziffern verwendet werden! Der Wert muss größer als 0 sein.\n", "Fehler bei der Eingabe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    break;

                case "Index":
                    if (!Regex.IsMatch(name, @"[^0-9]"))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        MessageBox.Show("Es dürfen nur Ziffern verwendet werden!\n", "Fehler bei der Eingabe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    break;

                default:
                    break;

            }
        }

        
        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Time":

                    try
                    {
                        e.Value = Timestamp.parseTimestamp(e.Value.ToString(), timecode.TimelineFormat, timecode.Framerate);
                    }
                    catch (TimelineFormatMatchException ex)
                    {
                        MessageBox.Show("Die Eingabe entspricht nicht dem Zeitformat!\n" +
                            "Erwartetes Format: " + ex.Excepted + "\n", "Fehler bei der Eingabe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.ParsingApplied = false;
                        break;
                    }
                    catch (Exception) { };

                    e.ParsingApplied = true;
                    break;

                default:
                    break;

            }
        }


        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && dataGridView1.Columns[e.ColumnIndex].Name == "Time")
                contextMenuStripTimeHeader.Show(dataGridView1, dataGridView1.PointToClient(Cursor.Position));
        }

        private void hoursMinutesSecondsMillisecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            updateTimelineFormat(TimelineFormat.HH_MM_SS);

            dataGridView1.Refresh();
        }

        private void totalFramesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTimelineFormat(TimelineFormat.TotalFrames);


            dataGridView1.Refresh();
        }
        private void hoursMinutesSecondsFramesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTimelineFormat(TimelineFormat.HH_MM_SS_FF);

            dataGridView1.Refresh();
        }


        public void updateTimelineFormat(TimelineFormat format)
        {
            foreach (TimecodeEvent timecodeEvent in timecode.TimecodeEvents)
            {
                timecodeEvent.Time.format = format;
            }


            hoursMinutesSecondsMillisecondsToolStripMenuItem.Checked = false;
            totalFramesToolStripMenuItem.Checked = false;
            minutesSecondsFramesToolStripMenuItem.Checked = false;

            switch (format)
            {
                case TimelineFormat.HH_MM_SS_FF:
                    minutesSecondsFramesToolStripMenuItem.Checked = true;
                    break;
                case TimelineFormat.HH_MM_SS:
                    hoursMinutesSecondsMillisecondsToolStripMenuItem.Checked = true;
                    break;
                case TimelineFormat.TotalFrames:
                    totalFramesToolStripMenuItem.Checked = true;
                    break;
            }


        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if(e.Context != DataGridViewDataErrorContexts.Parsing)
                e.ThrowException = true;
        }

        private void contextMenuStripTimeHeader_Opening(object sender, CancelEventArgs e)
        {
            dataGridView1.EndEdit();
        }
    }
}
