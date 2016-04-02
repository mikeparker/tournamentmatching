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

        public TournamentClientModel()
        {
            allPossiblePlayers = LoadPlayersFromTextFile();
        }

        private List<Player> LoadPlayersFromTextFile()
        {
            var fileString = FileTools.ReadFileString(@"D:\crossways-handicaps.txt");
            var strings = fileString.Split('\n');
            var results = strings.Select(ParsePlayer).ToList();

            return results;
        }

        public Player ParsePlayer(string inputString)
        {
            var splitString = inputString.Split(',');
            if (splitString.Length < 2)
            {
                return null;
            }

            var name = splitString[0];
            var handicap = float.Parse(splitString[1]);
            var player = new Player(name, handicap);
            return player;
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
