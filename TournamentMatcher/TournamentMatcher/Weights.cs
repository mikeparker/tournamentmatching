namespace TournamentMatcher
{
    internal class Weights
    {
        public static float SkillDifferenceForPartner = 1.0f;
        public static float PartnerVariation = 2.0f;
        public static float OpponentVariation = 1.0f;
        public static float SkillDifferenceForOpponent = 1.0f;

        public static float MinHandicapDifferenceToBand = 30f; // Since differences are squared this means 5 is ok but 6 is not
    }
}