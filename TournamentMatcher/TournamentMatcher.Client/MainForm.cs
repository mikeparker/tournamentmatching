using System;
using System.Linq;
using System.Windows.Forms;
using TournamentMatcher.GamePicking;

namespace TournamentMatcher.Client
{
    public partial class MainForm : Form
    {
        private readonly TournamentClientModel tournamentClientModel;

        public MainForm()
        {
            InitializeComponent();
            this.tournamentClientModel = new TournamentClientModel();

            dgvPlayers.DataSource = tournamentClientModel.PlayersBindingList;
            dgvPlayers.Columns[2].Visible = false;
            dgvPlayers.Columns[3].Visible = false;
            dgvPlayers.Columns[4].Visible = false;
        }

        private void btnAddPlayers_Click(object sender, EventArgs e)
        {
            AddRemovePlayersForm x = new AddRemovePlayersForm();
            x.SetModel(tournamentClientModel);
            x.ShowDialog(this);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string filepath = openFileDialog1.FileName;
                tournamentClientModel.LoadPlayersFromFile(filepath);
                var count = tournamentClientModel.AllPossiblePlayers.Count;
                if (count == 0)
                {
                    MessageBox.Show("Could not load players, please check file format is one player per line, Name followed by COMMA followed by handicap, e.g. Mike Parker, -13",
                        "Error loading players", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Loaded " + count + " players.", "Loaded players", MessageBoxButtons.OK);
                    btnAddPlayers.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!tournamentClientModel.PlayersBindingList.Any())
            {
                MessageBox.Show("Please select players before trying to generate a round.");
                return;
            }

            var nextRound = SuggestedTournamentRound.CreateIntelligentRound(tournamentClientModel.PlayersBindingList.ToList());
            var nextRoundDescriptions = nextRound.SuggestedMatches.Select(m => new MatchModel(m.ToString())).ToList();
            dgvNextRound.DataSource = nextRoundDescriptions;
        }
    }

    public class MatchModel
    {
        public string Description;

        public MatchModel(string description)
        {
            this.Description = description;
        }
    }
}
