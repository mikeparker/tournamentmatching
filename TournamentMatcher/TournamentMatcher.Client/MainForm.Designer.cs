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
            this.btnLoadHandicaps = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnGenerateNextRound = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvNextRound = new System.Windows.Forms.DataGridView();
            this.dgvGamesPlayed = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSittingOut = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openHandicapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRemovePlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tournamentSettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerateFinalRound = new System.Windows.Forms.Button();
            this.btnEnterScore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNextRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGamesPlayed)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddPlayers
            // 
            this.btnAddPlayers.Enabled = false;
            this.btnAddPlayers.Location = new System.Drawing.Point(139, 452);
            this.btnAddPlayers.Name = "btnAddPlayers";
            this.btnAddPlayers.Size = new System.Drawing.Size(128, 37);
            this.btnAddPlayers.TabIndex = 0;
            this.btnAddPlayers.Text = "Add/Remove Players";
            this.btnAddPlayers.UseVisualStyleBackColor = true;
            this.btnAddPlayers.Click += new System.EventHandler(this.btnAddPlayers_Click);
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Location = new System.Drawing.Point(12, 54);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.RowHeadersVisible = false;
            this.dgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayers.Size = new System.Drawing.Size(210, 329);
            this.dgvPlayers.TabIndex = 1;
            // 
            // btnLoadHandicaps
            // 
            this.btnLoadHandicaps.Location = new System.Drawing.Point(11, 452);
            this.btnLoadHandicaps.Name = "btnLoadHandicaps";
            this.btnLoadHandicaps.Size = new System.Drawing.Size(122, 37);
            this.btnLoadHandicaps.TabIndex = 2;
            this.btnLoadHandicaps.Text = "Load Handicaps File";
            this.btnLoadHandicaps.UseVisualStyleBackColor = true;
            this.btnLoadHandicaps.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "crossways-handicaps.txt";
            this.openFileDialog1.Filter = "Text files|*.txt|All files|*.*";
            // 
            // btnGenerateNextRound
            // 
            this.btnGenerateNextRound.Location = new System.Drawing.Point(712, 452);
            this.btnGenerateNextRound.Name = "btnGenerateNextRound";
            this.btnGenerateNextRound.Size = new System.Drawing.Size(128, 37);
            this.btnGenerateNextRound.TabIndex = 3;
            this.btnGenerateNextRound.Text = "Generate Next Round";
            this.btnGenerateNextRound.UseVisualStyleBackColor = true;
            this.btnGenerateNextRound.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tournament Players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(709, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Next Round";
            // 
            // dgvNextRound
            // 
            this.dgvNextRound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNextRound.Location = new System.Drawing.Point(712, 54);
            this.dgvNextRound.Name = "dgvNextRound";
            this.dgvNextRound.RowHeadersVisible = false;
            this.dgvNextRound.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvNextRound.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNextRound.Size = new System.Drawing.Size(577, 329);
            this.dgvNextRound.TabIndex = 5;
            // 
            // dgvGamesPlayed
            // 
            this.dgvGamesPlayed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGamesPlayed.Location = new System.Drawing.Point(228, 54);
            this.dgvGamesPlayed.Name = "dgvGamesPlayed";
            this.dgvGamesPlayed.RowHeadersVisible = false;
            this.dgvGamesPlayed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGamesPlayed.Size = new System.Drawing.Size(478, 329);
            this.dgvGamesPlayed.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Games Played";
            // 
            // lblSittingOut
            // 
            this.lblSittingOut.AutoSize = true;
            this.lblSittingOut.Location = new System.Drawing.Point(709, 395);
            this.lblSittingOut.Name = "lblSittingOut";
            this.lblSittingOut.Size = new System.Drawing.Size(57, 13);
            this.lblSittingOut.TabIndex = 6;
            this.lblSittingOut.Text = "Sitting out:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1301, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openHandicapsToolStripMenuItem,
            this.addRemovePlayersToolStripMenuItem,
            this.tournamentSettingsToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // openHandicapsToolStripMenuItem
            // 
            this.openHandicapsToolStripMenuItem.Name = "openHandicapsToolStripMenuItem";
            this.openHandicapsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openHandicapsToolStripMenuItem.Text = "Open Handicaps";
            this.openHandicapsToolStripMenuItem.Click += new System.EventHandler(this.openHandicapsToolStripMenuItem_Click);
            // 
            // addRemovePlayersToolStripMenuItem
            // 
            this.addRemovePlayersToolStripMenuItem.Name = "addRemovePlayersToolStripMenuItem";
            this.addRemovePlayersToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.addRemovePlayersToolStripMenuItem.Text = "Add/Remove players";
            this.addRemovePlayersToolStripMenuItem.Click += new System.EventHandler(this.addRemovePlayersToolStripMenuItem_Click);
            // 
            // tournamentSettingsToolStripMenuItem1
            // 
            this.tournamentSettingsToolStripMenuItem1.Name = "tournamentSettingsToolStripMenuItem1";
            this.tournamentSettingsToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.tournamentSettingsToolStripMenuItem1.Text = "Tournament Settings";
            this.tournamentSettingsToolStripMenuItem1.Click += new System.EventHandler(this.tournamentSettingsToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnGenerateFinalRound
            // 
            this.btnGenerateFinalRound.Location = new System.Drawing.Point(1161, 452);
            this.btnGenerateFinalRound.Name = "btnGenerateFinalRound";
            this.btnGenerateFinalRound.Size = new System.Drawing.Size(128, 37);
            this.btnGenerateFinalRound.TabIndex = 10;
            this.btnGenerateFinalRound.Text = "Generate FINAL Round";
            this.btnGenerateFinalRound.UseVisualStyleBackColor = true;
            this.btnGenerateFinalRound.Click += new System.EventHandler(this.btnGenerateFinalRound_Click);
            // 
            // btnEnterScore
            // 
            this.btnEnterScore.Location = new System.Drawing.Point(946, 395);
            this.btnEnterScore.Name = "btnEnterScore";
            this.btnEnterScore.Size = new System.Drawing.Size(128, 37);
            this.btnEnterScore.TabIndex = 11;
            this.btnEnterScore.Text = "Enter Score";
            this.btnEnterScore.UseVisualStyleBackColor = true;
            this.btnEnterScore.Click += new System.EventHandler(this.btnEnterScore_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 501);
            this.Controls.Add(this.btnEnterScore);
            this.Controls.Add(this.btnGenerateFinalRound);
            this.Controls.Add(this.lblSittingOut);
            this.Controls.Add(this.dgvGamesPlayed);
            this.Controls.Add(this.dgvNextRound);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerateNextRound);
            this.Controls.Add(this.btnLoadHandicaps);
            this.Controls.Add(this.dgvPlayers);
            this.Controls.Add(this.btnAddPlayers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Mikes Amazing Badminton Tournament Program";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNextRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGamesPlayed)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPlayers;
        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.Button btnLoadHandicaps;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnGenerateNextRound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvNextRound;
        private System.Windows.Forms.DataGridView dgvGamesPlayed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSittingOut;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem openHandicapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRemovePlayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tournamentSettingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnGenerateFinalRound;
        private System.Windows.Forms.Button btnEnterScore;
    }
}

