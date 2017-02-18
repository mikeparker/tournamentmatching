using System;
using System.Collections.Generic;
using System.Linq;
using TournamentMatcher.Models;

namespace TournamentMatcher
{
    public static class HandicapFileParser
    {
        public static List<Player> ParseFile(string filepath)
        {
            var fileString = FileTools.ReadFileString(filepath);
            var strings = fileString.Split('\n');
            var results = strings.Select(ParsePlayer).Where(p => p != null).ToList();
            return results;
        }

        public static Player ParsePlayer(string inputString)
        {
            var splitString = inputString.Split(',');
            if (splitString.Length < 2)
            {
                return null;
            }

            var name = splitString[0];
            var handicap = Single.Parse(splitString[1]);
            var player = new Player(name, handicap);
            return player;
        }
    }
}