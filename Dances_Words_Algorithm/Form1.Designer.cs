namespace Dances_Words_Algorithm
{
    partial class frmMain
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblPhase1 = new System.Windows.Forms.Label();
            this.lblPhase2 = new System.Windows.Forms.Label();
            this.lblPhase3 = new System.Windows.Forms.Label();
            this.lblPhase4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdStart = new System.Windows.Forms.Button();
            this.lblPhase5 = new System.Windows.Forms.Label();
            this.lblPhase6 = new System.Windows.Forms.Label();
            this.lblPhase7 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPhase8 = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 193);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(392, 23);
            this.progressBar.TabIndex = 0;
            // 
            // lblPhase1
            // 
            this.lblPhase1.AutoSize = true;
            this.lblPhase1.Enabled = false;
            this.lblPhase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPhase1.Location = new System.Drawing.Point(12, 50);
            this.lblPhase1.Name = "lblPhase1";
            this.lblPhase1.Size = new System.Drawing.Size(148, 17);
            this.lblPhase1.TabIndex = 1;
            this.lblPhase1.Text = "1. Get Data From CSV";
            // 
            // lblPhase2
            // 
            this.lblPhase2.AutoSize = true;
            this.lblPhase2.Enabled = false;
            this.lblPhase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPhase2.Location = new System.Drawing.Point(12, 67);
            this.lblPhase2.Name = "lblPhase2";
            this.lblPhase2.Size = new System.Drawing.Size(267, 17);
            this.lblPhase2.TabIndex = 2;
            this.lblPhase2.Text = "2. Differentiate Test Set and Training Set";
            // 
            // lblPhase3
            // 
            this.lblPhase3.AutoSize = true;
            this.lblPhase3.Enabled = false;
            this.lblPhase3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPhase3.Location = new System.Drawing.Point(12, 84);
            this.lblPhase3.Name = "lblPhase3";
            this.lblPhase3.Size = new System.Drawing.Size(111, 17);
            this.lblPhase3.TabIndex = 3;
            this.lblPhase3.Text = "3. Get All Words";
            // 
            // lblPhase4
            // 
            this.lblPhase4.AutoSize = true;
            this.lblPhase4.Enabled = false;
            this.lblPhase4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPhase4.Location = new System.Drawing.Point(12, 98);
            this.lblPhase4.Name = "lblPhase4";
            this.lblPhase4.Size = new System.Drawing.Size(189, 17);
            this.lblPhase4.TabIndex = 4;
            this.lblPhase4.Text = "4. Get Term Frequency Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dance Words Algorithm Manager";
            // 
            // cmdStart
            // 
            this.cmdStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmdStart.Location = new System.Drawing.Point(104, 231);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(217, 33);
            this.cmdStart.TabIndex = 6;
            this.cmdStart.Text = "Start Algorithm";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // lblPhase5
            // 
            this.lblPhase5.AutoSize = true;
            this.lblPhase5.Enabled = false;
            this.lblPhase5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPhase5.Location = new System.Drawing.Point(12, 115);
            this.lblPhase5.Name = "lblPhase5";
            this.lblPhase5.Size = new System.Drawing.Size(187, 17);
            this.lblPhase5.TabIndex = 7;
            this.lblPhase5.Text = "5. Create Dictionary (Terms)";
            // 
            // lblPhase6
            // 
            this.lblPhase6.AutoSize = true;
            this.lblPhase6.Enabled = false;
            this.lblPhase6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPhase6.Location = new System.Drawing.Point(12, 132);
            this.lblPhase6.Name = "lblPhase6";
            this.lblPhase6.Size = new System.Drawing.Size(158, 17);
            this.lblPhase6.TabIndex = 8;
            this.lblPhase6.Text = "6. Create Features Sets";
            // 
            // lblPhase7
            // 
            this.lblPhase7.AutoSize = true;
            this.lblPhase7.Enabled = false;
            this.lblPhase7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPhase7.Location = new System.Drawing.Point(12, 149);
            this.lblPhase7.Name = "lblPhase7";
            this.lblPhase7.Size = new System.Drawing.Size(249, 17);
            this.lblPhase7.TabIndex = 9;
            this.lblPhase7.Text = "7. Create Words DataTable (Columns)";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(13, 250);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Error Counter:";
            // 
            // lblPhase8
            // 
            this.lblPhase8.AutoSize = true;
            this.lblPhase8.Enabled = false;
            this.lblPhase8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPhase8.Location = new System.Drawing.Point(12, 166);
            this.lblPhase8.Name = "lblPhase8";
            this.lblPhase8.Size = new System.Drawing.Size(234, 17);
            this.lblPhase8.TabIndex = 12;
            this.lblPhase8.Text = "8. Create Matrix DataTable (TF-IDF)";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(355, 244);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(0, 13);
            this.lblTemp.TabIndex = 13;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 269);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.lblPhase8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblPhase7);
            this.Controls.Add(this.lblPhase6);
            this.Controls.Add(this.lblPhase5);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPhase4);
            this.Controls.Add(this.lblPhase3);
            this.Controls.Add(this.lblPhase2);
            this.Controls.Add(this.lblPhase1);
            this.Controls.Add(this.progressBar);
            this.Name = "frmMain";
            this.Text = "Dance Words Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblPhase1;
        private System.Windows.Forms.Label lblPhase2;
        private System.Windows.Forms.Label lblPhase3;
        private System.Windows.Forms.Label lblPhase4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Label lblPhase5;
        private System.Windows.Forms.Label lblPhase6;
        private System.Windows.Forms.Label lblPhase7;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPhase8;
        private System.Windows.Forms.Label lblTemp;
    }
}

