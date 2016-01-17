using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TournamentMatcher
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
            PartnersSoFar = new Dictionary<Player, int>();
            OpponentsSoFar = new Dictionary<Player, int>();
        }

        public float GetScoreForHandicapDifference(float otherHandicap)
        {
            var scoreForHandicapDifference = GetDifferenceInHandicap(otherHandicap);

            return scoreForHandicapDifference * scoreForHandicapDifference;
        }

        public float GetDifferenceInHandicap(float otherHandicap)
        {
            return Math.Abs(Handicap - otherHandicap);
        }

        public void AddOpponents(Player player1, Player player2)
        {
            AddOpponent(player1);
            AddOpponent(player2);
        }

        private void AddOpponent(Player player)
        {
            if (OpponentsSoFar.ContainsKey(player))
            {
                OpponentsSoFar[player]++;
            }
            else
            {
                OpponentsSoFar.Add(player, 1);
            }
        }

        public void AddPartner(Player player)
        {
            if (PartnersSoFar.ContainsKey(player))
            {
                PartnersSoFar[player]++;
            }
            else
            {
                PartnersSoFar.Add(player, 1);
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

        public float GetScoreIfTheyPlayWithPartner(Player p2)
        {
            var x = GetTimesPartnered(p2);

            return x * x;
        }

        public float GetScoreIfTheyPlayAgainst(Player opponent)
        {
            var x = GetTimesOpponent(opponent);

            return x * x;
        }

        private float GetTimesPartnered(Player p2)
        {
            if (PartnersSoFar.ContainsKey(p2))
            {
                return PartnersSoFar[p2];
            }

            return 0;
        }

        private float GetTimesOpponent(Player p2)
        {
            if (OpponentsSoFar.ContainsKey(p2))
            {
                return OpponentsSoFar[p2];
            }

            return 0;
        }
    }
}