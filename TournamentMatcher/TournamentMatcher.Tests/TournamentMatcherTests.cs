using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TournamentMatcher.Tests
{
    [TestFixture]
    public class TournamentMatcherTests
    {
        [Test]
        public void TestThat_SomethingWorks()
        {
            var y = new List<Player>();
            y.Add(new Player("Mike", -13f));
            y.Add(new Player("Simon", -11f));
            y.Add(new Player("Martin", -10f));
            y.Add(new Player("Richard", -9f));
            y.Add(new Player("Jack Curtis", -8f));
            y.Add(new Player("Chris Parker", -9f));
            y.Add(new Player("Sam Shepard", -7f));
            y.Add(new Player("Jon Sharpe", -7f));
            y.Add(new Player("Matt Sinclair", -7f));
            var sut = new TournamentMatcher(y);

            var result = sut.CreateRandomisedTournament(6);
            var score = result.GetScore();
            Assert.That(result.SuggestedTournamentRounds, Is.Not.Null);
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
            var sut = SuggestedMatch.TakeFirstFourPlayers(players, out remainingPlayers);

            Assert.That(sut.GetScore(), Is.EqualTo(0));
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

            var x = SuggestedTournament.CreateRandomTournament(players, 7);

        }
    }
}
