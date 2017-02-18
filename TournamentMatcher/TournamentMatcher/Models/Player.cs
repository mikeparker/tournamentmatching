using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TournamentMatcher.GamePicking;

namespace TournamentMatcher.Models
{
    [DebuggerDisplay("{Name}")]
    public class Player
    {
        public string Name { get; private set; }
        public float Handicap { get; private set; }
        public int NumberOfGamesSatOutSoFar { get; set; }
        public Dictionary<Player, int> PartnersSoFar { get; private set; } 
        public Dictionary<Player, int> OpponentsSoFar { get; private set; } 

        public Player(string name, float handicap)
        {
            this.Name = name;
            this.Handicap = handicap;
            this.PartnersSoFar = new Dictionary<Player, int>();
            this.OpponentsSoFar = new Dictionary<Player, int>();
        }

        public float GetScoreForHandicapDifference(float otherHandicap)
        {
            var scoreForHandicapDifference = GetDifferenceInHandicap(otherHandicap);

            return scoreForHandicapDifference * scoreForHandicapDifference;
        }

        public float GetDifferenceInHandicap(float otherHandicap)
        {
            return Math.Abs(this.Handicap - otherHandicap);
        }

        public void AddOpponents(Player player1, Player player2)
        {
            AddOpponent(player1);
            AddOpponent(player2);
        }

        private void AddOpponent(Player player)
        {
            if (this.OpponentsSoFar.ContainsKey(player))
            {
                this.OpponentsSoFar[player]++;
            }
            else
            {
                this.OpponentsSoFar.Add(player, 1);
            }
        }

        public void AddPartner(Player player)
        {
            if (this.PartnersSoFar.ContainsKey(player))
            {
                this.PartnersSoFar[player]++;
            }
            else
            {
                this.PartnersSoFar.Add(player, 1);
            }
        }

        public void AddOpponents(Team opposingTeam)
        {
            this.AddOpponent(opposingTeam.Player1);
            this.AddOpponent(opposingTeam.Player2);
        }

        public float GetScoreForPartnersSoFar()
        {
            return this.PartnersSoFar.Sum(kvp => (kvp.Value - 1) * (kvp.Value - 1)); // no idea if this is good
        }

        public float GetScoreForOpponentsSoFar()
        {
            return this.OpponentsSoFar.Sum(kvp => (kvp.Value - 1) * (kvp.Value - 1)); // no idea if this is good
        }

        public float GetScoreIfIPlayWithPartner(Player p2)
        {
            var x = GetTimesPartnered(p2);

            return x * x * Weights.PartnerVariation;
        }

        public float GetPartnerSuitabilityScoreWithBands(Player p2)
        {
            // Consider how many times you've played together
            // Consider how many times you've partnered
            // Consider skill difference

            var skillDifferenceBanded = GetBandedPartnerSkillDiff(p2);

            var partnerScore = GetScoreIfIPlayWithPartner(p2);

            var skillScoreWeighted = skillDifferenceBanded * Weights.SkillDifferenceForPartner;
            return skillScoreWeighted + partnerScore;
        }

        public float GetOpponentSuitabilityScoreWithBands(Player opponent1, Player opponent2)
        {
            // Consider how many times you've played together
            // Consider how many times you've partnered
            // Consider skill difference
            var skillDiff = GetBandedOpponentsSkillDiff(opponent1.Handicap); // Only use the initial players handicap so you dont get too extreme games
            var opponent1Score = GetScoreIfTheyPlayAgainst(opponent1);
            var opponent2Score = GetScoreIfTheyPlayAgainst(opponent2);

            var skillScoreWeighted = skillDiff * Weights.SkillDifferenceForOpponent;
            var opp1ScoreWeighted = opponent1Score * Weights.OpponentVariation;
            var opp2ScoreWeighted = opponent2Score * Weights.OpponentVariation;

            return skillScoreWeighted + opp1ScoreWeighted + skillScoreWeighted + opp2ScoreWeighted;
        }

        public float GetOpponentSuitabilityScore(Player opponent1, Player opponent2)
        {
            // Consider how many times you've played together
            // Consider how many times you've partnered
            // Consider skill difference
            var opp1SkillDiff = GetScoreForHandicapDifference(opponent1.Handicap);
            var opponent1Score = GetScoreIfTheyPlayAgainst(opponent1);
            var opp2SkillDiff = GetScoreForHandicapDifference(opponent2.Handicap);
            var opponent2Score = GetScoreIfTheyPlayAgainst(opponent2);

            var opp1SkillScoreWeighted = opp1SkillDiff * Weights.SkillDifferenceForOpponent;
            var opp1ScoreWeighted = opponent1Score * Weights.OpponentVariation;
            var opp2SkillScoreWeighted = opp2SkillDiff * Weights.SkillDifferenceForOpponent;
            var opp2ScoreWeighted = opponent2Score * Weights.OpponentVariation;

            return opp1SkillScoreWeighted + opp1ScoreWeighted + opp2SkillScoreWeighted + opp2ScoreWeighted;
        }

        public float GetBandedPartnerSkillDiff(Player p2)
        {
            var skillDifference = GetScoreForHandicapDifference(p2.Handicap);
            var skillDifferenceBanded = skillDifference;
            if (skillDifference < Weights.MinHandicapDifferenceToBand)
            {
                skillDifferenceBanded = 0;
            }

            return skillDifferenceBanded;
        }

        public float GetBandedOpponentsSkillDiff(float p2Handicap)
        {
            var skillDifference = GetScoreForHandicapDifference(p2Handicap);
            var skillDifferenceBanded = skillDifference;
            if (skillDifference < Weights.MinHandicapDifferenceForOpponentsToBand)
            {
                skillDifferenceBanded = 0;
            }

            return skillDifferenceBanded;
        }

        public float GetPartnerSuitabilityScore(Player p2)
        {
            // Consider how many times you've played together
            // Consider how many times you've partnered
            // Consider skill difference
            var skillDifference = GetScoreForHandicapDifference(p2.Handicap);
            var partnerScore = GetScoreIfIPlayWithPartner(p2);

            var skillScoreWeighted = skillDifference * Weights.SkillDifferenceForPartner;
            return skillScoreWeighted + partnerScore;
        }

        public float GetScoreIfTheyPlayAgainst(Player opponent)
        {
            var x = GetTimesOpponent(opponent);

            return x * x;
        }

        private float GetTimesPartnered(Player p2)
        {
            if (this.PartnersSoFar.ContainsKey(p2))
            {
                return this.PartnersSoFar[p2];
            }

            return 0;
        }

        private float GetTimesOpponent(Player p2)
        {
            if (this.OpponentsSoFar.ContainsKey(p2))
            {
                return this.OpponentsSoFar[p2];
            }

            return 0;
        }

        public string GetNameWithHandicapString()
        {
            return this.Name + " (" + this.Handicap + ")";
        }
    }
}