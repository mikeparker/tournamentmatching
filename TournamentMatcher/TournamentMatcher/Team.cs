namespace TournamentMatcher
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

        public void Finalise()
        {
            Player1.AddPartner(Player2);
            Player2.AddPartner(Player1);
        }

        public float CompareHandicapWith(Team otherTeam)
        {
            return totalHandicap - otherTeam.totalHandicap;
        }

        public override string ToString()
        {
            return Player1.Name + " + " + Player2.Name;
        }

        public float GetStdDevHandicap(float avgHandicap)
        {
            var x = Player1.GetDifferenceInHandicap(avgHandicap);
            var y = Player2.GetDifferenceInHandicap(avgHandicap);
            return (x + y)/2;
        }

        public void AddOpponents(Team opposingTeam)
        {
            this.Player1.AddOpponents(opposingTeam);
            this.Player2.AddOpponents(opposingTeam);
            opposingTeam.Player1.AddOpponents(this);
            opposingTeam.Player2.AddOpponents(this);
        }
    }
}