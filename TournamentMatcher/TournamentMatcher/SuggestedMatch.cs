using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TournamentMatcher
{
    [DebuggerDisplay("Match:{Team1.Player1.Name} + {Team1.Player2.Name} vs {Team2.Player1.Name} + {Team2.Player2.Name} | Hcap: {HandicapDifference}" )]
    public class SuggestedMatch
    {
        public Team Team1;
        public Team Team2;
        public float HandicapDifference { get; private set; }

        private SuggestedMatch(Player p1, Player p2, Player p3, Player p4)
        {
            Team1 = new Team(p1, p2);
            Team2 = new Team(p3, p4);
            Team1.AddOpponents(Team2);
            HandicapDifference = Math.Abs(Team1.CompareHandicapWith(Team2));
        }

        public static SuggestedMatch CreateMatchFromFirstFirstFourPlayers(List<Player> allPlayersRandomised, out List<Player> remainingPlayers)
        {
            if (allPlayersRandomised.Count < 4)
            {
                remainingPlayers = allPlayersRandomised;
                return null;
            }

            var p1 = allPlayersRandomised[0];
            var p2 = allPlayersRandomised[1];
            var p3 = allPlayersRandomised[2];
            var p4 = allPlayersRandomised[3];
            var match = new SuggestedMatch(p1, p2, p3, p4);
            remainingPlayers = allPlayersRandomised.Skip(4).ToList();
            return match;
        }

        public float GetScoreForPlayerHandicapDifferences()
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