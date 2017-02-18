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
            var maxIndex = Math.Min(playersOrdered.Count - 1, Weights.MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO - 1);
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
                if (scoreForMostBalancedGameYouCanMake > Weights.HandicapDifferenceBetweenTeamsToRetry)
                {
                    partnerSuitabilityScore += scoreForMostBalancedGameYouCanMake * scoreForMostBalancedGameYouCanMake;
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
            var team1handicap = player.Handicap + playerToConsider.Handicap;
            var playersCopy = players.ToList();
            playersCopy.Remove(playerToConsider);

            var opp1 = playersCopy[0];
            var opp2 = playersCopy[1];

            var team2handicap = opp1.Handicap + opp2.Handicap;
            return (int)Math.Abs(team1handicap - team2handicap);
        }

        public static List<Player> FindBestOpponents(List<Player> playersOrdered, Player player1, Player player2)
        {
            var potentialOpponents = new Dictionary<Player, float>();
            var numTocheck = Math.Min(playersOrdered.Count, Weights.MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO);
            for (int i = 0; i < numTocheck; i++)
            {
                if (playersOrdered.Count < i)
                {
                    break;
                }

                var playerToConsider = playersOrdered[i];
                var score = playerToConsider.GetOpponentSuitabilityScoreWithBands(player1, player2);
                potentialOpponents.Add(playerToConsider, score);
            }

            var firstOpponent = GetRandomPlayerFromBestGroup(potentialOpponents);
            potentialOpponents.Remove(firstOpponent.Key);

            // Find partner
            var newScores = AddScoreForPartnersWhoHavePlayedTogether(potentialOpponents, firstOpponent.Key);

            var secondOpponent = GetRandomPlayerFromBestGroup(newScores);

            return new List<Player>
            {
                firstOpponent.Key,
                secondOpponent.Key
            };
        }

        public static KeyValuePair<Player, float> GetRandomPlayerFromBestGroup(Dictionary<Player, float> players)
        {
            var playersOrdered = players.OrderBy(kvp => kvp.Value).ToList();
            var bestScore = playersOrdered.First().Value;
            var bestPlayers = playersOrdered.TakeWhile(kvp => kvp.Value == bestScore).ToList();
            bestPlayers.Shuffle();
            var randomPlayer = bestPlayers.First();
            return randomPlayer;
        }

        public static Dictionary<Player, float> AddScoreForPartnersWhoHavePlayedTogether(Dictionary<Player, float> potentialPartners, Player p1)
        {
            var retval = new Dictionary<Player, float>();
            foreach (var kvp in potentialPartners)
            {
                var p2 = kvp.Key;
                if (p2 == p1)
                {
                    retval.Add(p2, kvp.Value);
                }

                //                var partnerScore = GetBandedPartnerSkillDiff(p1, p2);
                var partnerScore = p1.GetScoreIfIPlayWithPartner(p2);
                retval.Add(p2, kvp.Value + partnerScore);
            }

            return retval;
        }
    }
}