namespace TournamentMatcher.GamePicking
{
    public class Weights
    {
        public int PartnerVariation = 200;
        public int OpponentVariation = 200;
        public float SkillDifferenceForPartner = 0.0f;
        public float SkillDifferenceForOpponent = 0.0f;
        public float BalancedTeams = 1.0f;

        public float MinHandicapDifferenceToBand = 1f; //squared
        public float MinHandicapDifferenceForOpponentsToBand = 1f; //squared
        public double HandicapDifferenceBetweenTeamsToRetry = 0.0f;
        public int MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO = 35;

        public static Weights Instance = new Weights();

    }
}