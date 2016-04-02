namespace TournamentMatcher.Models
{
    public class Team
    {
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        private readonly float totalHandicap;

        public Team(Player p1, Player p2)
        {
            this.Player1 = p1;
            this.Player2 = p2;
            this.totalHandicap = p1.Handicap + p2.Handicap;
        }

        public void Finalise()
        {
            this.Player1.AddPartner(this.Player2);
            this.Player2.AddPartner(this.Player1);
        }

        public float CompareHandicapWith(Team otherTeam)
        {
            return this.totalHandicap - otherTeam.totalHandicap;
        }

        public override string ToString()
        {
            return this.Player1.Name + " + " + this.Player2.Name;
        }

        public float GetStdDevHandicap(float avgHandicap)
        {
            var x = this.Player1.GetDifferenceInHandicap(avgHandicap);
            var y = this.Player2.GetDifferenceInHandicap(avgHandicap);
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