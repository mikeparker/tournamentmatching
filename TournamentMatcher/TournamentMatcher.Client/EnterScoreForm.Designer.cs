namespace TournamentMatcher.Client
{
    partial class EnterScoreForm
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
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.cbTeam1Score = new System.Windows.Forms.ComboBox();
            this.cbTeam2Score = new System.Windows.Forms.ComboBox();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTeam1
            // 
            this.lblTeam1.AutoSize = true;
            this.lblTeam1.Location = new System.Drawing.Point(80, 32);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(43, 13);
            this.lblTeam1.TabIndex = 0;
            this.lblTeam1.Text = "Team1:";
            // 
            // cbTeam1Score
            // 
            this.cbTeam1Score.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeam1Score.FormattingEnabled = true;
            this.cbTeam1Score.Items.AddRange(new object[] {
            "21",
            "20",
            "19",
            "18",
            "17",
            "16",
            "15",
            "14",
            "13",
            "12",
            "11",
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0"});
            this.cbTeam1Score.Location = new System.Drawing.Point(12, 29);
            this.cbTeam1Score.Name = "cbTeam1Score";
            this.cbTeam1Score.Size = new System.Drawing.Size(62, 21);
            this.cbTeam1Score.TabIndex = 1;
            // 
            // cbTeam2Score
            // 
            this.cbTeam2Score.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeam2Score.FormattingEnabled = true;
            this.cbTeam2Score.Items.AddRange(new object[] {
            "21",
            "20",
            "19",
            "18",
            "17",
            "16",
            "15",
            "14",
            "13",
            "12",
            "11",
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0"});
            this.cbTeam2Score.Location = new System.Drawing.Point(12, 65);
            this.cbTeam2Score.Name = "cbTeam2Score";
            this.cbTeam2Score.Size = new System.Drawing.Size(62, 21);
            this.cbTeam2Score.TabIndex = 3;
            // 
            // lblTeam2
            // 
            this.lblTeam2.AutoSize = true;
            this.lblTeam2.Location = new System.Drawing.Point(80, 68);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(43, 13);
            this.lblTeam2.TabIndex = 2;
            this.lblTeam2.Text = "Team2:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(254, 172);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(88, 36);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(348, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EnterScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 220);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbTeam2Score);
            this.Controls.Add(this.lblTeam2);
            this.Controls.Add(this.cbTeam1Score);
            this.Controls.Add(this.lblTeam1);
            this.Name = "EnterScoreForm";
            this.Text = "EnterScoreForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTeam1;
        private System.Windows.Forms.ComboBox cbTeam1Score;
        private System.Windows.Forms.ComboBox cbTeam2Score;
        private System.Windows.Forms.Label lblTeam2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}