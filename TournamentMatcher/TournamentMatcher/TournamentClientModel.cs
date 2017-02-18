using System;
using System.Collections.Generic;
using TournamentMatcher.Models;

namespace TournamentMatcher
{
    public class TournamentClientModel
    {
        public TournamentClientModel()
        {
            PlayersBindingList = new SortableBindingList<Player>();
        }

        public List<Player> PlayersInTournament { get; private set; }
        public List<CompletedTournamentRound> CompletedTournamentRounds { get; private set; }
        public SortableBindingList<Player> PlayersBindingList { get; private set; }

        public List<Player> AllPossiblePlayers { get; private set; }

        public void SetPlayersInTournament(List<Player> players)
        {
            PlayersInTournament = players;
            PlayersBindingList.Clear();
            foreach (var player in players)
            {
                PlayersBindingList.Add(player);
            }
        }

        public void LoadPlayersFromFile(string filepath)
        {
            List<Player> results;
            try
            {
                results = HandicapFileParser.ParseFile(filepath);
            }
            catch (Exception)
            {
                results = new List<Player>();
            }

            AllPossiblePlayers = results;
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
