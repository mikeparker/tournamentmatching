using System.Collections.Generic;
using TournamentMatcher.Models;

namespace TournamentMatcher.GamePicking
{
    public class TournamentMatcher
    {
        private readonly List<Player> players;

        public TournamentMatcher(List<Player> players)
        {
            this.players = players;
        }

        public SuggestedTournament CreateRandomisedTournament(int numRounds)
        {
            return SuggestedTournament.CreateRandomTournament(this.players, numRounds, Weights.Instance.PartnerVariation, Weights.Instance.OpponentVariation, Weights.Instance.MinHandicapDifferenceToBand);
        }
    }
}
