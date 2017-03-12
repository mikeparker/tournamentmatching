using System;
using System.Windows.Forms;

namespace TournamentMatcher.Client
{
    public partial class ExampleTournamentForm : Form
    {
        public ExampleTournamentForm(string text)
        {
            InitializeComponent();
            this.listBox1.Items.AddRange(text.Split('\n'));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
