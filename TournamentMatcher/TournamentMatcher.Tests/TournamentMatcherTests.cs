using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using TournamentMatcher.GamePicking;
using TournamentMatcher.Models;

namespace TournamentMatcher.Tests
{
    [TestFixture]
    public class TournamentMatcherTests
    {
        [Test]
        public void TestThat_SomethingWorks()
        {
            float lowestScore = 999999;
            List<SuggestedTournament> possibleTournaments = new List<SuggestedTournament>();
            for (int i = 0; i < 1; i++)
            {
                var y = new List<Player>();

                AddSmallSelectionOfMen(y);

                var sut = new GamePicking.TournamentMatcher(y);

                var result = sut.CreateRandomisedTournament(6);
                possibleTournaments.Add(result);
                if (result.Score < lowestScore)
                {
                    lowestScore = result.Score;
                }

                if (i%100 == 99)
                {
                    Debug.WriteLine(lowestScore);
                }
            }

            var orderedTournaments = possibleTournaments.OrderBy(t => t.Score);

            orderedTournaments.First().PrintToDebug();
        }

        private void AddAllPlayers(List<Player> y)
        {
            y.Add(new Player("Judith Ashman	", -3));
            y.Add(new Player("Sean Blanchflower", -3));
            y.Add(new Player("Naomi Bowman", -2));
            y.Add(new Player("Jack Boyns", -8));
            y.Add(new Player("Peter Clapham", -1));
            y.Add(new Player("Samuel Crabb", -1));
            y.Add(new Player("Martin Crossley", -11));
            y.Add(new Player("Zephanie Curgenven", -2));
            y.Add(new Player("Jack Curtis", -11));
            y.Add(new Player("Paul Davies", -2));
            y.Add(new Player("Julia Frede", -3));
            y.Add(new Player("Jenny Garratt", -2));
            y.Add(new Player("Hazel Greetham", -2));
            y.Add(new Player("David Hamilton", -3));
            y.Add(new Player("Martha Hawker", 0));
            y.Add(new Player("Paul Hilditch", -5));
            y.Add(new Player("Michael Ho", -3));
            y.Add(new Player("Neil Hunter", -1));
            y.Add(new Player("Elliot Jackson", 1));
            y.Add(new Player("Chris Jenkins", -2));
            y.Add(new Player("Hilary Jones", 2));
            y.Add(new Player("Joseph Jose", -7));
            y.Add(new Player("Thomas Keane", -1));
            y.Add(new Player("Kian Sing Low", -4));
            y.Add(new Player("Charlie Lowndes", -3));
            y.Add(new Player("Deepa Manthravadi", 3));
            y.Add(new Player("Kevin McIntyre", -1));
            y.Add(new Player("Douglas McMillan", -1));
            y.Add(new Player("Ivo Miller", -3));
            y.Add(new Player("Colin Millerchip", -2));
            y.Add(new Player("Vivek Mishra", -2));
            y.Add(new Player("Mark Nelid", -1));
            y.Add(new Player("Lorne Noble", 1));
            y.Add(new Player("Chris Parker", -9));
            y.Add(new Player("Mike Parker", -13));
            y.Add(new Player("Simon Parker", -12));
            y.Add(new Player("Rodolph Perfetta", -3));
            y.Add(new Player("Bridget Pickup", 2));
            y.Add(new Player("Charity Pickup", 1));
            y.Add(new Player("Raith Pickup", -4));
            y.Add(new Player("David Piggott", -6));
            y.Add(new Player("Alexander Ray", -3));
            y.Add(new Player("Alison Reed", -3));
            y.Add(new Player("Shang-Yik Reigh", -4));
            y.Add(new Player("Lucy Robertson", -1));
            y.Add(new Player("Jonathan Sharpe", -7));
            y.Add(new Player("Samuel Shepherd", -8));
            y.Add(new Player("Matthew Sinclair", -7));
            y.Add(new Player("Carl Skuce", -7));
            y.Add(new Player("Steven Slatter", -2));
            y.Add(new Player("Dominique Smith", -1));
            y.Add(new Player("Lorna Smith", -2));
            y.Add(new Player("Richard Smith", -9));
            y.Add(new Player("Mark Talbot", -4));
            y.Add(new Player("Chris Thomas", -3));
            y.Add(new Player("Dan Trowell", -3));
            y.Add(new Player("Lynn Trowell", -3));
            y.Add(new Player("Andy Turley", -8));
            y.Add(new Player("Paul Upton", -1));
            y.Add(new Player("Ian White", -7));
            y.Add(new Player("Andy Williamson", -5));
            y.Add(new Player("Richard Wilson", -1));
            y.Add(new Player("Becca Wisden", -2));
            y.Add(new Player("Karl Wycherley", -2));
            y.Add(new Player("Kasia Zalewska", -1));
            y.Add(new Player("Sense", -3));

        }

        private void AddMen(List<Player> y)
        {
            y.Add(new Player("Sean Blanchflower", -3));
            y.Add(new Player("Jack Boyns", -8));
            y.Add(new Player("Peter Clapham", -1));
            y.Add(new Player("Samuel Crabb", -1));
            y.Add(new Player("Martin Crossley", -11));
            y.Add(new Player("Jack Curtis", -11));
            y.Add(new Player("Paul Davies", -2));
            y.Add(new Player("David Hamilton", -3));
            y.Add(new Player("Paul Hilditch", -5));
            y.Add(new Player("Michael Ho", -3));
            y.Add(new Player("Neil Hunter", -1));
            y.Add(new Player("Elliot Jackson", 1));
            y.Add(new Player("Chris Jenkins", -2));
            y.Add(new Player("Joseph Jose", -7));
            y.Add(new Player("Thomas Keane", -1));
            y.Add(new Player("Kian Sing Low", -4));
            y.Add(new Player("Charlie Lowndes", -3));
            y.Add(new Player("Kevin McIntyre", -1));
            y.Add(new Player("Douglas McMillan", -1));
            y.Add(new Player("Ivo Miller", -3));
            y.Add(new Player("Colin Millerchip", -2));
            y.Add(new Player("Vivek Mishra", -2));
            y.Add(new Player("Mark Nelid", -1));
            y.Add(new Player("Lorne Noble", 1));
            y.Add(new Player("Chris Parker", -9));
            y.Add(new Player("Mike Parker", -13));
            y.Add(new Player("Simon Parker", -12));
            y.Add(new Player("Rodolph Perfetta", -3));
            y.Add(new Player("Raith Pickup", -4));
            y.Add(new Player("David Piggott", -6));
            y.Add(new Player("Alexander Ray", -3));
            y.Add(new Player("Shang-Yik Reigh", -4));
            y.Add(new Player("Jonathan Sharpe", -7));
            y.Add(new Player("Samuel Shepherd", -8));
            y.Add(new Player("Matthew Sinclair", -7));
            y.Add(new Player("Carl Skuce", -7));
            y.Add(new Player("Steven Slatter", -2));
            y.Add(new Player("Richard Smith", -9));
            y.Add(new Player("Mark Talbot", -4));
            y.Add(new Player("Chris Thomas", -3));
            y.Add(new Player("Dan Trowell", -3));
            y.Add(new Player("Andy Turley", -8));
            y.Add(new Player("Paul Upton", -1));
            y.Add(new Player("Ian White", -7));
            y.Add(new Player("Andy Williamson", -5));
            y.Add(new Player("Richard Wilson", -1));
            y.Add(new Player("Karl Wycherley", -2));
            y.Add(new Player("Sense", -3));
        }

        private void AddSmallSelectionOfMen(List<Player> y)
        {
            y.Add(new Player("Sean Blanchflower", -3));
//            y.Add(new Player("Jack Boyns", -8));
            y.Add(new Player("Peter Clapham", -1));
//            y.Add(new Player("Samuel Crabb", -1));
            y.Add(new Player("Martin Crossley", -11));
//            y.Add(new Player("Jack Curtis", -11));
            y.Add(new Player("Paul Davies", -2));
//            y.Add(new Player("David Hamilton", -3));
            y.Add(new Player("Paul Hilditch", -5));
//            y.Add(new Player("Michael Ho", -3));
            y.Add(new Player("Neil Hunter", -1));
//            y.Add(new Player("Elliot Jackson", 1));
            y.Add(new Player("Chris Jenkins", -2));
//            y.Add(new Player("Joseph Jose", -7));
            y.Add(new Player("Thomas Keane", -1));
//            y.Add(new Player("Kian Sing Low", -4));
            y.Add(new Player("Charlie Lowndes", -3));
//            y.Add(new Player("Kevin McIntyre", -1));
            y.Add(new Player("Douglas McMillan", -1));
//            y.Add(new Player("Ivo Miller", -3));
            y.Add(new Player("Colin Millerchip", -2));
//            y.Add(new Player("Vivek Mishra", -2));
            y.Add(new Player("Mark Nelid", -1));
//            y.Add(new Player("Lorne Noble", 1));
            y.Add(new Player("Chris Parker", -9));
//            y.Add(new Player("Mike Parker", -13));
            y.Add(new Player("Simon Parker", -12));
//            y.Add(new Player("Rodolph Perfetta", -3));
            y.Add(new Player("Raith Pickup", -4));
//            y.Add(new Player("David Piggott", -6));
            y.Add(new Player("Alexander Ray", -3));
//            y.Add(new Player("Shang-Yik Reigh", -4));
            y.Add(new Player("Jonathan Sharpe", -7));
//            y.Add(new Player("Samuel Shepherd", -8));
            y.Add(new Player("Matthew Sinclair", -7));
//            y.Add(new Player("Carl Skuce", -7));
            y.Add(new Player("Steven Slatter", -2));
//            y.Add(new Player("Richard Smith", -9));
            y.Add(new Player("Mark Talbot", -4));
//            y.Add(new Player("Chris Thomas", -3));
            y.Add(new Player("Dan Trowell", -3));
//            y.Add(new Player("Andy Turley", -8));
            y.Add(new Player("Paul Upton", -1));
//            y.Add(new Player("Ian White", -7));
            y.Add(new Player("Andy Williamson", -5));
//            y.Add(new Player("Richard Wilson", -1));
            y.Add(new Player("Karl Wycherley", -2));
//            y.Add(new Player("Sense", -3));
        }

        private void AddAllLadies(List<Player> y)
        {
            y.Add(new Player("Judith Ashman	", -3));
            y.Add(new Player("Naomi Bowman", -2));
            y.Add(new Player("Zephanie Curgenven", -2));
            y.Add(new Player("Julia Frede", -3));
            y.Add(new Player("Jenny Garratt", -2));
            y.Add(new Player("Hazel Greetham", -2));
            y.Add(new Player("Martha Hawker", 0));
            y.Add(new Player("Hilary Jones", 2));
            y.Add(new Player("Deepa Manthravadi", 3));
            y.Add(new Player("Bridget Pickup", 2));
            y.Add(new Player("Charity Pickup", 1));
            y.Add(new Player("Alison Reed", -3));
            y.Add(new Player("Lucy Robertson", -1));
            y.Add(new Player("Dominique Smith", -1));
            y.Add(new Player("Lorna Smith", -2));
            y.Add(new Player("Lynn Trowell", -3));
            y.Add(new Player("Becca Wisden", -2));
            y.Add(new Player("Kasia Zalewska", -1));
        }

        [Test]
        public void TestThat_AvgHandicapWorks()
        {
            var players = new List<Player>();
            players.Add(new Player("One", 0));
            players.Add(new Player("Two", 0));
            players.Add(new Player("Three", 2));
            players.Add(new Player("Four", 2));
            List<Player> remainingPlayers;
            var sut = SuggestedMatch.CreateMatchFromFirstFirstFourPlayers(players, out remainingPlayers);

            Assert.That(sut.GetScoreForPlayerHandicapDifferences(), Is.EqualTo(0));
        }

        [Test]
        public void TestThat_SittingOutIsFair()
        {
            var players = new List<Player>();
            players.Add(new Player("One", 0));
            players.Add(new Player("Two", 0));
            players.Add(new Player("Three", 2));
            players.Add(new Player("Four", 2));
            players.Add(new Player("Five", 1));
            players.Add(new Player("Six", 1));
            players.Add(new Player("Seven", 1));

            var x = SuggestedTournament.CreateRandomTournament(players, 7, 1.0f, 1.0f, 3.0f);

        }
    }
}
