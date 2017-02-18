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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNextRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGamesPlayed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPlayers
            // 
            this.btnAddPlayers.Enabled = false;
            this.btnAddPlayers.Location = new System.Drawing.Point(185, 570);
            this.btnAddPlayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddPlayers.Name = "btnAddPlayers";
            this.btnAddPlayers.Size = new System.Drawing.Size(171, 32);
            this.btnAddPlayers.TabIndex = 0;
            this.btnAddPlayers.Text = "Add/Remove Players";
            this.btnAddPlayers.UseVisualStyleBackColor = true;
            this.btnAddPlayers.Click += new System.EventHandler(this.btnAddPlayers_Click);
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Location = new System.Drawing.Point(16, 57);
            this.dgvPlayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.RowHeadersVisible = false;
            this.dgvPlayers.Size = new System.Drawing.Size(280, 405);
            this.dgvPlayers.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 570);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 32);
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
            this.button2.Location = new System.Drawing.Point(683, 570);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "Generate Next Round";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(680, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Next Round";
            // 
            // dgvNextRound
            // 
            this.dgvNextRound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNextRound.Location = new System.Drawing.Point(683, 57);
            this.dgvNextRound.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvNextRound.Name = "dgvNextRound";
            this.dgvNextRound.RowHeadersVisible = false;
            this.dgvNextRound.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvNextRound.Size = new System.Drawing.Size(464, 405);
            this.dgvNextRound.TabIndex = 5;
            // 
            // dgvGamesPlayed
            // 
            this.dgvGamesPlayed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGamesPlayed.Location = new System.Drawing.Point(304, 57);
            this.dgvGamesPlayed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGamesPlayed.Name = "dgvGamesPlayed";
            this.dgvGamesPlayed.RowHeadersVisible = false;
            this.dgvGamesPlayed.Size = new System.Drawing.Size(371, 405);
            this.dgvGamesPlayed.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Games Played";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 617);
            this.Controls.Add(this.dgvGamesPlayed);
            this.Controls.Add(this.dgvNextRound);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPlayers);
            this.Controls.Add(this.btnAddPlayers);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    }
}

