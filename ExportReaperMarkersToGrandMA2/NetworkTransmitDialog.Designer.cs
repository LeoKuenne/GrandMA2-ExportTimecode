namespace ExportReaperMarkersToGrandMA2
{
    partial class NetworkTransmitDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.lbl_ipadress = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.cB_Mode = new System.Windows.Forms.ComboBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.49751F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.50249F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_Mode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_ipadress, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_username, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_password, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_ip, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_username, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_password, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cB_Mode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_send, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(511, 383);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.AutoSize = true;
            this.lbl_Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Mode.Location = new System.Drawing.Point(3, 0);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(252, 30);
            this.lbl_Mode.TabIndex = 0;
            this.lbl_Mode.Text = "Mode:";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_ipadress
            // 
            this.lbl_ipadress.AutoSize = true;
            this.lbl_ipadress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ipadress.Location = new System.Drawing.Point(3, 30);
            this.lbl_ipadress.Name = "lbl_ipadress";
            this.lbl_ipadress.Size = new System.Drawing.Size(252, 30);
            this.lbl_ipadress.TabIndex = 1;
            this.lbl_ipadress.Text = "IP-Adresse von der GrandMA2-Konsole:";
            this.lbl_ipadress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_username.Location = new System.Drawing.Point(3, 60);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(252, 30);
            this.lbl_username.TabIndex = 2;
            this.lbl_username.Text = "Benutzername:";
            this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_password.Location = new System.Drawing.Point(3, 90);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(252, 30);
            this.lbl_password.TabIndex = 3;
            this.lbl_password.Text = "Passwort:";
            this.lbl_password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_ip
            // 
            this.txt_ip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ip.Location = new System.Drawing.Point(261, 33);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(247, 20);
            this.txt_ip.TabIndex = 7;
            this.txt_ip.Text = "192.168.178.24";
            this.txt_ip.Leave += new System.EventHandler(this.txt_ip_Leave);
            // 
            // txt_username
            // 
            this.txt_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_username.Location = new System.Drawing.Point(261, 63);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(247, 20);
            this.txt_username.TabIndex = 8;
            this.txt_username.Text = "administrator";
            // 
            // txt_password
            // 
            this.txt_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_password.Location = new System.Drawing.Point(261, 93);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(247, 20);
            this.txt_password.TabIndex = 9;
            this.txt_password.Text = "admin";
            // 
            // cB_Mode
            // 
            this.cB_Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cB_Mode.FormattingEnabled = true;
            this.cB_Mode.Items.AddRange(new object[] {
            "Erstelle Sequence",
            "Erstelle Timecode",
            "Erstelle Sequence + Timecode"});
            this.cB_Mode.Location = new System.Drawing.Point(261, 3);
            this.cB_Mode.Name = "cB_Mode";
            this.cB_Mode.Size = new System.Drawing.Size(247, 21);
            this.cB_Mode.TabIndex = 10;
            this.cB_Mode.SelectedIndexChanged += new System.EventHandler(this.cB_TransmitType_SelectedIndexChanged);
            // 
            // btn_send
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btn_send, 2);
            this.btn_send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_send.Location = new System.Drawing.Point(3, 123);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(505, 24);
            this.btn_send.TabIndex = 11;
            this.btn_send.Text = "Übertragen!";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // progressBar1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar1, 2);
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 153);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(505, 24);
            this.progressBar1.TabIndex = 12;
            // 
            // richTextBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox1, 2);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 183);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(505, 197);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // NetworkTransmitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 383);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NetworkTransmitDialog";
            this.Text = "Netzwerkübertragung";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.Label lbl_ipadress;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.ComboBox cB_Mode;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}