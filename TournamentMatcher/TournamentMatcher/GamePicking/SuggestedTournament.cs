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
                var currentRound = TournamentRound.CreateIntelligentRound(players);
//                var currentRound = TournamentRound.CreateRandomRound(players);
                newTournament.AddRound(currentRound);
                Debug.WriteLine("*** Creating Round " + i + " *******");
            }

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

        public void PrintToDebug()
        {
            var rounds = this.SuggestedTournamentRounds.ToList();
//            rounds.Shuffle();

            for (int i = 0; i < rounds.Count; i++)
            {
                var suggestedTournamentRound = rounds[i];
                Debug.WriteLine("");
                Debug.WriteLine("ROUND " +(i+1));
                Debug.WriteLine("-------");
                if (suggestedTournamentRound.PlayersSittingOut.Any())
                {
                    Debug.WriteLine("Sitting out: " + string.Join(", ", suggestedTournamentRound.PlayersSittingOut));
                }
                foreach (var suggestedMatch in suggestedTournamentRound.SuggestedMatches)
                {
                    Debug.WriteLine(suggestedMatch.ToString());
                }
            }

            foreach (var player in this.players.OrderBy(p => p.Handicap))
            {
                Debug.WriteLine("");
                Debug.WriteLine("-- " + player.GetNameWithHandicapString() + "--");
                Debug.WriteLine("Partners: " + string.Join(", ", player.PartnersSoFar.Select(p => p.Key.GetNameWithHandicapString() + DisplayIfMoreThanOne(p.Value))));
                Debug.WriteLine("Opponents: " + string.Join(", ", player.OpponentsSoFar.Select(p => p.Key.GetNameWithHandicapString() + DisplayIfMoreThanOne(p.Value))));
                var partnersMoreThanOnce = player.PartnersSoFar.Where(p => p.Value > 1);
                var opponentsMoreThanOnce = player.OpponentsSoFar.Where(p => p.Value > 1);

                Debug.WriteIf(partnersMoreThanOnce.Any(), "** Duplicate partners: " + string.Join(", ", partnersMoreThanOnce.Select(p => p.Key.GetNameWithHandicapString() + DisplayIfMoreThanOne(p.Value))) + "\n");
                Debug.WriteIf(opponentsMoreThanOnce.Any(), "** Duplicate opponents: " + string.Join(", ", opponentsMoreThanOnce.Select(p => p.Key.GetNameWithHandicapString() + DisplayIfMoreThanOne(p.Value))) + "\n");
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