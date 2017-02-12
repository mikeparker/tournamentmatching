using System;
using System.Collections.Generic;
using System.Linq;
using TournamentMatcher.lib;
using TournamentMatcher.Models;

namespace TournamentMatcher.GamePicking
{
    public class SuggestedTournamentRound
    {
        public List<Player> PlayersSittingOut { get; private set; } 
        public List<SuggestedMatch> SuggestedMatches;

        public SuggestedTournamentRound()
        {
            this.PlayersSittingOut = new List<Player>();
            this.SuggestedMatches = new List<SuggestedMatch>();
        }

        public static SuggestedTournamentRound CreateRandomRound(List<Player> players)
        {
            players.Shuffle();
            var round = new SuggestedTournamentRound();

            var playersSittingOut = CalculatePlayersSittingOutNext(players);
            round.AddPlayersSittingOut(playersSittingOut);
            var playingPlayers = players.Except(playersSittingOut).ToList();
            List<Player> remainingPlayers;
            var match = SuggestedMatch.CreateMatchFromFirstFirstFourPlayers(playingPlayers, out remainingPlayers);
            while (match != null)
            {
                round.AddMatch(match, true);
                playingPlayers = remainingPlayers;
                match = SuggestedMatch.CreateMatchFromFirstFirstFourPlayers(playingPlayers, out remainingPlayers);

            }

            if (remainingPlayers.Count != 0)
            {
                throw new Exception("Was not expecting any remaining players!");
            }

            return round;
        }

        public static SuggestedTournamentRound CreateIntelligentRound(List<Player> players)
        {
            players.Shuffle();
            var round = new SuggestedTournamentRound();

            var playersSittingOut = CalculatePlayersSittingOutNext(players);
            round.AddPlayersSittingOut(playersSittingOut);
            var playingPlayers = players.Except(playersSittingOut).ToList();
            List<Player> remainingPlayers;
            //            var match = SuggestedMatch.CreateMatchFromFirstFirstFourPlayers(playingPlayers, out remainingPlayers);
            bool topFirst = true;
            var match = SuggestedMatch.CreateMatchFromIntelligentlySelectedPlayers(playingPlayers, out remainingPlayers, topFirst);
            while (match != null)
            {
                topFirst = !topFirst;
                round.AddMatch(match, topFirst);
                playingPlayers = remainingPlayers;
                match = SuggestedMatch.CreateMatchFromIntelligentlySelectedPlayers(playingPlayers, out remainingPlayers, topFirst);
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
            this.PlayersSittingOut.AddRange(players);
        }

        private void AddMatch(SuggestedMatch match, bool topFirst)
        {
            if (!topFirst)
            {
                this.SuggestedMatches.Insert(0 + (this.SuggestedMatches.Count / 2), match);
            }
            else
            {
                this.SuggestedMatches.Insert(0+(this.SuggestedMatches.Count/2), match);
            }
        }

        public float GetScoreForPlayerHandicapDifferences()
        {
            return this.SuggestedMatches.Sum(m => m.GetScoreForPlayerHandicapDifferences()) / this.SuggestedMatches.Count;
        }
    }
}