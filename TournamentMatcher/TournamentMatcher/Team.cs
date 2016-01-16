﻿namespace TournamentMatcher
{
    public class Team
    {
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        private readonly float totalHandicap;

        public Team(Player p1, Player p2)
        {
            Player1 = p1;
            Player2 = p2;
            totalHandicap = p1.Handicap + p2.Handicap;
        }

        public float CompareHandicapWith(Team otherTeam)
        {
            return totalHandicap - otherTeam.totalHandicap;
        }

        public float GetStdDevHandicap(float avgHandicap)
        {
            var x = Player1.GetDevHandicap(avgHandicap);
            var y = Player2.GetDevHandicap(avgHandicap);
            return (x + y)/2;
        }
    }
}