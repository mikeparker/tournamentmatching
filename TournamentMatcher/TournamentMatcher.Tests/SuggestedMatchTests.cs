using System.Collections.Generic;
using NUnit.Framework;
using TournamentMatcher.GamePicking;
using TournamentMatcher.Models;

namespace TournamentMatcher.Tests
{
    [TestFixture]
    class SuggestedMatchTests
    {
        [Test]
        public void TestGetScoreForMostBalancedGameWorksWithPositiveAndNegativeTeamHandicaps()
        {
            var playerOne = new Player("one", -10f);
            var playerTwo = new Player("two", -10f);
            var restOfPlayers = new List<Player>()
            {
                new Player("three", 10f),
                new Player("four", 10f),
                playerTwo
            };

            var scoreForMostBalancedGame = SuggestedMatch.GetScoreForMostBalancedGame(playerOne, playerTwo, restOfPlayers);
            Assert.That(scoreForMostBalancedGame, Is.EqualTo(40));
        }

        [Test]
        public void TestGetScoreForMostBalancedGameWorksWithNegativeAndPositiveTeamHandicaps()
        {
            var playerOne = new Player("one", 10f);
            var playerTwo = new Player("two", 10f);
            var restOfPlayers = new List<Player>()
            {
                new Player("three", -10f),
                new Player("four", -10f),
                playerTwo
            };

            var scoreForMostBalancedGame = SuggestedMatch.GetScoreForMostBalancedGame(playerOne, playerTwo, restOfPlayers);
            Assert.That(scoreForMostBalancedGame, Is.EqualTo(40));
        }
    }
}
