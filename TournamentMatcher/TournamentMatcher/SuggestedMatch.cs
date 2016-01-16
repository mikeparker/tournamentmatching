using System.Collections.Generic;
using System.Linq;

namespace TournamentMatcher
{
    public class SuggestedMatch
    {
        public Team Team1;
        public Team Team2;
        public float HandicapDifference { get; private set; }

        private SuggestedMatch(Player p1, Player p2, Player p3, Player p4)
        {
            Team1 = new Team(p1, p2);
            Team2 = new Team(p3, p4);
            HandicapDifference = Team1.CompareHandicapWith(Team2);
        }

        public static SuggestedMatch TakeFirstFourPlayers(List<Player> allPlayersRandomised, out List<Player> remainingPlayers)
        {
            if (allPlayersRandomised.Count < 4)
            {
                remainingPlayers = allPlayersRandomised;
                return null;
            }

            var match = new SuggestedMatch(allPlayersRandomised[0], allPlayersRandomised[1], allPlayersRandomised[2], allPlayersRandomised[3]);
            remainingPlayers = allPlayersRandomised.Skip(4).ToList();
            return match;
        }

        public float GetScore()
        {
            return GetPlayerHandicapStdDev();
        }

        private float GetPlayerHandicapStdDev()
        {
            var avgHandicap = (Team1.Player1.Handicap + Team1.Player2.Handicap + Team2.Player1.Handicap +
                               Team2.Player2.Handicap)/4;
            var stdDev = (Team1.GetStdDevHandicap(avgHandicap) + Team2.GetStdDevHandicap(avgHandicap))/2;
            return stdDev;
        }
    }
}