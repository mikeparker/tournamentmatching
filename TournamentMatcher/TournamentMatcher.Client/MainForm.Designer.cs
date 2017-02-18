namespace TournamentMatcher.Client
{
    partial class MainForm
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
            this.btnAddPlayers = new System.Windows.Forms.Button();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvNextRound = new System.Windows.Forms.DataGridView();
            this.dgvGamesPlayed = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSittingOut = new System.Windows.Forms.Label();
            this.btnEnterScore = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNextRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGamesPlayed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPlayers
            // 
            this.btnAddPlayers.Enabled = false;
            this.btnAddPlayers.Location = new System.Drawing.Point(139, 463);
            this.btnAddPlayers.Name = "btnAddPlayers";
            this.btnAddPlayers.Size = new System.Drawing.Size(128, 26);
            this.btnAddPlayers.TabIndex = 0;
            this.btnAddPlayers.Text = "Add/Remove Players";
            this.btnAddPlayers.UseVisualStyleBackColor = true;
            this.btnAddPlayers.Click += new System.EventHandler(this.btnAddPlayers_Click);
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Location = new System.Drawing.Point(12, 46);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.RowHeadersVisible = false;
            this.dgvPlayers.Size = new System.Drawing.Size(210, 329);
            this.dgvPlayers.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load Handicaps File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "crossways-handicaps.txt";
            this.openFileDialog1.Filter = "Text files|*.txt|All files|*.*";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(512, 463);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "Generate Next Round";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tournament Players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Next Round";
            // 
            // dgvNextRound
            // 
            this.dgvNextRound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNextRound.Location = new System.Drawing.Point(512, 46);
            this.dgvNextRound.Name = "dgvNextRound";
            this.dgvNextRound.RowHeadersVisible = false;
            this.dgvNextRound.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvNextRound.Size = new System.Drawing.Size(348, 329);
            this.dgvNextRound.TabIndex = 5;
            // 
            // dgvGamesPlayed
            // 
            this.dgvGamesPlayed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGamesPlayed.Location = new System.Drawing.Point(228, 46);
            this.dgvGamesPlayed.Name = "dgvGamesPlayed";
            this.dgvGamesPlayed.RowHeadersVisible = false;
            this.dgvGamesPlayed.Size = new System.Drawing.Size(278, 329);
            this.dgvGamesPlayed.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Games Played";
            // 
            // lblSittingOut
            // 
            this.lblSittingOut.AutoSize = true;
            this.lblSittingOut.Location = new System.Drawing.Point(510, 390);
            this.lblSittingOut.Name = "lblSittingOut";
            this.lblSittingOut.Size = new System.Drawing.Size(0, 13);
            this.lblSittingOut.TabIndex = 6;
            // 
            // btnEnterScore
            // 
            this.btnEnterScore.Location = new System.Drawing.Point(228, 390);
            this.btnEnterScore.Name = "btnEnterScore";
            this.btnEnterScore.Size = new System.Drawing.Size(128, 26);
            this.btnEnterScore.TabIndex = 7;
            this.btnEnterScore.Text = "Enter Score";
            this.btnEnterScore.UseVisualStyleBackColor = true;
            this.btnEnterScore.Click += new System.EventHandler(this.btnEnterScore_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(730, 450);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 39);
            this.button3.TabIndex = 8;
            this.button3.Text = "Change Tournament Settings";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 501);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnEnterScore);
            this.Controls.Add(this.lblSittingOut);
            this.Controls.Add(this.dgvGamesPlayed);
            this.Controls.Add(this.dgvNextRound);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPlayers);
            this.Controls.Add(this.btnAddPlayers);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNextRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGamesPlayed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPlayers;
        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvNextRound;
        private System.Windows.Forms.DataGridView dgvGamesPlayed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSittingOut;
        private System.Windows.Forms.Button btnEnterScore;
        private System.Windows.Forms.Button button3;
    }
}

