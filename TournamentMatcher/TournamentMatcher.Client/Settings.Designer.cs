namespace TournamentMatcher.Client
{
    partial class Settings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.sliderPartnerVariation = new System.Windows.Forms.TrackBar();
            this.lblPartnerVariation = new System.Windows.Forms.Label();
            this.btnResetDefaults = new System.Windows.Forms.Button();
            this.lblOpponentVariation = new System.Windows.Forms.Label();
            this.sliderOpponentVariation = new System.Windows.Forms.TrackBar();
            this.lblPartnerSkillDifference = new System.Windows.Forms.Label();
            this.sliderPartnerSkillDiff = new System.Windows.Forms.TrackBar();
            this.lblOpponentSkillDiff = new System.Windows.Forms.Label();
            this.sliderOpponentSkillDiff = new System.Windows.Forms.TrackBar();
            this.btnGenerateExampleTournament = new System.Windows.Forms.Button();
            this.lblBalancedTeams = new System.Windows.Forms.Label();
            this.sliderBalancedTeams = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPartnerVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpponentVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPartnerSkillDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpponentSkillDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBalancedTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(547, 523);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(627, 523);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // sliderPartnerVariation
            // 
            this.sliderPartnerVariation.LargeChange = 20;
            this.sliderPartnerVariation.Location = new System.Drawing.Point(187, 55);
            this.sliderPartnerVariation.Margin = new System.Windows.Forms.Padding(2);
            this.sliderPartnerVariation.Maximum = 200;
            this.sliderPartnerVariation.Name = "sliderPartnerVariation";
            this.sliderPartnerVariation.Size = new System.Drawing.Size(377, 45);
            this.sliderPartnerVariation.SmallChange = 10;
            this.sliderPartnerVariation.TabIndex = 2;
            this.sliderPartnerVariation.TickFrequency = 20;
            this.sliderPartnerVariation.ValueChanged += new System.EventHandler(this.slider1_ValueChanged);
            // 
            // lblPartnerVariation
            // 
            this.lblPartnerVariation.AutoSize = true;
            this.lblPartnerVariation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartnerVariation.Location = new System.Drawing.Point(18, 55);
            this.lblPartnerVariation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPartnerVariation.Name = "lblPartnerVariation";
            this.lblPartnerVariation.Size = new System.Drawing.Size(102, 13);
            this.lblPartnerVariation.TabIndex = 3;
            this.lblPartnerVariation.Text = "Partner Variation";
            // 
            // btnResetDefaults
            // 
            this.btnResetDefaults.Location = new System.Drawing.Point(250, 523);
            this.btnResetDefaults.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetDefaults.Name = "btnResetDefaults";
            this.btnResetDefaults.Size = new System.Drawing.Size(95, 32);
            this.btnResetDefaults.TabIndex = 4;
            this.btnResetDefaults.Text = "Reset to defaults";
            this.btnResetDefaults.UseVisualStyleBackColor = true;
            this.btnResetDefaults.Click += new System.EventHandler(this.btnResetDefaults_Click);
            // 
            // lblOpponentVariation
            // 
            this.lblOpponentVariation.AutoSize = true;
            this.lblOpponentVariation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpponentVariation.Location = new System.Drawing.Point(20, 142);
            this.lblOpponentVariation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOpponentVariation.Name = "lblOpponentVariation";
            this.lblOpponentVariation.Size = new System.Drawing.Size(116, 13);
            this.lblOpponentVariation.TabIndex = 6;
            this.lblOpponentVariation.Text = "Opponent Variation";
            // 
            // sliderOpponentVariation
            // 
            this.sliderOpponentVariation.LargeChange = 20;
            this.sliderOpponentVariation.Location = new System.Drawing.Point(189, 142);
            this.sliderOpponentVariation.Margin = new System.Windows.Forms.Padding(2);
            this.sliderOpponentVariation.Maximum = 200;
            this.sliderOpponentVariation.Name = "sliderOpponentVariation";
            this.sliderOpponentVariation.Size = new System.Drawing.Size(377, 45);
            this.sliderOpponentVariation.SmallChange = 20;
            this.sliderOpponentVariation.TabIndex = 5;
            this.sliderOpponentVariation.TickFrequency = 20;
            this.sliderOpponentVariation.ValueChanged += new System.EventHandler(this.sliderOpponentVariation_ValueChanged);
            // 
            // lblPartnerSkillDifference
            // 
            this.lblPartnerSkillDifference.AutoSize = true;
            this.lblPartnerSkillDifference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartnerSkillDifference.Location = new System.Drawing.Point(19, 226);
            this.lblPartnerSkillDifference.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPartnerSkillDifference.Name = "lblPartnerSkillDifference";
            this.lblPartnerSkillDifference.Size = new System.Drawing.Size(100, 13);
            this.lblPartnerSkillDifference.TabIndex = 8;
            this.lblPartnerSkillDifference.Text = "Partner Skill Diff";
            // 
            // sliderPartnerSkillDiff
            // 
            this.sliderPartnerSkillDiff.Location = new System.Drawing.Point(188, 226);
            this.sliderPartnerSkillDiff.Margin = new System.Windows.Forms.Padding(2);
            this.sliderPartnerSkillDiff.Maximum = 50;
            this.sliderPartnerSkillDiff.Name = "sliderPartnerSkillDiff";
            this.sliderPartnerSkillDiff.Size = new System.Drawing.Size(377, 45);
            this.sliderPartnerSkillDiff.TabIndex = 7;
            this.sliderPartnerSkillDiff.ValueChanged += new System.EventHandler(this.sliderPartnerSkillDiff_ValueChanged);
            // 
            // lblOpponentSkillDiff
            // 
            this.lblOpponentSkillDiff.AutoSize = true;
            this.lblOpponentSkillDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpponentSkillDiff.Location = new System.Drawing.Point(19, 311);
            this.lblOpponentSkillDiff.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOpponentSkillDiff.Name = "lblOpponentSkillDiff";
            this.lblOpponentSkillDiff.Size = new System.Drawing.Size(114, 13);
            this.lblOpponentSkillDiff.TabIndex = 10;
            this.lblOpponentSkillDiff.Text = "Opponent Skill Diff";
            // 
            // sliderOpponentSkillDiff
            // 
            this.sliderOpponentSkillDiff.LargeChange = 1;
            this.sliderOpponentSkillDiff.Location = new System.Drawing.Point(188, 311);
            this.sliderOpponentSkillDiff.Margin = new System.Windows.Forms.Padding(2);
            this.sliderOpponentSkillDiff.Maximum = 50;
            this.sliderOpponentSkillDiff.Name = "sliderOpponentSkillDiff";
            this.sliderOpponentSkillDiff.Size = new System.Drawing.Size(377, 45);
            this.sliderOpponentSkillDiff.TabIndex = 9;
            this.sliderOpponentSkillDiff.ValueChanged += new System.EventHandler(this.sliderOpponentSkillDiff_ValueChanged);
            // 
            // btnGenerateExampleTournament
            // 
            this.btnGenerateExampleTournament.Location = new System.Drawing.Point(599, 223);
            this.btnGenerateExampleTournament.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerateExampleTournament.Name = "btnGenerateExampleTournament";
            this.btnGenerateExampleTournament.Size = new System.Drawing.Size(104, 101);
            this.btnGenerateExampleTournament.TabIndex = 11;
            this.btnGenerateExampleTournament.Text = "Generate Example Tournament";
            this.btnGenerateExampleTournament.UseVisualStyleBackColor = true;
            this.btnGenerateExampleTournament.Click += new System.EventHandler(this.btnGenerateExampleTournament_Click);
            // 
            // lblBalancedTeams
            // 
            this.lblBalancedTeams.AutoSize = true;
            this.lblBalancedTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalancedTeams.Location = new System.Drawing.Point(18, 400);
            this.lblBalancedTeams.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBalancedTeams.Name = "lblBalancedTeams";
            this.lblBalancedTeams.Size = new System.Drawing.Size(101, 13);
            this.lblBalancedTeams.TabIndex = 13;
            this.lblBalancedTeams.Text = "Balanced Teams";
            this.lblBalancedTeams.Click += new System.EventHandler(this.lblBalancedTeams_Click);
            // 
            // sliderBalancedTeams
            // 
            this.sliderBalancedTeams.LargeChange = 1;
            this.sliderBalancedTeams.Location = new System.Drawing.Point(187, 400);
            this.sliderBalancedTeams.Margin = new System.Windows.Forms.Padding(2);
            this.sliderBalancedTeams.Maximum = 200;
            this.sliderBalancedTeams.Name = "sliderBalancedTeams";
            this.sliderBalancedTeams.Size = new System.Drawing.Size(377, 45);
            this.sliderBalancedTeams.TabIndex = 12;
            this.sliderBalancedTeams.ValueChanged += new System.EventHandler(this.sliderBalancedTeams_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "<- Repeated a few times if it makes better games ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 258);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "<- Any skill level, i dont mind";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "My partners should be:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(452, 87);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Different every time ->";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 174);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "My opponents should be:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(454, 174);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Different every time ->";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 174);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "<- Repeated a few times if it makes better games ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 258);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "My partners should be:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(454, 258);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Similar to me in skill ->";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 343);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "My opponents should be:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(454, 343);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Similar to me in skill ->";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(197, 343);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "<- Any skill level, i dont mind";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 432);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "The starting handicap should be:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(197, 432);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "<- Doesnt matter";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(373, 432);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(193, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "As small as possible (balanced teams)->";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 566);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBalancedTeams);
            this.Controls.Add(this.sliderBalancedTeams);
            this.Controls.Add(this.btnGenerateExampleTournament);
            this.Controls.Add(this.lblOpponentSkillDiff);
            this.Controls.Add(this.sliderOpponentSkillDiff);
            this.Controls.Add(this.lblPartnerSkillDifference);
            this.Controls.Add(this.sliderPartnerSkillDiff);
            this.Controls.Add(this.lblOpponentVariation);
            this.Controls.Add(this.sliderOpponentVariation);
            this.Controls.Add(this.btnResetDefaults);
            this.Controls.Add(this.lblPartnerVariation);
            this.Controls.Add(this.sliderPartnerVariation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sliderPartnerVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpponentVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPartnerSkillDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpponentSkillDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBalancedTeams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TrackBar sliderPartnerVariation;
        private System.Windows.Forms.Label lblPartnerVariation;
        private System.Windows.Forms.Button btnResetDefaults;
        private System.Windows.Forms.Label lblOpponentVariation;
        private System.Windows.Forms.TrackBar sliderOpponentVariation;
        private System.Windows.Forms.Label lblPartnerSkillDifference;
        private System.Windows.Forms.TrackBar sliderPartnerSkillDiff;
        private System.Windows.Forms.Label lblOpponentSkillDiff;
        private System.Windows.Forms.TrackBar sliderOpponentSkillDiff;
        private System.Windows.Forms.Button btnGenerateExampleTournament;
        private System.Windows.Forms.Label lblBalancedTeams;
        private System.Windows.Forms.TrackBar sliderBalancedTeams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}