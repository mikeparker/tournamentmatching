using System;
using System.Collections.Generic;
using System.Linq;
using TournamentMatcher.GamePicking;
using TournamentMatcher.Models;

namespace TournamentMatcher
{
    public class TournamentClientModel
    {
        public TournamentClientModel()
        {
            PlayersBindingList = new SortableBindingList<Player>();
            CurrentRoundBindingList = new SortableBindingList<Match>();
            PreviousRoundsBindingList = new SortableBindingList<Match>();
            PreviousRounds = new List<TournamentRound>();
        }

        public List<Player> PlayersInTournament { get; private set; }
        public List<TournamentRound> PreviousRounds { get; private set; }
        public SortableBindingList<Player> PlayersBindingList { get; private set; }
        public SortableBindingList<Match> CurrentRoundBindingList { get; private set; }
        public SortableBindingList<Match> PreviousRoundsBindingList { get; private set; }
        public TournamentRound CurrentRound { get; private set; }

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

        public void FinaliseCurrentRoundAndGenerateNext()
        {
            var nextRound = TournamentRound.CreateIntelligentRound(PlayersBindingList.ToList());
            FinaliseCurrentRound(nextRound);
        }

        public void FinaliseCurrentRoundAndGenerateFinalRound()
        {
            var playersNeedingExtraRound = TournamentRound.GetPlayersNeedingExtraRoundAndSitOutRest(PlayersBindingList.ToList());

            var extraRound = TournamentRound.CreateIntelligentRound(playersNeedingExtraRound);
            FinaliseCurrentRound(extraRound);
        }

        private void FinaliseCurrentRound(TournamentRound nextRound)
        {
            if (this.CurrentRound != null)
            {
                this.PreviousRounds.Add(this.CurrentRound);
                foreach (var suggestedMatch in this.CurrentRound.SuggestedMatches)
                {
                    this.PreviousRoundsBindingList.Add(suggestedMatch);
                }
            }
            CurrentRound = nextRound;
            CurrentRoundBindingList.Clear();
            foreach (var suggestedMatch in CurrentRound.SuggestedMatches)
            {
                CurrentRoundBindingList.Add(suggestedMatch);
            }
        }
    }
}
