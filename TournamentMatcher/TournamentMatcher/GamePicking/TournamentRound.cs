using System;
using System.Collections.Generic;
using System.Linq;
using TournamentMatcher.lib;
using TournamentMatcher.Models;

namespace TournamentMatcher.GamePicking
{
    public class TournamentRound
    {
        public List<Player> PlayersSittingOut { get; private set; } 
        public List<Match> SuggestedMatches;

        public TournamentRound()
        {
            this.PlayersSittingOut = new List<Player>();
            this.SuggestedMatches = new List<Match>();
        }

        public static TournamentRound CreateIntelligentRound(List<Player> players)
        {
            players.Shuffle();
            var round = new TournamentRound();

            var playersSittingOut = CalculatePlayersSittingOutNext(players);
            round.AddPlayersSittingOut(playersSittingOut);
            var playingPlayers = players.Except(playersSittingOut).ToList();
            List<Player> remainingPlayers;
            bool topFirst = true;
            var match = Match.CreateMatchFromIntelligentlySelectedPlayers(playingPlayers, out remainingPlayers, topFirst);
            while (match != null)
            {
                topFirst = !topFirst;
                round.AddMatch(match, topFirst);
                playingPlayers = remainingPlayers;
                match = Match.CreateMatchFromIntelligentlySelectedPlayers(playingPlayers, out remainingPlayers, topFirst);
            }

            if (remainingPlayers.Count != 0)
            {
                throw new Exception("Was not expecting any remainig players!");
            }

            return round;
        }

        public static List<Player> GetPlayersNeedingExtraRoundAndSitOutRest(List<Player> players)
        {
            var groups = players.GroupBy(p => p.NumberOfGamesSatOutSoFar).OrderByDescending(g => g.Key);
            if (groups.Count() == 1)
            {
                return new List<Player>();
            }

            var playersNeedingExtraRound = groups.First().ToList();
            var playersToChooseSubsFrom = groups.Skip(1).First().ToList();
            playersToChooseSubsFrom.ForEach(p => p.NumberOfGamesSatOutSoFar++);
            var subs = GetSubsForFinalRound(playersToChooseSubsFrom, playersNeedingExtraRound);
//            subs.ForEach(p => p.Name += " (SUB)");
            var playersPlusSubs = playersNeedingExtraRound.Concat(subs).ToList();
            return playersPlusSubs;
        }

        private static List<Player> GetSubsForFinalRound(List<Player> playersToChooseSubsFrom, List<Player> playersNeedingExtraRound)
        {
            // TODO: Make a more intelligent sub-choosing function
            var numberOfExtraPlayersNeeded = 4 - (playersNeedingExtraRound.Count % 4);
            if (numberOfExtraPlayersNeeded == 4)
            {
                return new List<Player>();
            }

            var playersInOrder = playersNeedingExtraRound.OrderBy(p => p.Handicap);
            var maxHandicap = playersInOrder.First().Handicap;
            var minHandicap = playersInOrder.Last().Handicap;
            var averageHandicap = (maxHandicap + minHandicap) / 2;
            var subsInOrder = playersToChooseSubsFrom.OrderBy(p => Math.Abs(p.Handicap - averageHandicap));
            return subsInOrder.Take(numberOfExtraPlayersNeeded).ToList();
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

        private void AddMatch(Match match, bool topFirst)
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