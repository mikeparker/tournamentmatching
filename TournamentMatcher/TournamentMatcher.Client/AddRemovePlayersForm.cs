using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TournamentMatcher.Models;

namespace TournamentMatcher.Client
{
    public partial class AddRemovePlayersForm : Form
    {
        private SortableBindingList<Player> currentPlayersNotPlaying;
        private SortableBindingList<Player> currentTournamentPlayers;
        private TournamentClientModel model;

        public AddRemovePlayersForm()
        {
            InitializeComponent();
        }

        private void SetDataGrid(DataGridView dataGridView, BindingList<Player> playersList)
        {
            dataGridView.DataSource = playersList;
            dataGridView.Columns[2].Visible = false;
            dataGridView.Columns[3].Visible = false;
            dataGridView.Columns[4].Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            model.SetPlayersInTournament(currentTournamentPlayers.ToList());
            this.Close();
        }

        // Add players
        private void button1_Click(object sender, EventArgs e)
        {
            MovePlayers(this.dataGridView1, this.currentPlayersNotPlaying, this.currentTournamentPlayers);
        }

        private void MovePlayers(DataGridView dataGridView, BindingList<Player> playersToMoveFrom, BindingList<Player> playersToMoveTo)
        {
            Int32 selectedRowCount = dataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0)
            {
                return;
            }

            var indexesToMove = new HashSet<int>();
            for (int i = 0; i < selectedRowCount; i++)
            {
                var index = dataGridView.SelectedRows[i].Index;
                indexesToMove.Add(index);
            }

            MoveIndexesBetweenLists(indexesToMove, playersToMoveFrom, playersToMoveTo);
        }

        private void MoveIndexesBetweenLists(HashSet<int> indexesToMove, BindingList<Player> playersToMoveFrom, BindingList<Player> playersToMoveTo)
        {
            var firstListLength = playersToMoveFrom.Count;
            for (int i = firstListLength; i >= 0; i--)
            {
                if (indexesToMove.Contains(i))
                {
                    playersToMoveTo.Add(playersToMoveFrom[i]);
                    playersToMoveFrom.RemoveAt(i);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MovePlayers(this.dataGridView2, this.currentTournamentPlayers, this.currentPlayersNotPlaying);
        }

        public void SetModel(TournamentClientModel tournamentClientModel)
        {
            this.model = tournamentClientModel;
            this.currentPlayersNotPlaying = new SortableBindingList<Player>(tournamentClientModel.AllPossiblePlayers);
            currentTournamentPlayers = new SortableBindingList<Player>();
            SetDataGrid(this.dataGridView1, this.currentPlayersNotPlaying);
            SetDataGrid(this.dataGridView2, this.currentTournamentPlayers);
        }
    }
}
