using System;
using System.Collections.Generic;
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
            OpenAddPlayersForm();
        }

        private void OpenAddPlayersForm()
        {
            AddRemovePlayersForm x = new AddRemovePlayersForm();
            x.SetModel(this.tournamentClientModel);
            x.ShowDialog(this);
        }

        private void button1_Click_1(object sender, EventArgs e)
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
            this.dgvNextRound.DataSource = tournamentClientModel.CurrentRoundBindingList;
            this.dgvGamesPlayed.DataSource = tournamentClientModel.PreviousRoundsBindingList;
            this.lblSittingOut.Text = "Sitting out:" + string.Join(", ", tournamentClientModel.CurrentRound.PlayersSittingOut.Select(p => p.Name));
        }
    }
}
