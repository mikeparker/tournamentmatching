using NUnit.Framework;

namespace TournamentMatcher.Tests
{
    [TestFixture]
    public class TournamentClientTests
    {
        [Test]
        public void TestSomething()
        {
            // the client should be initialised with a list of players with their handicaps
            // Perhaps read from a file.
            var player = HandicapFileParser.ParsePlayer("Something, -3");

            Assert.That(player, Is.Not.Null);
        }

        [Test]
        public void TestParsePlayerIgnoresBlankLines()
        {
            var player = HandicapFileParser.ParsePlayer("");

            Assert.That(player, Is.Null);
        }

        [Test]
        public void TestParsePlayerStoresName()
        {
            var player = HandicapFileParser.ParsePlayer("Mike Parker, -10");

            Assert.That(player.Name, Is.EqualTo("Mike Parker"));
            Assert.That(player.Handicap, Is.EqualTo(-10));
        }
    }
}
