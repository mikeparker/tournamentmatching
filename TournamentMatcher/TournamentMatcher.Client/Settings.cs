using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TournamentMatcher.GamePicking;
using TournamentMatcher.Models;

namespace TournamentMatcher.Client
{
    public partial class Settings : Form
    {
        private readonly List<Player> playersInTournament;

        public Settings(List<Player> playersInTournament)
        {
            this.playersInTournament = playersInTournament;
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
            SaveWeights();
            Close();
        }

        private void SaveWeights()
        {
            Weights.Instance.PartnerVariation = this.sliderPartnerVariation.Value;
            Weights.Instance.OpponentVariation = this.sliderOpponentVariation.Value;
            Weights.Instance.SkillDifferenceForPartner = this.sliderPartnerSkillDiff.Value / 10f;
            Weights.Instance.SkillDifferenceForOpponent = this.sliderOpponentSkillDiff.Value / 10f;
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

        private void btnGenerateExampleTournament_Click(object sender, EventArgs e)
        {
            SaveWeights();
            List<Player> players;
            if (this.playersInTournament == null || !this.playersInTournament.Any())
            {
                players = MakeListWithAllPlayers();
            }
            else
            {
                players = playersInTournament;
            }
            var sut = new GamePicking.TournamentMatcher(players);

            var result = sut.CreateRandomisedTournament(6);

            var x = "";
            result.PrintToDebug(str => x += str + "\n");
            new ExampleTournamentForm(x).Show(this);
        }

        private List<Player> MakeListWithAllPlayers()
        {
            var players = new List<Player>();
            players.Add(new Player("Judith Ashman	", -3));
            players.Add(new Player("Sean Blanchflower", -3));
            players.Add(new Player("Naomi Bowman", -2));
            players.Add(new Player("Jack Boyns", -8));
            players.Add(new Player("Peter Clapham", -1));
            players.Add(new Player("Samuel Crabb", -1));
            players.Add(new Player("Martin Crossley", -11));
            players.Add(new Player("Zephanie Curgenven", -2));
            players.Add(new Player("Jack Curtis", -11));
            players.Add(new Player("Paul Davies", -2));
            players.Add(new Player("Julia Frede", -3));
            players.Add(new Player("Jenny Garratt", -2));
            players.Add(new Player("Hazel Greetham", -2));
            players.Add(new Player("David Hamilton", -3));
            players.Add(new Player("Martha Hawker", 0));
            players.Add(new Player("Paul Hilditch", -5));
            players.Add(new Player("Michael Ho", -3));
            players.Add(new Player("Neil Hunter", -1));
            players.Add(new Player("Elliot Jackson", 1));
            players.Add(new Player("Chris Jenkins", -2));
            players.Add(new Player("Hilary Jones", 2));
            players.Add(new Player("Joseph Jose", -7));
            players.Add(new Player("Thomas Keane", -1));
            players.Add(new Player("Kian Sing Low", -4));
            players.Add(new Player("Charlie Lowndes", -3));
            players.Add(new Player("Deepa Manthravadi", 3));
            players.Add(new Player("Kevin McIntyre", -1));
            players.Add(new Player("Douglas McMillan", -1));
            players.Add(new Player("Ivo Miller", -3));
            players.Add(new Player("Colin Millerchip", -2));
            players.Add(new Player("Vivek Mishra", -2));
            players.Add(new Player("Mark Nelid", -1));
            players.Add(new Player("Lorne Noble", 1));
            players.Add(new Player("Chris Parker", -9));
            players.Add(new Player("Mike Parker", -13));
            players.Add(new Player("Simon Parker", -12));
            players.Add(new Player("Rodolph Perfetta", -3));
            players.Add(new Player("Bridget Pickup", 2));
            players.Add(new Player("Charity Pickup", 1));
            players.Add(new Player("Raith Pickup", -4));
            players.Add(new Player("David Piggott", -6));
            players.Add(new Player("Alexander Ray", -3));
            players.Add(new Player("Alison Reed", -3));
            players.Add(new Player("Shang-Yik Reigh", -4));
            players.Add(new Player("Lucy Robertson", -1));
            players.Add(new Player("Jonathan Sharpe", -7));
            players.Add(new Player("Samuel Shepherd", -8));
            players.Add(new Player("Matthew Sinclair", -7));
            players.Add(new Player("Carl Skuce", -7));
            players.Add(new Player("Steven Slatter", -2));
            players.Add(new Player("Dominique Smith", -1));
            players.Add(new Player("Lorna Smith", -2));
            players.Add(new Player("Richard Smith", -9));
            players.Add(new Player("Mark Talbot", -4));
            players.Add(new Player("Chris Thomas", -3));
            players.Add(new Player("Dan Trowell", -3));
            players.Add(new Player("Lynn Trowell", -3));
            players.Add(new Player("Andy Turley", -8));
            players.Add(new Player("Paul Upton", -1));
            players.Add(new Player("Ian White", -7));
            players.Add(new Player("Andy Williamson", -5));
            players.Add(new Player("Richard Wilson", -1));
            players.Add(new Player("Becca Wisden", -2));
            players.Add(new Player("Karl Wycherley", -2));
            players.Add(new Player("Kasia Zalewska", -1));
            players.Add(new Player("Sense", -3));

            return players;
        }
    }
}
