namespace TournamentMatcher.GamePicking
{
    public class Weights
    {
        public int PartnerVariation = 100;
        public int OpponentVariation = 30;
        public float SkillDifferenceForPartner = 1.0f;
        public float SkillDifferenceForOpponent = 1.0f;

        public float MinHandicapDifferenceToBand = 1f; // Since differences are squared this means 5 is treated as 0 but 6 is not
        public float MinHandicapDifferenceForOpponentsToBand = 1f; // Since differences are squared this means 5 is treated as 0 but 6 is not
        public double HandicapDifferenceBetweenTeamsToRetry = 7.0f;
        public int MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO = 15;

        public static Weights Instance = new Weights();
    }
}