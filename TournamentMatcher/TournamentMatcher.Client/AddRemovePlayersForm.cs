using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentMatcher.Models;

namespace TournamentMatcher.Client
{
    public partial class AddRemovePlayersForm : Form
    {
        private List<Player> allPossiblePlayers;
        private BindingList<Player> currentPlayersNotPlaying;
        private BindingList<Player> currentTournamentPlayers;

        public AddRemovePlayersForm()
        {
            InitializeComponent();
        }

        public void SetPlayers(List<Player> allPossiblePlayers)
        {
            this.currentPlayersNotPlaying = new BindingList<Player>(allPossiblePlayers);
            this.allPossiblePlayers = allPossiblePlayers;
            currentTournamentPlayers = new BindingList<Player>();
            SetDataGrid(this.dataGridView1, this.currentPlayersNotPlaying);
            SetDataGrid(this.dataGridView2, this.currentTournamentPlayers);
        }

        private void SetDataGrid(DataGridView dataGridView, BindingList<Player> playersList)
        {
            dataGridView.DataSource = playersList;
            dataGridView.Columns[2].Visible = false;
            dataGridView.Columns[3].Visible = false;
            dataGridView.Columns[4].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
    }
}
