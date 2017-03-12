using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TournamentMatcher.Models;

namespace TournamentMatcher.GamePicking
{
    public class SuggestedTournament
    {
        private readonly List<Player> players;
        private readonly float weightDifferentPartners;
        private readonly float weightDifferentOpponents;
        private readonly float weightSimilarSkill;
        // a tournament has multiple rounds
        // each round has a set of matches
        // each match has 2 teams
        // each team has 2 players
        public List<TournamentRound> SuggestedTournamentRounds { get; private set; }

        public SuggestedTournament(List<Player> players, float weightDifferentPartners, float weightDifferentOpponents, float weightSimilarSkill)
        {
            this.players = players;
            this.weightDifferentPartners = weightDifferentPartners;
            this.weightDifferentOpponents = weightDifferentOpponents;
            this.weightSimilarSkill = weightSimilarSkill;
            this.SuggestedTournamentRounds = new List<TournamentRound>();
        }

        public static SuggestedTournament CreateRandomTournament(List<Player> players, int numRounds, 
            float weightDifferentPartners, float weightDifferentOpponents, float weightSimilarSkill)
        {
            var newTournament = new SuggestedTournament(players, weightDifferentPartners, weightDifferentOpponents, weightSimilarSkill);

            for (int i = 0; i < numRounds; i++)
            {
                Debug.WriteLine("*** Creating Round " + i + " *******");
                var currentRound = TournamentRound.CreateIntelligentRound(players);
//                var currentRound = TournamentRound.CreateRandomRound(players);
                newTournament.AddRound(currentRound);
            }

            var playersNeedingExtraRound = TournamentRound.GetPlayersNeedingExtraRoundAndSitOutRest(players);

            Debug.WriteLine("*** Creating Extra Round For Players That Sat Out *******");
            var extraRound = TournamentRound.CreateIntelligentRound(playersNeedingExtraRound);
            newTournament.AddRound(extraRound);

            newTournament.StoreScore();

            return newTournament;
        }

        private void StoreScore()
        {
            this.Score = GetScore();
        }

        public float Score { get; private set; }

        private void AddRound(TournamentRound currentRound)
        {
            this.SuggestedTournamentRounds.Add(currentRound);
        }

        private float GetScore()
        {
            // Todo: Differences in skill level DONE
            // TODO: Players don't sit out too many times DONE
            // TODO: Players dont play with the same partner DONE
            // TODO: Players dont play in the same game as others DONE
            // TODO: Differences in skill level between partners
            var totalScoreForAllRounds = this.SuggestedTournamentRounds.Sum(r => r.GetScoreForPlayerHandicapDifferences());
            var avgScorePerRound = totalScoreForAllRounds/this.SuggestedTournamentRounds.Count;

            // for each player, calculate their tournament based on partners
            var totalPartnerScoreForAllPlayers = this.players.Sum(p => p.GetScoreForPartnersSoFar());
            var totalOpponentScoreForAllPlayers = this.players.Sum(p => p.GetScoreForOpponentsSoFar());

            var avgPartnerScore = totalPartnerScoreForAllPlayers/this.players.Count;
            var avgOpponentScore = totalOpponentScoreForAllPlayers/this.players.Count;
            return avgScorePerRound*this.weightSimilarSkill + avgPartnerScore*this.weightDifferentPartners + avgOpponentScore*this.weightDifferentOpponents;
        }

        public void PrintToDebug(Action<string> alternativeOutput = null)
        {
            var rounds = this.SuggestedTournamentRounds.ToList();
           
            var outputFunc = new Action<string>(str => PrintMaybe(alternativeOutput, str));
//            rounds.Shuffle();

            for (int i = 0; i < rounds.Count; i++)
            {
                var suggestedTournamentRound = rounds[i];
                outputFunc("");
                outputFunc("ROUND " + (i + 1));
                outputFunc("-------");
                if (suggestedTournamentRound.PlayersSittingOut.Any())
                {
                    outputFunc(" * Sitting out: " + string.Join(", ", suggestedTournamentRound.PlayersSittingOut));
                }
                foreach (var suggestedMatch in suggestedTournamentRound.SuggestedMatches)
                {
                    outputFunc(suggestedMatch.ToString());
                }
            }

            foreach (var player in this.players.OrderBy(p => p.Handicap))
            {
                outputFunc("");
                outputFunc("-- " + player.GetNameWithHandicapString() + "--");
                outputFunc("Partners: " + string.Join(", ", player.PartnersSoFar.Select(p => p.Key.GetNameWithHandicapString() + DisplayIfMoreThanOne(p.Value))));
                outputFunc("Opponents: " + string.Join(", ", player.OpponentsSoFar.Select(p => p.Key.GetNameWithHandicapString() + DisplayIfMoreThanOne(p.Value))));
                var partnersMoreThanOnce = player.PartnersSoFar.Where(p => p.Value > 1);
                var opponentsMoreThanOnce = player.OpponentsSoFar.Where(p => p.Value > 1);

                if (partnersMoreThanOnce.Any())
                {
                    outputFunc("** Duplicate partners: " + string.Join(", ", partnersMoreThanOnce.Select(p => p.Key.GetNameWithHandicapString() + DisplayIfMoreThanOne(p.Value))) + "\n");
                }
                if (opponentsMoreThanOnce.Any())
                {
                    outputFunc("** Duplicate opponents: " + string.Join(", ", opponentsMoreThanOnce.Select(p => p.Key.GetNameWithHandicapString() + DisplayIfMoreThanOne(p.Value))) + "\n");
                }
            }
        }

        private void PrintMaybe(Action<string> alternativeOutput, string input)
        {
            if (alternativeOutput != null)
            {
                alternativeOutput(input);
            }
            else
            {
                Debug.WriteLine(input);
            }
        }

        private string DisplayIfMoreThanOne(int number)
        {
            if (number == 1)
            {
                return string.Empty;
            }
            else
            {
                return " x" + number.ToString();
            }
        }
    }
}