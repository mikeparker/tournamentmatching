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

        public AddRemovePlayersForm()
        {
            InitializeComponent();
        }

        public void SetPlayers(List<Player> allPossiblePlayers)
        {
            this.allPossiblePlayers = allPossiblePlayers;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
