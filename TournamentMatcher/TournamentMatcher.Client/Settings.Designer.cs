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
            ((System.ComponentModel.ISupportInitialize)(this.sliderPartnerVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpponentVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPartnerSkillDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpponentSkillDiff)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(453, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(560, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // sliderPartnerVariation
            // 
            this.sliderPartnerVariation.LargeChange = 20;
            this.sliderPartnerVariation.Location = new System.Drawing.Point(216, 68);
            this.sliderPartnerVariation.Maximum = 200;
            this.sliderPartnerVariation.Name = "sliderPartnerVariation";
            this.sliderPartnerVariation.Size = new System.Drawing.Size(242, 56);
            this.sliderPartnerVariation.SmallChange = 10;
            this.sliderPartnerVariation.TabIndex = 2;
            this.sliderPartnerVariation.TickFrequency = 20;
            this.sliderPartnerVariation.ValueChanged += new System.EventHandler(this.slider1_ValueChanged);
            // 
            // lblPartnerVariation
            // 
            this.lblPartnerVariation.AutoSize = true;
            this.lblPartnerVariation.Location = new System.Drawing.Point(24, 68);
            this.lblPartnerVariation.Name = "lblPartnerVariation";
            this.lblPartnerVariation.Size = new System.Drawing.Size(115, 17);
            this.lblPartnerVariation.TabIndex = 3;
            this.lblPartnerVariation.Text = "Partner Variation";
            // 
            // btnResetDefaults
            // 
            this.btnResetDefaults.Location = new System.Drawing.Point(12, 370);
            this.btnResetDefaults.Name = "btnResetDefaults";
            this.btnResetDefaults.Size = new System.Drawing.Size(127, 40);
            this.btnResetDefaults.TabIndex = 4;
            this.btnResetDefaults.Text = "Reset to defaults";
            this.btnResetDefaults.UseVisualStyleBackColor = true;
            this.btnResetDefaults.Click += new System.EventHandler(this.btnResetDefaults_Click);
            // 
            // lblOpponentVariation
            // 
            this.lblOpponentVariation.AutoSize = true;
            this.lblOpponentVariation.Location = new System.Drawing.Point(24, 121);
            this.lblOpponentVariation.Name = "lblOpponentVariation";
            this.lblOpponentVariation.Size = new System.Drawing.Size(131, 17);
            this.lblOpponentVariation.TabIndex = 6;
            this.lblOpponentVariation.Text = "Opponent Variation";
            // 
            // sliderOpponentVariation
            // 
            this.sliderOpponentVariation.LargeChange = 20;
            this.sliderOpponentVariation.Location = new System.Drawing.Point(216, 121);
            this.sliderOpponentVariation.Maximum = 200;
            this.sliderOpponentVariation.Name = "sliderOpponentVariation";
            this.sliderOpponentVariation.Size = new System.Drawing.Size(242, 56);
            this.sliderOpponentVariation.SmallChange = 20;
            this.sliderOpponentVariation.TabIndex = 5;
            this.sliderOpponentVariation.TickFrequency = 20;
            this.sliderOpponentVariation.ValueChanged += new System.EventHandler(this.sliderOpponentVariation_ValueChanged);
            // 
            // lblPartnerSkillDifference
            // 
            this.lblPartnerSkillDifference.AutoSize = true;
            this.lblPartnerSkillDifference.Location = new System.Drawing.Point(24, 183);
            this.lblPartnerSkillDifference.Name = "lblPartnerSkillDifference";
            this.lblPartnerSkillDifference.Size = new System.Drawing.Size(109, 17);
            this.lblPartnerSkillDifference.TabIndex = 8;
            this.lblPartnerSkillDifference.Text = "Partner Skill Diff";
            // 
            // sliderPartnerSkillDiff
            // 
            this.sliderPartnerSkillDiff.Location = new System.Drawing.Point(216, 183);
            this.sliderPartnerSkillDiff.Maximum = 50;
            this.sliderPartnerSkillDiff.Name = "sliderPartnerSkillDiff";
            this.sliderPartnerSkillDiff.Size = new System.Drawing.Size(242, 56);
            this.sliderPartnerSkillDiff.TabIndex = 7;
            this.sliderPartnerSkillDiff.ValueChanged += new System.EventHandler(this.sliderPartnerSkillDiff_ValueChanged);
            // 
            // lblOpponentSkillDiff
            // 
            this.lblOpponentSkillDiff.AutoSize = true;
            this.lblOpponentSkillDiff.Location = new System.Drawing.Point(24, 245);
            this.lblOpponentSkillDiff.Name = "lblOpponentSkillDiff";
            this.lblOpponentSkillDiff.Size = new System.Drawing.Size(125, 17);
            this.lblOpponentSkillDiff.TabIndex = 10;
            this.lblOpponentSkillDiff.Text = "Opponent Skill Diff";
            // 
            // sliderOpponentSkillDiff
            // 
            this.sliderOpponentSkillDiff.LargeChange = 1;
            this.sliderOpponentSkillDiff.Location = new System.Drawing.Point(216, 245);
            this.sliderOpponentSkillDiff.Maximum = 50;
            this.sliderOpponentSkillDiff.Name = "sliderOpponentSkillDiff";
            this.sliderOpponentSkillDiff.Size = new System.Drawing.Size(242, 56);
            this.sliderOpponentSkillDiff.TabIndex = 9;
            this.sliderOpponentSkillDiff.ValueChanged += new System.EventHandler(this.sliderOpponentSkillDiff_ValueChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 422);
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
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.sliderPartnerVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpponentVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPartnerSkillDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpponentSkillDiff)).EndInit();
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
    }
}