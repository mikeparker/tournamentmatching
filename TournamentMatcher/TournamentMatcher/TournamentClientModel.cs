using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TournamentMatcher.Models;

namespace TournamentMatcher
{
    public class TournamentClientModel
    {
        private List<Player> allPossiblePlayers = new List<Player>();
        private List<CompletedTournamentRound> completedTournamentRounds = new List<CompletedTournamentRound>();

        public List<Player> AllPossiblePlayers
        {
            get { return this.allPossiblePlayers; }
        }

        public void LoadPlayersFromFile(string filepath)
        {
            List<Player> results;
            try
            {
                results = HandicapFileParser.ParseFile(filepath);
            }
            catch (Exception e)
            {
                results = new List<Player>();
            }

            this.allPossiblePlayers = results;
        }
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
