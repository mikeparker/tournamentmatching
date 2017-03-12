using System;
using System.Windows.Forms;
using TournamentMatcher.GamePicking;

namespace TournamentMatcher.Client
{
    public partial class EnterScoreForm : Form
    {
        private readonly Match match;
        private readonly DataGridView dgvNextRound;

        public EnterScoreForm(Match match, DataGridView dgvNextRound)
        {
            InitializeComponent();

            this.match = match;
            this.dgvNextRound = dgvNextRound;
            this.lblTeam1.Text = match.Team1.ToString();
            this.lblTeam2.Text = match.Team2.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Add score to match
            var team1score = int.Parse((string)cbTeam1Score.SelectedItem);
            var team2score = int.Parse((string)cbTeam2Score.SelectedItem);

            if (team1score != 21 && team2score != 21)
            {
                MessageBox.Show("One team must have scored 21", "Error: No-one scored 21");
                return;
            }

            if (team1score == 21 && team2score == 21)
            {
                MessageBox.Show("Both teams cannot score 21", "Error: Both teams scored 21");
                return;
            }

            match.SetScore(team1score, team2score);
            dgvNextRound.Refresh();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
