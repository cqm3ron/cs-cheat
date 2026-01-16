using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheat
{
    internal class NaturalLanguageParser
    {
        public NaturalLanguageParser() { }

        private static readonly Dictionary<string, Rank> RankMap = new()
        {
                { "2", Rank.two }, { "two", Rank.two },
                { "3", Rank.three }, { "three", Rank.three },
                { "4", Rank.four }, { "four", Rank.four },
                { "5", Rank.five }, { "five", Rank.five },
                { "6", Rank.six }, { "six", Rank.six },
                { "7", Rank.seven }, { "seven", Rank.seven },
                { "8", Rank.eight }, { "eight", Rank.eight },
                { "9", Rank.nine }, { "nine", Rank.nine },
                { "10", Rank.ten }, { "ten", Rank.ten },
                { "j", Rank.jack }, { "jack", Rank.jack },
                { "q", Rank.queen }, { "queen", Rank.queen },
                { "k", Rank.king }, { "king", Rank.king },
                { "a", Rank.ace }, { "ace", Rank.ace }
        };
        
        private static readonly Dictionary<string, Suit> SuitMap = new()
        {
                { "h", Suit.heart }, { "heart", Suit.heart }, { "hearts", Suit.heart }, { "♥", Suit.heart },
                { "d", Suit.diamond }, { "diamond", Suit.diamond }, { "diamonds", Suit.diamond }, { "♦", Suit.diamond },
                { "s", Suit.spade }, { "spade", Suit.spade }, { "spades", Suit.spade }, { "♠", Suit.spade },
                { "c", Suit.club }, { "club", Suit.club }, { "clubs", Suit.club }, { "♣", Suit.club}
        };

        public bool TryParseCard(string input, out Card? card)
        {
            card = null;
            var tokens = Normalise(input).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Rank? rank = null;
            Suit? suit = null;

            foreach (var token in tokens)
            {
                if (rank == null && TryFindMatch<Rank>(token, RankMap, out var r))
                {
                    rank = r;
                    continue;
                }

                if (suit == null && TryFindMatch<Suit>(token, SuitMap, out var s))
                {
                    suit = s;
                    continue;
                }
            }


            if (rank == null || suit == null) return false;

            card = new Card(rank.Value, suit.Value);
            return true;
        }

        private bool TryFindMatch<T>(string token, Dictionary<string, T> map, out T value)
        {
            if (map.TryGetValue(token, out value))
                return true;

            var prefixMatches = map.Keys.Where(k => k.StartsWith(token)).OrderByDescending(k => k.Length).ToList();

            if (prefixMatches.Any())
            {
                value = map[prefixMatches[0]];
                return true;
            }
            else
            {
                return TryFuzzyMatch(token, map, out value);
            }
        }


        private string Normalise(string input)
        {
            return input.ToLower().Replace("of", "").Replace(",", "").Replace(".", "").Trim();
        }

        private int CalculateLevenshteinDistance(string item1, string item2) // https://gist.github.com/Davidblkx/e12ab0bb2aff7fd8072632b396538560
        {                                                                    // check if im ok to use this code if it isnt mine?!?!
            var item1Length = item1.Length;
            var item2Length = item2.Length;

            var matrix = new int[item1Length + 1, item2Length + 1];

            if (item1Length == 0) return item2Length;
            if (item2Length == 0) return item1Length;

            for (var i = 0; i <= item1Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= item2Length; matrix[0, j] = j++) { }

            for (var i = 1; i <= item1Length; i++)
            {
                for (var j = 1; j <= item2Length; j++)
                {
                    var cost = (item2[j - 1] == item1[i - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            return matrix[item1Length, item2Length];
        }

        private bool TryFuzzyMatch<T>(string token, Dictionary<string, T> map, out T value)
        {
            value = default!;
            const int TOLERANCE = 2;

            string? bestKey = null;
            int bestDistance = int.MaxValue;

            foreach (var key in map.Keys)
            {
                int distance = CalculateLevenshteinDistance(token, key);

                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestKey = key;
                }
            }

            if (bestKey != null && bestDistance <= TOLERANCE)
            {
                value = map[bestKey];
                return true;
            }

            return false;
        }
    }
}
