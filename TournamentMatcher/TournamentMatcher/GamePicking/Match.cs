using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TournamentMatcher.Models;

namespace TournamentMatcher.GamePicking
{
    [DebuggerDisplay("{ToString()}")]
    public class Match
    {
        public Team Team1 { get; private set; }
        public Team Team2 { get; private set; }
        public string Score { get; set; }

        private readonly float absHandicapDifference;

        private Match(Player p1, Player p2, Player p3, Player p4)
        {
            this.Team1 = new Team(p1, p2);
            this.Team2 = new Team(p3, p4);
            this.absHandicapDifference = Math.Abs(this.Team1.CompareHandicapWith(this.Team2));
        }

        public override string ToString()
        {
            return "Match:" + this.Team1.Player1.Name + " + " + this.Team1.Player2.Name + " vs " + this.Team2.Player1.Name + " + " + this.Team2.Player2.Name + " | Hcap: " + this.absHandicapDifference;
        }

        public static Match CreateMatchFromIntelligentlySelectedPlayers(List<Player> allPlayersRandomised, out List<Player> remainingPlayers, bool topFirst)
        {
            if (allPlayersRandomised.Count < 4)
            {
                remainingPlayers = allPlayersRandomised;
                return null;
            }

            List<Player> playersOrdered = OrderPlayersByHandicap(allPlayersRandomised, topFirst);

            var initialPlayer = playersOrdered[0];
            playersOrdered.RemoveAt(0);

            var bestPartner = MatchPicker.FindBestPartner(playersOrdered, initialPlayer);
            playersOrdered.Remove(bestPartner);

            Match match;
            List<Player> bestOpponents = FindBestOpponentsAndMakeMatch(playersOrdered, initialPlayer, bestPartner, out match);

            match.Finalise();

            playersOrdered.Remove(bestOpponents[0]);
            playersOrdered.Remove(bestOpponents[1]);
            remainingPlayers = playersOrdered;
            return match;
        }

        private static List<Player> OrderPlayersByHandicap(List<Player> allPlayersRandomised, bool topFirst)
        {
            return topFirst 
                ? allPlayersRandomised.OrderBy(p => p.Handicap).ToList() 
                : allPlayersRandomised.OrderByDescending(p => p.Handicap).ToList();
        }

        private void Finalise()
        {
            this.Team1.FinaliseGame(Team2);
        }

        private static List<Player> FindBestOpponentsAndMakeMatch(List<Player> playersOrdered, Player initialPlayer, Player bestPartner, out Match match)
        {
            var bestOpponents = MatchPicker.FindBestOpponents(playersOrdered, initialPlayer, bestPartner);
            var p1 = initialPlayer;
            var p2 = bestPartner;
            var p3 = bestOpponents[0];
            var p4 = bestOpponents[1];
            match = new Match(p1, p2, p3, p4);
            return bestOpponents;
        }

        public float GetScoreForPlayerHandicapDifferences()
        {
            return GetPlayerHandicapStdDev();
        }

        private float GetPlayerHandicapStdDev()
        {
            var avgHandicap = (this.Team1.Player1.Handicap + this.Team1.Player2.Handicap + this.Team2.Player1.Handicap +
                               this.Team2.Player2.Handicap)/4;
            var stdDev = (this.Team1.GetStdDevHandicap(avgHandicap) + this.Team2.GetStdDevHandicap(avgHandicap))/2;
            return stdDev;
        }
    }
}