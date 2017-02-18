using System;
using System.Windows.Forms;
using TournamentMatcher.GamePicking;

namespace TournamentMatcher.Client
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            SetSlidersToCurrentWeights();
        }

        private void SetSlidersToCurrentWeights()
        {
            sliderPartnerVariation.Value = Weights.Instance.PartnerVariation;
            sliderOpponentVariation.Value = Weights.Instance.OpponentVariation;
            sliderPartnerSkillDiff.Value = (int) (Weights.Instance.SkillDifferenceForPartner*10);
            sliderOpponentSkillDiff.Value = (int) (Weights.Instance.SkillDifferenceForOpponent*10);
        }

        private void btnResetDefaults_Click(object sender, EventArgs e)
        {
            Weights.Instance = new Weights();
            SetSlidersToCurrentWeights();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void slider1_ValueChanged(object sender, EventArgs e)
        {
            lblPartnerVariation.Text = "Partner Variation : " + sliderPartnerVariation.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Weights.Instance.PartnerVariation = sliderPartnerVariation.Value;
            Weights.Instance.OpponentVariation = sliderOpponentVariation.Value;
            Weights.Instance.SkillDifferenceForPartner = sliderPartnerSkillDiff.Value / 10f;
            Weights.Instance.SkillDifferenceForOpponent = sliderOpponentSkillDiff.Value / 10f;
            Close();
        }

        private void sliderOpponentVariation_ValueChanged(object sender, EventArgs e)
        {
            lblOpponentVariation.Text = "Opponent Variation : " + sliderOpponentVariation.Value;
        }

        private void sliderPartnerSkillDiff_ValueChanged(object sender, EventArgs e)
        {
            lblPartnerSkillDifference.Text = "Partner Skill Diff : " + sliderPartnerSkillDiff.Value;
        }

        private void sliderOpponentSkillDiff_ValueChanged(object sender, EventArgs e)
        {
            lblOpponentSkillDiff.Text = "Opponent Skill Diff : " + sliderOpponentSkillDiff.Value;
        }
    }
}
