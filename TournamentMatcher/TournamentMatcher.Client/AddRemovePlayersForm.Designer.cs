namespace TournamentMatcher.Client
{
    partial class AddRemovePlayersForm
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
            this.dgvPlayersNotPlaying = new System.Windows.Forms.DataGridView();
            this.dgvPlayersPlaying = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayersNotPlaying)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayersPlaying)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlayersNotPlaying
            // 
            this.dgvPlayersNotPlaying.AllowUserToAddRows = false;
            this.dgvPlayersNotPlaying.AllowUserToDeleteRows = false;
            this.dgvPlayersNotPlaying.AllowUserToOrderColumns = true;
            this.dgvPlayersNotPlaying.AllowUserToResizeRows = false;
            this.dgvPlayersNotPlaying.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayersNotPlaying.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPlayersNotPlaying.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvPlayersNotPlaying.Location = new System.Drawing.Point(12, 25);
            this.dgvPlayersNotPlaying.Name = "dgvPlayersNotPlaying";
            this.dgvPlayersNotPlaying.ReadOnly = true;
            this.dgvPlayersNotPlaying.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayersNotPlaying.Size = new System.Drawing.Size(306, 349);
            this.dgvPlayersNotPlaying.TabIndex = 0;
            // 
            // dgvPlayersPlaying
            // 
            this.dgvPlayersPlaying.AllowUserToAddRows = false;
            this.dgvPlayersPlaying.AllowUserToDeleteRows = false;
            this.dgvPlayersPlaying.AllowUserToResizeRows = false;
            this.dgvPlayersPlaying.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayersPlaying.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPlayersPlaying.Location = new System.Drawing.Point(405, 25);
            this.dgvPlayersPlaying.Name = "dgvPlayersPlaying";
            this.dgvPlayersPlaying.ReadOnly = true;
            this.dgvPlayersPlaying.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayersPlaying.Size = new System.Drawing.Size(326, 349);
            this.dgvPlayersPlaying.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add >>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(324, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "<< Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(656, 380);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 34);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Available players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Players in tournament";
            // 
            // AddRemovePlayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 425);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPlayersPlaying);
            this.Controls.Add(this.dgvPlayersNotPlaying);
            this.Name = "AddRemovePlayersForm";
            this.Text = "Add players to tournament";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayersNotPlaying)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayersPlaying)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlayersNotPlaying;
        private System.Windows.Forms.DataGridView dgvPlayersPlaying;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}