using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TournamentMatcher
{
    [DebuggerDisplay("{ToString()}")]
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

        public override string ToString()
        {
            return "Match:" + Team1.Player1.Name + " + " + Team1.Player2.Name + " vs " + Team2.Player1.Name + " + " + Team2.Player2.Name + " | Hcap: " + HandicapDifference;
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

            var initialPlayer = playersOrdered[0];
            playersOrdered.RemoveAt(0);

            var bestPartner = FindBestPartner(playersOrdered, initialPlayer);
            playersOrdered.Remove(bestPartner);

            List<Player> bestOpponents;
            var match = MakeMatch(playersOrdered, initialPlayer, bestPartner, out bestOpponents);

            match.Finalise();

            playersOrdered.Remove(bestOpponents[0]);
            playersOrdered.Remove(bestOpponents[1]);
            remainingPlayers = playersOrdered;
            return match;
        }

        private static SuggestedMatch MakeMatch(List<Player> playersOrdered, Player initialPlayer, Player bestPartner, out List<Player> bestOpponents)
        {
//            for (int j = 0; j < 5; j++)
//            {
                for (int i = 0; i < 10; i++)
                {
                    SuggestedMatch match;
                    bestOpponents = FindBestOpponentsAndMakeMatch(playersOrdered, initialPlayer, bestPartner, out match);
                    if (match.HandicapDifference < Weights.HandicapDifferenceBetweenTeamsToRetry)
                    {
                        return match;
                    }

                    Debug.WriteLine("Skipping game " + match.ToString());

                    if (i == 9)
                    {
                        Debug.WriteLine("Giving up attempting to find sensible opponents for partnership: " + match.Team1);
                        return match;
//                        break;
                    }
                }
//            }
            bestOpponents = new List<Player>();
            return null;
        }

        private void Finalise()
        {
            this.Team1.Finalise();
            this.Team2.Finalise();
            Team1.AddOpponents(Team2);
        }

        private static List<Player> FindBestOpponentsAndMakeMatch(List<Player> playersOrdered, Player initialPlayer, Player bestPartner, out SuggestedMatch match)
        {
            var bestOpponents = FindBestOpponents(playersOrdered, initialPlayer, bestPartner);
            var p1 = initialPlayer;
            var p2 = bestPartner;
            var p3 = bestOpponents[0];
            var p4 = bestOpponents[1];
            match = new SuggestedMatch(p1, p2, p3, p4);
            return bestOpponents;
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
                var scoreForMostBalancedGameYouCanMake = GetScoreForMostBalancedGame(player, playerToConsider, playersOrdered.ToList());
                if (scoreForMostBalancedGameYouCanMake > Weights.HandicapDifferenceBetweenTeamsToRetry)
                {
                    score += scoreForMostBalancedGameYouCanMake;
                    Debug.WriteLine("Adding points to stupid partnership " + player.Name + " + " + playerToConsider.Name);
                }

                potentialPartners.Add(playerToConsider, score);
            }

            var orderedPartners = potentialPartners.OrderBy(kvp => kvp.Value);
            var bestPartner = orderedPartners.First();
            var bestPartnerScore = bestPartner.Value;
            var allMatchingBestPartners = orderedPartners.TakeWhile(kvp => kvp.Value == bestPartnerScore).ToList();
            allMatchingBestPartners.Shuffle();
            
            return allMatchingBestPartners.First().Key;
        }

        private static int GetScoreForMostBalancedGame(Player player, Player playerToConsider, List<Player> playersCopy)
        {
            var team1handicap = player.Handicap + playerToConsider.Handicap;
            playersCopy.Remove(playerToConsider);

            var opp1 = playersCopy[0];
            var opp2 = playersCopy[1];

            var team2handicap = opp1.Handicap + opp2.Handicap;
            return (int)Math.Abs(team1handicap - team2handicap);
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
                var score = GetOpponentSuitabilityScoreWithBands(playerToConsider, player1, player2);
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

        private static KeyValuePair<Player, float> GetRandomPlayerFromBestGroup(Dictionary<Player, float> players)
        {
            var playersOrdered = players.OrderBy(kvp => kvp.Value).ToList();
            var bestScore = playersOrdered.First().Value;
            var bestPlayers = playersOrdered.TakeWhile(kvp => kvp.Value == bestScore).ToList();
            bestPlayers.Shuffle();
            var randomPlayer = bestPlayers.First();
            return randomPlayer;
        }

        private static Dictionary<Player, float> AddScoreForPartnersWhoHavePlayedTogether(Dictionary<Player, float> potentialPartners, Player p1)
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
                var partnerScore = p1.GetScoreIfTheyPlayWithPartner(p2);
                retval.Add(p2, kvp.Value + partnerScore);
            }

            return retval;
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

        private static float GetOpponentSuitabilityScoreWithBands(Player playerToConsider, Player opponent1, Player opponent2)
        {
            // Consider how many times you've played together
            // Consider how many times you've partnered
            // Consider skill difference
            var skillDiff = GetBandedOpponentsSkillDiff(playerToConsider, opponent1.Handicap); // Always use the initial players handicap so you dont get too extreme games
            var opponent1Score = playerToConsider.GetScoreIfTheyPlayAgainst(opponent1);
            var opponent2Score = playerToConsider.GetScoreIfTheyPlayAgainst(opponent2);

            var skillScoreWeighted = skillDiff * Weights.SkillDifferenceForOpponent;
            var opp1ScoreWeighted = opponent1Score * Weights.OpponentVariation;
            var opp2ScoreWeighted = opponent2Score * Weights.OpponentVariation;

            return skillScoreWeighted + opp1ScoreWeighted + skillScoreWeighted + opp2ScoreWeighted;
        }

        private static float GetPartnerSuitabilityScore(Player p1, Player p2)
        {
            // Consider how many times you've played together
            // Consider how many times you've partnered
            // Consider skill difference
            var skillDifference = p1.GetScoreForHandicapDifference(p2.Handicap);
            var partnerScore = p1.GetScoreIfTheyPlayWithPartner(p2);

            var skillScoreWeighted = skillDifference * Weights.SkillDifferenceForPartner;
            return skillScoreWeighted + partnerScore;
        }

        private static float GetPartnerSuitabilityScoreWithBands(Player p1, Player p2)
        {
            // Consider how many times you've played together
            // Consider how many times you've partnered
            // Consider skill difference

            var skillDifferenceBanded = GetBandedPartnerSkillDiff(p1, p2);

            var partnerScore = p1.GetScoreIfTheyPlayWithPartner(p2);

            var skillScoreWeighted = skillDifferenceBanded * Weights.SkillDifferenceForPartner;
            return skillScoreWeighted + partnerScore;
        }

        private static float GetBandedPartnerSkillDiff(Player p1, Player p2)
        {
            var skillDifference = p1.GetScoreForHandicapDifference(p2.Handicap);
            var skillDifferenceBanded = skillDifference;
            if (skillDifference < Weights.MinHandicapDifferenceToBand)
            {
                skillDifferenceBanded = 0;
            }

            return skillDifferenceBanded;
        }

        private static float GetBandedOpponentsSkillDiff(Player p1, float p2handicap)
        {
            var skillDifference = p1.GetScoreForHandicapDifference(p2handicap);
            var skillDifferenceBanded = skillDifference;
            if (skillDifference < Weights.MinHandicapDifferenceForOpponentsToBand)
            {
                skillDifferenceBanded = 0;
            }

            return skillDifferenceBanded;
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