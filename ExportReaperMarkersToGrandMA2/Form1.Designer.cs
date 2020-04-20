using System;

namespace ExportReaperMarkersToGrandMA2
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gB_Open = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_Open = new System.Windows.Forms.TableLayoutPanel();
            this.txt_Open = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.gB_Timecode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_Timecode = new System.Windows.Forms.TableLayoutPanel();
            this.gB_Exec = new System.Windows.Forms.GroupBox();
            this.num_ExecItem = new System.Windows.Forms.NumericUpDown();
            this.lbl_ExecItem = new System.Windows.Forms.Label();
            this.lbl_ExecPage = new System.Windows.Forms.Label();
            this.num_ExecPage = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gB_TimecodeItem = new System.Windows.Forms.GroupBox();
            this.cB_TcFrameRate = new System.Windows.Forms.ComboBox();
            this.cB_TcDefaultTrigger = new System.Windows.Forms.ComboBox();
            this.lbl_TcDefaultTrigger = new System.Windows.Forms.Label();
            this.lbl_TcFrameRate = new System.Windows.Forms.Label();
            this.txt_TcName = new System.Windows.Forms.TextBox();
            this.lbl_TcName = new System.Windows.Forms.Label();
            this.num_TcItem = new System.Windows.Forms.NumericUpDown();
            this.lbl_TcItem = new System.Windows.Forms.Label();
            this.gB_Seq = new System.Windows.Forms.GroupBox();
            this.txt_SeqName = new System.Windows.Forms.TextBox();
            this.lbl_SeqName = new System.Windows.Forms.Label();
            this.num_SeqItem = new System.Windows.Forms.NumericUpDown();
            this.lbl_SeqItem = new System.Windows.Forms.Label();
            this.gB_Save = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_Save = new System.Windows.Forms.TableLayoutPanel();
            this.txt_Save = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extensionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkuploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTimeHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hoursMinutesSecondsMillisecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesSecondsFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gB_Open.SuspendLayout();
            this.tableLayoutPanel_Open.SuspendLayout();
            this.gB_Timecode.SuspendLayout();
            this.tableLayoutPanel_Timecode.SuspendLayout();
            this.gB_Exec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_ExecItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ExecPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gB_TimecodeItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_TcItem)).BeginInit();
            this.gB_Seq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_SeqItem)).BeginInit();
            this.gB_Save.SuspendLayout();
            this.tableLayoutPanel_Save.SuspendLayout();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripTimeHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gB_Open
            // 
            this.gB_Open.AutoSize = true;
            this.gB_Open.Controls.Add(this.tableLayoutPanel_Open);
            this.gB_Open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB_Open.Location = new System.Drawing.Point(3, 28);
            this.gB_Open.Name = "gB_Open";
            this.gB_Open.Size = new System.Drawing.Size(834, 44);
            this.gB_Open.TabIndex = 0;
            this.gB_Open.TabStop = false;
            this.gB_Open.Text = "Reaper Marker File auswählen";
            // 
            // tableLayoutPanel_Open
            // 
            this.tableLayoutPanel_Open.AutoSize = true;
            this.tableLayoutPanel_Open.ColumnCount = 2;
            this.tableLayoutPanel_Open.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Open.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel_Open.Controls.Add(this.txt_Open, 0, 0);
            this.tableLayoutPanel_Open.Controls.Add(this.btn_Open, 1, 0);
            this.tableLayoutPanel_Open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Open.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel_Open.Name = "tableLayoutPanel_Open";
            this.tableLayoutPanel_Open.RowCount = 1;
            this.tableLayoutPanel_Open.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Open.Size = new System.Drawing.Size(828, 25);
            this.tableLayoutPanel_Open.TabIndex = 4;
            // 
            // txt_Open
            // 
            this.txt_Open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Open.Location = new System.Drawing.Point(0, 2);
            this.txt_Open.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.txt_Open.Name = "txt_Open";
            this.txt_Open.Size = new System.Drawing.Size(753, 20);
            this.txt_Open.TabIndex = 0;
            // 
            // btn_Open
            // 
            this.btn_Open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Open.Location = new System.Drawing.Point(753, 0);
            this.btn_Open.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 25);
            this.btn_Open.TabIndex = 1;
            this.btn_Open.Text = "Öffnen";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // gB_Timecode
            // 
            this.gB_Timecode.Controls.Add(this.tableLayoutPanel_Timecode);
            this.gB_Timecode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB_Timecode.Location = new System.Drawing.Point(3, 78);
            this.gB_Timecode.Name = "gB_Timecode";
            this.gB_Timecode.Size = new System.Drawing.Size(834, 313);
            this.gB_Timecode.TabIndex = 1;
            this.gB_Timecode.TabStop = false;
            this.gB_Timecode.Text = "Timecode Pool Item konfigurieren";
            this.gB_Timecode.Visible = false;
            // 
            // tableLayoutPanel_Timecode
            // 
            this.tableLayoutPanel_Timecode.ColumnCount = 2;
            this.tableLayoutPanel_Timecode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Timecode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Timecode.Controls.Add(this.gB_Exec, 1, 1);
            this.tableLayoutPanel_Timecode.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel_Timecode.Controls.Add(this.gB_TimecodeItem, 1, 2);
            this.tableLayoutPanel_Timecode.Controls.Add(this.gB_Seq, 1, 0);
            this.tableLayoutPanel_Timecode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Timecode.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel_Timecode.Name = "tableLayoutPanel_Timecode";
            this.tableLayoutPanel_Timecode.RowCount = 3;
            this.tableLayoutPanel_Timecode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Timecode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Timecode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Timecode.Size = new System.Drawing.Size(828, 294);
            this.tableLayoutPanel_Timecode.TabIndex = 0;
            // 
            // gB_Exec
            // 
            this.gB_Exec.AutoSize = true;
            this.gB_Exec.Controls.Add(this.num_ExecItem);
            this.gB_Exec.Controls.Add(this.lbl_ExecItem);
            this.gB_Exec.Controls.Add(this.lbl_ExecPage);
            this.gB_Exec.Controls.Add(this.num_ExecPage);
            this.gB_Exec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB_Exec.Location = new System.Drawing.Point(389, 101);
            this.gB_Exec.Name = "gB_Exec";
            this.gB_Exec.Size = new System.Drawing.Size(436, 92);
            this.gB_Exec.TabIndex = 9;
            this.gB_Exec.TabStop = false;
            this.gB_Exec.Text = "Wähle den Executor der Timecode Spur";
            // 
            // num_ExecItem
            // 
            this.num_ExecItem.Location = new System.Drawing.Point(166, 15);
            this.num_ExecItem.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.num_ExecItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_ExecItem.Name = "num_ExecItem";
            this.num_ExecItem.Size = new System.Drawing.Size(50, 20);
            this.num_ExecItem.TabIndex = 17;
            this.num_ExecItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_ExecItem.ValueChanged += new System.EventHandler(this.num_ExecItem_ValueChanged);
            // 
            // lbl_ExecItem
            // 
            this.lbl_ExecItem.AutoSize = true;
            this.lbl_ExecItem.Location = new System.Drawing.Point(106, 17);
            this.lbl_ExecItem.Name = "lbl_ExecItem";
            this.lbl_ExecItem.Size = new System.Drawing.Size(52, 13);
            this.lbl_ExecItem.TabIndex = 16;
            this.lbl_ExecItem.Text = "Executor:";
            // 
            // lbl_ExecPage
            // 
            this.lbl_ExecPage.AutoSize = true;
            this.lbl_ExecPage.Location = new System.Drawing.Point(9, 17);
            this.lbl_ExecPage.Name = "lbl_ExecPage";
            this.lbl_ExecPage.Size = new System.Drawing.Size(35, 13);
            this.lbl_ExecPage.TabIndex = 15;
            this.lbl_ExecPage.Text = "Page:";
            // 
            // num_ExecPage
            // 
            this.num_ExecPage.Location = new System.Drawing.Point(50, 15);
            this.num_ExecPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_ExecPage.Name = "num_ExecPage";
            this.num_ExecPage.Size = new System.Drawing.Size(50, 20);
            this.num_ExecPage.TabIndex = 14;
            this.num_ExecPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_ExecPage.ValueChanged += new System.EventHandler(this.num_ExecPage_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.tableLayoutPanel_Timecode.SetRowSpan(this.dataGridView1, 3);
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(380, 288);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // gB_TimecodeItem
            // 
            this.gB_TimecodeItem.AutoSize = true;
            this.gB_TimecodeItem.Controls.Add(this.cB_TcFrameRate);
            this.gB_TimecodeItem.Controls.Add(this.cB_TcDefaultTrigger);
            this.gB_TimecodeItem.Controls.Add(this.lbl_TcDefaultTrigger);
            this.gB_TimecodeItem.Controls.Add(this.lbl_TcFrameRate);
            this.gB_TimecodeItem.Controls.Add(this.txt_TcName);
            this.gB_TimecodeItem.Controls.Add(this.lbl_TcName);
            this.gB_TimecodeItem.Controls.Add(this.num_TcItem);
            this.gB_TimecodeItem.Controls.Add(this.lbl_TcItem);
            this.gB_TimecodeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB_TimecodeItem.Location = new System.Drawing.Point(389, 199);
            this.gB_TimecodeItem.Name = "gB_TimecodeItem";
            this.gB_TimecodeItem.Size = new System.Drawing.Size(436, 92);
            this.gB_TimecodeItem.TabIndex = 7;
            this.gB_TimecodeItem.TabStop = false;
            this.gB_TimecodeItem.Text = "Wähle das Timecode Pool Item:";
            // 
            // cB_TcFrameRate
            // 
            this.cB_TcFrameRate.FormattingEnabled = true;
            this.cB_TcFrameRate.Location = new System.Drawing.Point(196, 13);
            this.cB_TcFrameRate.Name = "cB_TcFrameRate";
            this.cB_TcFrameRate.Size = new System.Drawing.Size(69, 21);
            this.cB_TcFrameRate.TabIndex = 17;
            // 
            // cB_TcDefaultTrigger
            // 
            this.cB_TcDefaultTrigger.FormattingEnabled = true;
            this.cB_TcDefaultTrigger.Location = new System.Drawing.Point(360, 16);
            this.cB_TcDefaultTrigger.Name = "cB_TcDefaultTrigger";
            this.cB_TcDefaultTrigger.Size = new System.Drawing.Size(70, 21);
            this.cB_TcDefaultTrigger.TabIndex = 16;
            this.cB_TcDefaultTrigger.Text = "Go";
            // 
            // lbl_TcDefaultTrigger
            // 
            this.lbl_TcDefaultTrigger.AutoSize = true;
            this.lbl_TcDefaultTrigger.Location = new System.Drawing.Point(271, 16);
            this.lbl_TcDefaultTrigger.Name = "lbl_TcDefaultTrigger";
            this.lbl_TcDefaultTrigger.Size = new System.Drawing.Size(80, 13);
            this.lbl_TcDefaultTrigger.TabIndex = 14;
            this.lbl_TcDefaultTrigger.Text = "Default Trigger:";
            // 
            // lbl_TcFrameRate
            // 
            this.lbl_TcFrameRate.AutoSize = true;
            this.lbl_TcFrameRate.Location = new System.Drawing.Point(125, 16);
            this.lbl_TcFrameRate.Name = "lbl_TcFrameRate";
            this.lbl_TcFrameRate.Size = new System.Drawing.Size(65, 13);
            this.lbl_TcFrameRate.TabIndex = 14;
            this.lbl_TcFrameRate.Text = "Frame Rate:";
            // 
            // txt_TcName
            // 
            this.txt_TcName.Location = new System.Drawing.Point(50, 41);
            this.txt_TcName.Name = "txt_TcName";
            this.txt_TcName.Size = new System.Drawing.Size(380, 20);
            this.txt_TcName.TabIndex = 13;
            this.txt_TcName.Text = "Timecode 1";
            this.txt_TcName.TextChanged += new System.EventHandler(this.txt_TcName_TextChanged);
            // 
            // lbl_TcName
            // 
            this.lbl_TcName.AutoSize = true;
            this.lbl_TcName.Location = new System.Drawing.Point(6, 44);
            this.lbl_TcName.Name = "lbl_TcName";
            this.lbl_TcName.Size = new System.Drawing.Size(38, 13);
            this.lbl_TcName.TabIndex = 12;
            this.lbl_TcName.Text = "Name:";
            // 
            // num_TcItem
            // 
            this.num_TcItem.Location = new System.Drawing.Point(69, 14);
            this.num_TcItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_TcItem.Name = "num_TcItem";
            this.num_TcItem.Size = new System.Drawing.Size(50, 20);
            this.num_TcItem.TabIndex = 7;
            this.num_TcItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_TcItem.ValueChanged += new System.EventHandler(this.num_TcItem_ValueChanged);
            // 
            // lbl_TcItem
            // 
            this.lbl_TcItem.AutoSize = true;
            this.lbl_TcItem.Location = new System.Drawing.Point(9, 16);
            this.lbl_TcItem.Name = "lbl_TcItem";
            this.lbl_TcItem.Size = new System.Drawing.Size(54, 13);
            this.lbl_TcItem.TabIndex = 0;
            this.lbl_TcItem.Text = "Pool Item:";
            // 
            // gB_Seq
            // 
            this.gB_Seq.AutoSize = true;
            this.gB_Seq.Controls.Add(this.txt_SeqName);
            this.gB_Seq.Controls.Add(this.lbl_SeqName);
            this.gB_Seq.Controls.Add(this.num_SeqItem);
            this.gB_Seq.Controls.Add(this.lbl_SeqItem);
            this.gB_Seq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB_Seq.Location = new System.Drawing.Point(389, 3);
            this.gB_Seq.Name = "gB_Seq";
            this.gB_Seq.Size = new System.Drawing.Size(436, 92);
            this.gB_Seq.TabIndex = 6;
            this.gB_Seq.TabStop = false;
            this.gB_Seq.Text = "Wähle die Sequenz der Timecode Spur:";
            // 
            // txt_SeqName
            // 
            this.txt_SeqName.Location = new System.Drawing.Point(50, 40);
            this.txt_SeqName.Name = "txt_SeqName";
            this.txt_SeqName.Size = new System.Drawing.Size(380, 20);
            this.txt_SeqName.TabIndex = 11;
            this.txt_SeqName.Text = "Sequenze 1";
            this.txt_SeqName.TextChanged += new System.EventHandler(this.txt_SeqName_TextChanged);
            // 
            // lbl_SeqName
            // 
            this.lbl_SeqName.AutoSize = true;
            this.lbl_SeqName.Location = new System.Drawing.Point(6, 43);
            this.lbl_SeqName.Name = "lbl_SeqName";
            this.lbl_SeqName.Size = new System.Drawing.Size(38, 13);
            this.lbl_SeqName.TabIndex = 10;
            this.lbl_SeqName.Text = "Name:";
            // 
            // num_SeqItem
            // 
            this.num_SeqItem.Location = new System.Drawing.Point(66, 14);
            this.num_SeqItem.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_SeqItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_SeqItem.Name = "num_SeqItem";
            this.num_SeqItem.Size = new System.Drawing.Size(50, 20);
            this.num_SeqItem.TabIndex = 9;
            this.num_SeqItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_SeqItem.ValueChanged += new System.EventHandler(this.num_SeqItem_ValueChanged);
            // 
            // lbl_SeqItem
            // 
            this.lbl_SeqItem.AutoSize = true;
            this.lbl_SeqItem.Location = new System.Drawing.Point(6, 16);
            this.lbl_SeqItem.Name = "lbl_SeqItem";
            this.lbl_SeqItem.Size = new System.Drawing.Size(54, 13);
            this.lbl_SeqItem.TabIndex = 8;
            this.lbl_SeqItem.Text = "Pool Item:";
            // 
            // gB_Save
            // 
            this.gB_Save.AutoSize = true;
            this.gB_Save.Controls.Add(this.tableLayoutPanel_Save);
            this.gB_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB_Save.Location = new System.Drawing.Point(3, 397);
            this.gB_Save.Name = "gB_Save";
            this.gB_Save.Size = new System.Drawing.Size(834, 44);
            this.gB_Save.TabIndex = 2;
            this.gB_Save.TabStop = false;
            this.gB_Save.Text = "GrandMA2 Ordner auswählen";
            this.gB_Save.Visible = false;
            // 
            // tableLayoutPanel_Save
            // 
            this.tableLayoutPanel_Save.AutoSize = true;
            this.tableLayoutPanel_Save.ColumnCount = 2;
            this.tableLayoutPanel_Save.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Save.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel_Save.Controls.Add(this.txt_Save, 0, 0);
            this.tableLayoutPanel_Save.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Save.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel_Save.Name = "tableLayoutPanel_Save";
            this.tableLayoutPanel_Save.RowCount = 1;
            this.tableLayoutPanel_Save.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Save.Size = new System.Drawing.Size(828, 25);
            this.tableLayoutPanel_Save.TabIndex = 5;
            // 
            // txt_Save
            // 
            this.txt_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Save.Location = new System.Drawing.Point(0, 2);
            this.txt_Save.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.txt_Save.Name = "txt_Save";
            this.txt_Save.Size = new System.Drawing.Size(753, 20);
            this.txt_Save.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Save.Location = new System.Drawing.Point(753, 0);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 25);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Speichern";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.AutoSize = true;
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.gB_Open, 0, 1);
            this.tableLayoutPanel_Main.Controls.Add(this.gB_Save, 0, 3);
            this.tableLayoutPanel_Main.Controls.Add(this.gB_Timecode, 0, 2);
            this.tableLayoutPanel_Main.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 4;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(840, 444);
            this.tableLayoutPanel_Main.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.extensionsToolStripMenuItem,
            this.updatesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(840, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.helpToolStripMenuItem.Text = "Hilfe";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // extensionsToolStripMenuItem
            // 
            this.extensionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.networkuploadToolStripMenuItem});
            this.extensionsToolStripMenuItem.Enabled = false;
            this.extensionsToolStripMenuItem.Name = "extensionsToolStripMenuItem";
            this.extensionsToolStripMenuItem.Size = new System.Drawing.Size(95, 23);
            this.extensionsToolStripMenuItem.Text = "Erweiterungen";
            // 
            // networkuploadToolStripMenuItem
            // 
            this.networkuploadToolStripMenuItem.Enabled = false;
            this.networkuploadToolStripMenuItem.Name = "networkuploadToolStripMenuItem";
            this.networkuploadToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.networkuploadToolStripMenuItem.Text = "Netzwerk-Upload";
            this.networkuploadToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // updatesToolStripMenuItem
            // 
            this.updatesToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.updatesToolStripMenuItem.Enabled = false;
            this.updatesToolStripMenuItem.Name = "updatesToolStripMenuItem";
            this.updatesToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.updatesToolStripMenuItem.Text = "Updates";
            this.updatesToolStripMenuItem.Visible = false;
            this.updatesToolStripMenuItem.Click += new System.EventHandler(this.updatesToolStripMenuItem_Click);
            // 
            // contextMenuStripTimeHeader
            // 
            this.contextMenuStripTimeHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hoursMinutesSecondsMillisecondsToolStripMenuItem,
            this.minutesSecondsFramesToolStripMenuItem,
            this.totalFramesToolStripMenuItem});
            this.contextMenuStripTimeHeader.Name = "contextMenuStripTimeHeader";
            this.contextMenuStripTimeHeader.Size = new System.Drawing.Size(269, 92);
            this.contextMenuStripTimeHeader.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripTimeHeader_Opening);
            // 
            // hoursMinutesSecondsMillisecondsToolStripMenuItem
            // 
            this.hoursMinutesSecondsMillisecondsToolStripMenuItem.Checked = true;
            this.hoursMinutesSecondsMillisecondsToolStripMenuItem.CheckOnClick = true;
            this.hoursMinutesSecondsMillisecondsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hoursMinutesSecondsMillisecondsToolStripMenuItem.Name = "hoursMinutesSecondsMillisecondsToolStripMenuItem";
            this.hoursMinutesSecondsMillisecondsToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.hoursMinutesSecondsMillisecondsToolStripMenuItem.Text = "Hours:Minutes:Seconds:Milliseconds";
            this.hoursMinutesSecondsMillisecondsToolStripMenuItem.Click += new System.EventHandler(this.hoursMinutesSecondsMillisecondsToolStripMenuItem_Click);
            // 
            // minutesSecondsFramesToolStripMenuItem
            // 
            this.minutesSecondsFramesToolStripMenuItem.Name = "minutesSecondsFramesToolStripMenuItem";
            this.minutesSecondsFramesToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.minutesSecondsFramesToolStripMenuItem.Text = "Hours:Minutes:Seconds:Frames";
            this.minutesSecondsFramesToolStripMenuItem.Click += new System.EventHandler(this.hoursMinutesSecondsFramesToolStripMenuItem_Click);
            // 
            // totalFramesToolStripMenuItem
            // 
            this.totalFramesToolStripMenuItem.Name = "totalFramesToolStripMenuItem";
            this.totalFramesToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.totalFramesToolStripMenuItem.Text = "Total Frames";
            this.totalFramesToolStripMenuItem.Click += new System.EventHandler(this.totalFramesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 444);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(595, 392);
            this.Name = "Form1";
            this.Text = "Exporterie Reaper Marker nach GrandMA2 | Version: 1.2";
            this.gB_Open.ResumeLayout(false);
            this.gB_Open.PerformLayout();
            this.tableLayoutPanel_Open.ResumeLayout(false);
            this.tableLayoutPanel_Open.PerformLayout();
            this.gB_Timecode.ResumeLayout(false);
            this.tableLayoutPanel_Timecode.ResumeLayout(false);
            this.tableLayoutPanel_Timecode.PerformLayout();
            this.gB_Exec.ResumeLayout(false);
            this.gB_Exec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_ExecItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ExecPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gB_TimecodeItem.ResumeLayout(false);
            this.gB_TimecodeItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_TcItem)).EndInit();
            this.gB_Seq.ResumeLayout(false);
            this.gB_Seq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_SeqItem)).EndInit();
            this.gB_Save.ResumeLayout(false);
            this.gB_Save.PerformLayout();
            this.tableLayoutPanel_Save.ResumeLayout(false);
            this.tableLayoutPanel_Save.PerformLayout();
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.tableLayoutPanel_Main.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripTimeHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gB_Open;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.TextBox txt_Open;
        private System.Windows.Forms.GroupBox gB_Timecode;
        private System.Windows.Forms.GroupBox gB_Save;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_Save;
        private System.Windows.Forms.GroupBox gB_TimecodeItem;
        private System.Windows.Forms.TextBox txt_TcName;
        private System.Windows.Forms.Label lbl_TcName;
        private System.Windows.Forms.NumericUpDown num_TcItem;
        private System.Windows.Forms.Label lbl_TcItem;
        private System.Windows.Forms.GroupBox gB_Seq;
        private System.Windows.Forms.TextBox txt_SeqName;
        private System.Windows.Forms.Label lbl_SeqName;
        private System.Windows.Forms.NumericUpDown num_SeqItem;
        private System.Windows.Forms.Label lbl_SeqItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_TcFrameRate;
        private System.Windows.Forms.GroupBox gB_Exec;
        private System.Windows.Forms.NumericUpDown num_ExecItem;
        private System.Windows.Forms.Label lbl_ExecItem;
        private System.Windows.Forms.Label lbl_ExecPage;
        private System.Windows.Forms.NumericUpDown num_ExecPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Open;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Save;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Timecode;
        private System.Windows.Forms.ComboBox cB_TcDefaultTrigger;
        private System.Windows.Forms.Label lbl_TcDefaultTrigger;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extensionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkuploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTimeHeader;
        private System.Windows.Forms.ToolStripMenuItem hoursMinutesSecondsMillisecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalFramesToolStripMenuItem;
        private System.Windows.Forms.ComboBox cB_TcFrameRate;
        private System.Windows.Forms.ToolStripMenuItem minutesSecondsFramesToolStripMenuItem;
    }
}

