using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TournamentMatcher.lib;
using TournamentMatcher.Models;

namespace TournamentMatcher.GamePicking
{
    public class MatchPicker
    {
        public static Player FindBestPartner(List<Player> playersOrdered, Player player)
        {
            var potentialPartnersWithSuitabilityScore = new Dictionary<Player, float>();
            var maxIndex = Math.Min(playersOrdered.Count - 1, Weights.Instance.MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO - 1);
            for (int i = 0; i < maxIndex; i++)
            {
                if (playersOrdered.Count < i)
                {
                    break;
                }

                var playerToConsider = playersOrdered[i];
                var partnerSuitabilityScore = playerToConsider.GetPartnerSuitabilityScoreWithBands(player);
                var scoreForMostBalancedGameYouCanMake = GetScoreForMostBalancedGame(player, playerToConsider, playersOrdered);

                // If the partner is suitable but you can't make a sensible game with this partnership, discourage the partnership
                if (scoreForMostBalancedGameYouCanMake > Weights.Instance.HandicapDifferenceBetweenTeamsToRetry)
                {
                    partnerSuitabilityScore += (scoreForMostBalancedGameYouCanMake * scoreForMostBalancedGameYouCanMake) * Weights.Instance.BalancedTeams;
                    Debug.WriteLine("Adding points to stupid partnership " + player.Name + " + " + playerToConsider.Name + " because there are no sensible opponents.");
                }

                potentialPartnersWithSuitabilityScore.Add(playerToConsider, partnerSuitabilityScore);
            }

            var orderedPartners = potentialPartnersWithSuitabilityScore.OrderBy(kvp => kvp.Value);
            var bestPartner = orderedPartners.First();
            var bestPartnerScore = bestPartner.Value;
            var allMatchingBestPartners = orderedPartners.TakeWhile(kvp => kvp.Value == bestPartnerScore).ToList();
            allMatchingBestPartners.Shuffle();

            return allMatchingBestPartners.First().Key;
        }

        public static int GetScoreForMostBalancedGame(Player player, Player playerToConsider, List<Player> players)
        {
            var playersCopy = players.ToList();
            playersCopy.Remove(playerToConsider);
            int lowestScore = 9999; 

            foreach (var opp1 in players)
            {
                var remainingPlayers = players.ToList();
                remainingPlayers.Remove(opp1);
                foreach (var opp2 in remainingPlayers)
                {
                    var score = GetScoreForGame(player, playerToConsider, opp1, opp2);
                    if (score == 0) return 0;
                    if (score < lowestScore)
                    {
                        lowestScore = score;
                    }
                }
            }

            return lowestScore;
        }

        public static int GetScoreForMostBalancedGame2(Player player1, Player player2, Player player3, List<Player> players)
        {
            var playersCopy = players.ToList();
            playersCopy.Remove(player3);

            var player4 = playersCopy[0];
            return GetScoreForGame(player1, player2, player3, player4);
        }

        public static int GetScoreForGame(Player player1, Player player2, Player player3, Player player4)
        {
            var team1handicap = player1.Handicap + player2.Handicap;
            var team2handicap = player3.Handicap + player4.Handicap;
            return (int)Math.Abs(team1handicap - team2handicap);
        }

        public static List<Player> FindBestOpponents(List<Player> playersOrdered, Player player1, Player player2)
        {
            var firstOpponent = GetBestFirstOpponent(playersOrdered, player1, player2);
            playersOrdered.Remove(firstOpponent);
            var secondOpponent = GetBestSecondOpponent(playersOrdered, player1, player2, firstOpponent);
            playersOrdered.Remove(secondOpponent);

            return new List<Player>
            {
                firstOpponent,
                secondOpponent,
            };
        }

        private static Player GetBestFirstOpponent(List<Player> playersOrdered, Player player1, Player player2)
        {
            var potentialOpponents = new Dictionary<Player, float>();
            var numTocheck = Math.Min(playersOrdered.Count, Weights.Instance.MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO);
            for (int i = 0; i < numTocheck; i++)
            {
                if (playersOrdered.Count < i)
                {
                    break;
                }

                var playerToConsider = playersOrdered[i];
                var score = playerToConsider.GetOpponentSuitabilityScoreWithBands(player1, player2);
                // Add points for best match
                var scoreForMostBalancedGameYouCanMake = GetScoreForMostBalancedGame2(player1, player2, playerToConsider, playersOrdered);
                score += (scoreForMostBalancedGameYouCanMake * scoreForMostBalancedGameYouCanMake) * Weights.Instance.BalancedTeams;
                potentialOpponents.Add(playerToConsider, score);
            }

            var firstOpponent = GetRandomPlayerFromBestGroup(potentialOpponents);
            return firstOpponent;
        }

        private static Player GetBestSecondOpponent(List<Player> playersOrdered, Player player1, Player player2, Player player3)
        {
            var potentialOpponents = new Dictionary<Player, float>();
            var numTocheck = Math.Min(playersOrdered.Count, Weights.Instance.MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO);
            for (int i = 0; i < numTocheck; i++)
            {
                if (playersOrdered.Count < i)
                {
                    break;
                }

                var playerToConsider = playersOrdered[i];
                var score = playerToConsider.GetOpponentSuitabilityScoreWithBands(player1, player2);
                // Add points for best match
                var handicapScore = GetScoreForGame(player1, player2, player3, playerToConsider);
                score += (handicapScore * handicapScore) * Weights.Instance.BalancedTeams;
                potentialOpponents.Add(playerToConsider, score);
            }

            var newScores = AddScoreForPartnersWhoHavePlayedTogether(potentialOpponents, player3);

            var secondOpponent = GetRandomPlayerFromBestGroup(newScores);
            return secondOpponent;
        }

        public static Player GetRandomPlayerFromBestGroup(Dictionary<Player, float> players)
        {
            var playersOrdered = players.OrderBy(kvp => kvp.Value).ToList();
            var bestScore = playersOrdered.First().Value;
            var bestPlayers = playersOrdered.TakeWhile(kvp => kvp.Value == bestScore).ToList();
            bestPlayers.Shuffle();
            var randomPlayer = bestPlayers.First();
            return randomPlayer.Key;
        }

        public static Dictionary<Player, float> AddScoreForPartnersWhoHavePlayedTogether(Dictionary<Player, float> potentialPartners, Player player)
        {
            var retval = new Dictionary<Player, float>();
            foreach (var kvp in potentialPartners)
            {
                var p2 = kvp.Key;
                if (p2 == player)
                {
                    retval.Add(p2, kvp.Value);
                }
                else
                {
                    //                var partnerScore = GetBandedPartnerSkillDiff(player, p2);
                    var partnerScore = player.GetPartnerVariationScore(p2);
                    retval.Add(p2, kvp.Value + partnerScore);
                }
            }

            return retval;
        }
    }
}