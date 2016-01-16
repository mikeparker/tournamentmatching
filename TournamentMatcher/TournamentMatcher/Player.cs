using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentMatcher
{
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

        public float GetDevHandicap(float avgHandicap)
        {
            return Math.Abs(Handicap - avgHandicap);
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

        public float GetPartnerScore()
        {
            return this.PartnersSoFar.Sum(kvp => (kvp.Value - 1) * (kvp.Value - 1)); // no idea if this is good
        }

        public float GetOpponentScore()
        {
            return this.OpponentsSoFar.Sum(kvp => (kvp.Value - 1) * (kvp.Value - 1)); // no idea if this is good
        }
    }
}