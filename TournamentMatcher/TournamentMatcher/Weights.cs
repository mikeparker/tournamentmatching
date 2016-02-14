namespace TournamentMatcher
{
    internal class Weights
    {
        public static float SkillDifferenceForPartner = 1.0f;
        public static float PartnerVariation = 3.0f;
        public static float OpponentVariation = 2.0f;
        public static float SkillDifferenceForOpponent = 1.0f;

        public static float MinHandicapDifferenceToBand = 30f; // Since differences are squared this means 5 is treated as 0 but 6 is not
        public static float MinHandicapDifferenceForOpponentsToBand = 50f; // Since differences are squared this means 5 is treated as 0 but 6 is not
        public static double HandicapDifferenceBetweenTeamsToRetry = 7.0f;
        }
}