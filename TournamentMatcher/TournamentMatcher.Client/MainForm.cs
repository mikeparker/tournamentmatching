using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btnAddPlayers_Click(object sender, EventArgs e)
        {
            AddRemovePlayersForm x = new AddRemovePlayersForm();
            x.SetPlayers(tournamentClientModel.AllPossiblePlayers);
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
    }
}
