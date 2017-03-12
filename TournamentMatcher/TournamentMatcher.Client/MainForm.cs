using System;
using System.Linq;
using System.Windows.Forms;

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
            OpenAddPlayersForm();
        }

        private void OpenAddPlayersForm()
        {
            if (tournamentClientModel.AllPossiblePlayers == null)
            {
                return;
            }
            var x = new AddRemovePlayersForm();
            x.SetModel(this.tournamentClientModel);
            x.ShowDialog(this);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenHandicapsFile();
        }

        private void OpenHandicapsFile()
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            string filepath = this.openFileDialog1.FileName;
            this.tournamentClientModel.LoadPlayersFromFile(filepath);
            var count = this.tournamentClientModel.AllPossiblePlayers.Count;
            if (count == 0)
            {
                MessageBox.Show("Could not load players, please check file format is one player per line, Name followed by COMMA followed by handicap, e.g. Mike Parker, -13",
                    "Error loading players", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Loaded " + count + " players.", "Loaded players", MessageBoxButtons.OK);
                this.btnAddPlayers.Enabled = true;
                OpenAddPlayersForm();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!tournamentClientModel.PlayersBindingList.Any())
            {
                MessageBox.Show("Please select players before trying to generate a round.");
                return;
            }

            var dialogResult = MessageBox.Show(this, "Finalise round and create the next one?", "Finalise Round?", MessageBoxButtons.OKCancel );
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            tournamentClientModel.FinaliseCurrentRoundAndGenerateNext();
            RefreshUI();
        }

        private void RefreshUI()
        {
            this.dgvNextRound.DataSource = this.tournamentClientModel.CurrentRoundBindingList;
            this.dgvGamesPlayed.DataSource = this.tournamentClientModel.PreviousRoundsBindingList;
            this.label2.Text = "Next Round (" + (this.tournamentClientModel.PreviousRounds.Count + 1) + ")";
            this.lblSittingOut.Text = "Sitting out:" + string.Join(", ", this.tournamentClientModel.CurrentRound.PlayersSittingOut.Select(p => p.Name));
            this.dgvGamesPlayed.SetNotColumnSortable();
            this.dgvNextRound.SetNotColumnSortable();
            this.dgvGamesPlayed.SetColumnEditable(2);
        }

        private void openHandicapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHandicapsFile();
        }

        private void addRemovePlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAddPlayersForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tournamentSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var x = new Settings(this.tournamentClientModel.PlayersInTournament);
            x.ShowDialog(this);
        }

        private void btnGenerateFinalRound_Click(object sender, EventArgs e)
        {
            if (!tournamentClientModel.PlayersBindingList.Any())
            {
                MessageBox.Show("Please select players before trying to generate a round.");
                return;
            }

            var dialogResult = MessageBox.Show(this, "Finalise round and create the FINAL ROUND?", "FINAL ROUND?", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            tournamentClientModel.FinaliseCurrentRoundAndGenerateFinalRound();
            RefreshUI();
        }
    }
}
