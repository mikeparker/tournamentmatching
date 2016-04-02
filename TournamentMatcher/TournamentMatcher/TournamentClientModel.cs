using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentMatcher.Models;

namespace TournamentMatcher
{
    public class TournamentClientModel
    {
        private List<Player> allPossiblePlayers = new List<Player>();
        private List<CompletedTournamentRound> completedTournamentRounds = new List<CompletedTournamentRound>(); 
    }

    public class CompletedTournamentRound
    {
        // each round has a number of games
        // and a number of people that sat out
        private List<Player> playersThatSatOut = new List<Player>();
        private List<CompletedGame> CompletedGame = new List<CompletedGame>();
    }

    public class CompletedGame
    {
        private Team team1;
        private Team team2;
        private GameScore gameScore;
    }

    public class GameScore
    {
        public readonly int Team1Score;
        public readonly int Team2Score;

        public GameScore(int team1Score, int team2Score)
        {
            this.Team1Score = team1Score;
            this.Team2Score = team2Score;
        }
    }
}
