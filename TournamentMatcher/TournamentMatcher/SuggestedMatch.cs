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
        private const int MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO = 15;
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

        public static SuggestedMatch CreateMatchFromIntelligentlySelectedPlayers(List<Player> allPlayersRandomised, out List<Player> remainingPlayers, bool topFirst)
        {
            if (allPlayersRandomised.Count < 4)
            {
                remainingPlayers = allPlayersRandomised;
                return null;
            }

            List<Player> playersOrdered = topFirst 
                                            ? allPlayersRandomised.OrderBy(p => p.Handicap).ToList() 
                                            : allPlayersRandomised.OrderByDescending(p => p.Handicap).ToList();

            List<Player> playersForThisGame = new List<Player>();
            var initialPlayer = playersOrdered[0];
            playersOrdered.RemoveAt(0);
            playersForThisGame.Add(initialPlayer);

            var bestPartner = FindBestPartner(playersOrdered, initialPlayer);
            playersOrdered.Remove(bestPartner);
            var bestOpponents = FindBestOpponents(playersOrdered, initialPlayer, bestPartner);
            playersOrdered.Remove(bestOpponents[0]);
            playersOrdered.Remove(bestOpponents[1]);
            var p1 = initialPlayer;
            var p2 = bestPartner;
            var p3 = bestOpponents[0];
            var p4 = bestOpponents[1];
            var match = new SuggestedMatch(p1, p2, p3, p4);
            remainingPlayers = playersOrdered;
            return match;
        }

        private static Player FindBestPartner(List<Player> playersOrdered, Player player)
        {
            var potentialPartners = new Dictionary<Player, float>();
            var maxIndex = Math.Min(playersOrdered.Count - 1, MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO - 1);
            for (int i = 0; i < maxIndex; i++)
            {
                if (playersOrdered.Count < i)
                {
                    break;
                }

                var playerToConsider = playersOrdered[i];
//                var score = GetPartnerSuitabilityScore(playerToConsider, player);
                var score = GetPartnerSuitabilityScoreWithBands(playerToConsider, player);
                potentialPartners.Add(playerToConsider, score);
            }

            var orderedPartners = potentialPartners.OrderBy(kvp => kvp.Value);
            var bestPartner = orderedPartners.First();
            var bestPartnerScore = bestPartner.Value;
            var allMatchingBestPartners = orderedPartners.TakeWhile(kvp => kvp.Value == bestPartnerScore).ToList();
            allMatchingBestPartners.Shuffle();
            return allMatchingBestPartners.First().Key;
        }

        private static List<Player> FindBestOpponents(List<Player> playersOrdered, Player player1, Player player2)
        {
            var potentialOpponents = new Dictionary<Player, float>();
            var numTocheck = Math.Min(playersOrdered.Count, MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO);
            for (int i = 0; i < numTocheck; i++)
            {
                if (playersOrdered.Count < i)
                {
                    break;
                }

                var playerToConsider = playersOrdered[i];
                var score = GetOpponentSuitabilityScore(playerToConsider, player1, player2);
                potentialOpponents.Add(playerToConsider, score);
            }

            var orderedOpponents = potentialOpponents.OrderBy(kvp => kvp.Value).ToList();
            var bestOpponent = orderedOpponents.First();
            var bestOpponentScore = bestOpponent.Value;
            var allMatchingBestOpponents = orderedOpponents.TakeWhile(kvp => kvp.Value == bestOpponentScore).ToList();
            allMatchingBestOpponents.Shuffle();
            var firstOpponent = allMatchingBestOpponents.First();
            if (allMatchingBestOpponents.Count > 1)
            {
                var secondOpponent = allMatchingBestOpponents[1];
                return new List<Player>
                {
                    firstOpponent.Key,
                    secondOpponent.Key
                };
            }
            else
            {
                var secondOpponent = orderedOpponents[1];
                return new List<Player>
                {
                    firstOpponent.Key,
                    secondOpponent.Key
                };
            }
        }

        private static float GetOpponentSuitabilityScore(Player playerToConsider, Player opponent1, Player opponent2)
        {
            // Consider how many times you've played together
            // Consider how many times you've partnered
            // Consider skill difference
            var opp1SkillDiff = playerToConsider.GetScoreForHandicapDifference(opponent1.Handicap);
            var opponent1Score = playerToConsider.GetScoreIfTheyPlayAgainst(opponent1);
            var opp2SkillDiff = playerToConsider.GetScoreForHandicapDifference(opponent2.Handicap);
            var opponent2Score = playerToConsider.GetScoreIfTheyPlayAgainst(opponent2);

            var opp1SkillScoreWeighted = opp1SkillDiff * Weights.SkillDifferenceForOpponent;
            var opp1ScoreWeighted = opponent1Score * Weights.OpponentVariation;
            var opp2SkillScoreWeighted = opp2SkillDiff * Weights.SkillDifferenceForOpponent;
            var opp2ScoreWeighted = opponent2Score * Weights.OpponentVariation;

            return opp1SkillScoreWeighted + opp1ScoreWeighted + opp2SkillScoreWeighted + opp2ScoreWeighted;
        }

        private static float GetPartnerSuitabilityScore(Player p1, Player p2)
        {
            // Consider how many times you've played together
            // Consider how many times you've partnered
            // Consider skill difference
            var skillDifference = p1.GetScoreForHandicapDifference(p2.Handicap);
            var partnerScore = p1.GetScoreIfTheyPlayWithPartner(p2);

            var skillScoreWeighted = skillDifference * Weights.SkillDifferenceForPartner;
            var partnerScoreWeighted = partnerScore * Weights.PartnerVariation;
            return skillScoreWeighted + partnerScoreWeighted;
        }

        private static float GetPartnerSuitabilityScoreWithBands(Player p1, Player p2)
        {
            // Consider how many times you've played together
            // Consider how many times you've partnered
            // Consider skill difference
            var skillDifference = p1.GetScoreForHandicapDifference(p2.Handicap);
            var skillDifferenceBanded = skillDifference;
            if (skillDifference < Weights.MinHandicapDifferenceToBand)
            {
                skillDifferenceBanded = 0;
            }

            var partnerScore = p1.GetScoreIfTheyPlayWithPartner(p2);

            var skillScoreWeighted = skillDifferenceBanded * Weights.SkillDifferenceForPartner;
            var partnerScoreWeighted = partnerScore * Weights.PartnerVariation;
            return skillScoreWeighted + partnerScoreWeighted;
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