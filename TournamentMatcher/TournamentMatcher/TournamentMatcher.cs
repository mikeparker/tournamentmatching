using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TournamentMatcher
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
            return SuggestedTournament.CreateRandomTournament(players, numRounds, 0.0f, 0.0f, 30.0f);
        }
    }
}
