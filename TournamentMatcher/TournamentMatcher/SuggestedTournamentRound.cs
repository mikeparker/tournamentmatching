using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentMatcher
{
    public class SuggestedTournamentRound
    {
        public List<Player> PlayersSittingOut { get; private set; } 
        public List<SuggestedMatch> SuggestedMatches;

        public SuggestedTournamentRound()
        {
            PlayersSittingOut = new List<Player>();
            SuggestedMatches = new List<SuggestedMatch>();
        }

        public static SuggestedTournamentRound CreateRandomRound(List<Player> players)
        {
            players.Shuffle();
            var round = new SuggestedTournamentRound();

            var playersSittingOut = CalculatePlayersSittingOutNext(players);
            round.AddPlayersSittingOut(playersSittingOut);
            var playingPlayers = players.Except(playersSittingOut).ToList();
            List<Player> remainingPlayers;
            var match = SuggestedMatch.TakeFirstFourPlayers(playingPlayers, out remainingPlayers);
            while (match != null)
            {
                round.AddMatch(match);
                playingPlayers = remainingPlayers;
                match = SuggestedMatch.TakeFirstFourPlayers(playingPlayers, out remainingPlayers);
            }

            if (remainingPlayers.Count != 0)
            {
                throw new Exception("Was not expecting any remainig players!");
            }

            return round;
        }

        private static List<Player> CalculatePlayersSittingOutNext(List<Player> players)
        {
            var numSittingOutPerRound = players.Count % 4;
            var playersToSitOut = new List<Player>();
            for (int i = 0; i < numSittingOutPerRound; i++)
            {
                var minimumSitOut = players.Min(p => p.NumberOfGamesSatOutSoFar);
                var potentialPlayers = players.Where(p => p.NumberOfGamesSatOutSoFar == minimumSitOut && !playersToSitOut.Contains(p));
                var playerToSitOut = potentialPlayers.First();
                playerToSitOut.NumberOfGamesSatOutSoFar++;
                playersToSitOut.Add(playerToSitOut);
            }

            return playersToSitOut;
        }

        private void AddPlayersSittingOut(List<Player> players)
        {
            PlayersSittingOut.AddRange(players);
        }

        private void AddMatch(SuggestedMatch match)
        {
            SuggestedMatches.Add(match);
        }

        public float GetScore()
        {
            return this.SuggestedMatches.Sum(m => m.GetScore());
        }
    }
}