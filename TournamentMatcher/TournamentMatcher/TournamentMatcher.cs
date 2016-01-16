using System;
using System.Collections.Generic;
using System.Linq;
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
            return SuggestedTournament.CreateRandomTournament(players, numRounds);
        }
    }


    public class SuggestedTournament
    {
        // a tournament has multiple rounds
        // each round has a set of matches
        // each match has 2 teams
        // each team has 2 players
        public List<SuggestedTournamentRound> SuggestedTournamentRounds { get; private set; }

        public SuggestedTournament()
        {
            this.SuggestedTournamentRounds = new List<SuggestedTournamentRound>();
        }

        public static SuggestedTournament CreateRandomTournament(List<Player> players, int numRounds)
        {
            var newTournament = new SuggestedTournament();
            var numSittingOutPerRound = players.Count%4;

            // if theres 6 players and 1 round then 2 players will sit out 1 round and 4 0, total = 2 / 6
            // if theres 6 players and 2 rounds then 4 players will sit out 1 round and 2 0, total = 4/6

//            var numTotalGamesSatOutPerPlayer = (numSittingOutPerRound*numRounds)/players.Count;
            for (int i = 0; i < numRounds; i++)
            {
                var currentRound = SuggestedTournamentRound.CreateRandomRound(players);
                newTournament.AddRound(currentRound);
            }

            return newTournament;
        }

        private void AddRound(SuggestedTournamentRound currentRound)
        {
            SuggestedTournamentRounds.Add(currentRound);
        }

        public float GetScore()
        {
            // Todo: Differences in skill level DONE
            // TODO: Players don't sit out too many times
            // TODO: Players dont play with the same partner
            // TODO: Players dont play in the same game as others
            // TODO: Differences in skill level between partners
            var totalScoreForAllRounds = SuggestedTournamentRounds.Sum(r => r.GetScore());
            return totalScoreForAllRounds/SuggestedTournamentRounds.Count;
        }
    }

    public class Player
    {
        public string Name { get; private set; }
        public float Handicap { get; private set; }
        public int NumberOfGamesSatOutSoFar { get; set; }

        public Player(string name, float handicap)
        {
            this.Name = name;
            this.Handicap = handicap;
        }

        public float GetDevHandicap(float avgHandicap)
        {
            return Math.Abs(Handicap - avgHandicap);
        }
    }
}
