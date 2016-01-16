using System.Collections.Generic;
using System.Linq;

namespace TournamentMatcher
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
        public List<SuggestedTournamentRound> SuggestedTournamentRounds { get; private set; }

        public SuggestedTournament(List<Player> players, float weightDifferentPartners, float weightDifferentOpponents, float weightSimilarSkill)
        {
            this.players = players;
            this.weightDifferentPartners = weightDifferentPartners;
            this.weightDifferentOpponents = weightDifferentOpponents;
            this.weightSimilarSkill = weightSimilarSkill;
            this.SuggestedTournamentRounds = new List<SuggestedTournamentRound>();
        }

        public static SuggestedTournament CreateRandomTournament(List<Player> players, int numRounds, 
            float weightDifferentPartners, float weightDifferentOpponents, float weightSimilarSkill)
        {
            var newTournament = new SuggestedTournament(players, weightDifferentPartners, weightDifferentOpponents, weightSimilarSkill);

            for (int i = 0; i < numRounds; i++)
            {
                var currentRound = SuggestedTournamentRound.CreateRandomRound(players);
                newTournament.AddRound(currentRound);
            }

            newTournament.StoreScore();

            return newTournament;
        }

        private void StoreScore()
        {
            this.Score = GetScore();
        }

        public float Score { get; private set; }

        private void AddRound(SuggestedTournamentRound currentRound)
        {
            SuggestedTournamentRounds.Add(currentRound);
        }

        private float GetScore()
        {
            // Todo: Differences in skill level DONE
            // TODO: Players don't sit out too many times DONE
            // TODO: Players dont play with the same partner DONE
            // TODO: Players dont play in the same game as others DONE
            // TODO: Differences in skill level between partners
            var totalScoreForAllRounds = SuggestedTournamentRounds.Sum(r => r.GetScoreForPlayerHandicapDifferences());
            var avgScorePerRound = totalScoreForAllRounds/SuggestedTournamentRounds.Count;

            // for each player, calculate their tournament based on partners
            var totalPartnerScoreForAllPlayers = this.players.Sum(p => p.GetPartnerScore());
            var totalOpponentScoreForAllPlayers = this.players.Sum(p => p.GetOpponentScore());

            var avgPartnerScore = totalPartnerScoreForAllPlayers/players.Count;
            var avgOpponentScore = totalOpponentScoreForAllPlayers/players.Count;
            return avgScorePerRound*weightSimilarSkill + avgPartnerScore*weightDifferentPartners + avgOpponentScore*weightDifferentOpponents;
        }
    }
}