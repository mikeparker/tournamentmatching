namespace TournamentMatcher.GamePicking
{
    internal class Weights
    {
        public static float PartnerVariation = 20.0f;
        public static float OpponentVariation = 10.0f;
        public static float SkillDifferenceForPartner = 1.0f;
        public static float SkillDifferenceForOpponent = 1.0f;

        public static float MinHandicapDifferenceToBand = 1f; // Since differences are squared this means 5 is treated as 0 but 6 is not
        public static float MinHandicapDifferenceForOpponentsToBand = 1f; // Since differences are squared this means 5 is treated as 0 but 6 is not
        public static double HandicapDifferenceBetweenTeamsToRetry = 7.0f;
        public const int MAX_PLAYERS_BELOW_TOP_TO_STRETCH_TO = 15;
    }
}