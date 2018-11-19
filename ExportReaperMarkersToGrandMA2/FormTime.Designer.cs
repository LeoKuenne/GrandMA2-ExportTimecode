namespace ExportReaperMarkersToGrandMA2
{
    partial class FormTime
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
            this.label1 = new System.Windows.Forms.Label();
            this.num_Hours = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.num_Minutes = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.num_Seconds = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.num_Frames = new System.Windows.Forms.NumericUpDown();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Minutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Seconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Frames)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stunden";
            // 
            // num_Hours
            // 
            this.num_Hours.Location = new System.Drawing.Point(75, 7);
            this.num_Hours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.num_Hours.Name = "num_Hours";
            this.num_Hours.Size = new System.Drawing.Size(120, 20);
            this.num_Hours.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Minuten";
            // 
            // num_Minutes
            // 
            this.num_Minutes.Location = new System.Drawing.Point(75, 33);
            this.num_Minutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.num_Minutes.Name = "num_Minutes";
            this.num_Minutes.Size = new System.Drawing.Size(120, 20);
            this.num_Minutes.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sekunden";
            // 
            // num_Seconds
            // 
            this.num_Seconds.Location = new System.Drawing.Point(75, 59);
            this.num_Seconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.num_Seconds.Name = "num_Seconds";
            this.num_Seconds.Size = new System.Drawing.Size(120, 20);
            this.num_Seconds.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Frames";
            // 
            // num_Frames
            // 
            this.num_Frames.Location = new System.Drawing.Point(75, 85);
            this.num_Frames.Name = "num_Frames";
            this.num_Frames.Size = new System.Drawing.Size(120, 20);
            this.num_Frames.TabIndex = 1;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(120, 120);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Abbrechen";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(15, 120);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // FormTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 151);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.num_Frames);
            this.Controls.Add(this.num_Seconds);
            this.Controls.Add(this.num_Minutes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.num_Hours);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormTime";
            this.Text = "Zeiten";
            this.Load += new System.EventHandler(this.FormTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Minutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Seconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Frames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_Hours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_Minutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_Seconds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_Frames;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
    }
}