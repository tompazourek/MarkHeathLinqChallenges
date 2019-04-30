using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarkHeathLinqChallenges
{
    /// <summary>
    /// https://markheath.net/post/linq-challenge-3
    /// </summary>
    public static class LinqChallenge3Solution
    {
        #region Problem 1

        public static int SolveProblem1(string input)
        {
            var inputNumbers = input.Split(',')
                .Select(int.Parse);

            var output = inputNumbers
                .Aggregate((current: 0, max: 0), (agg, x) =>
                    x == 0
                        ? (agg.current + 1, Math.Max(agg.current + 1, agg.max))
                        : (0, agg.max))
                .max;

            return output;
        }

        #endregion

        #region Problem 2

        public static string SolveProblem2(string input)
        {
            IList<(string value, char color)> parseHand(string x) =>
                x.Split(' ')
                    .Select(y => Regex.Match(y, @"^(?<Value>\d+|[JQKA])(?<Color>[♣♦♠♥])$"))
                    .Select(y => (value: y.Groups["Value"].Value, color: y.Groups["Color"].Value[0]))
                    .ToList();

            string formatHand(IList<(string value, char color)> x)
                => string.Join(" ", x.Select(y => $"{y.value}{y.color}"));

            bool isFullHouse(IList<(string value, char color)> hand)
            {
                var groups = hand
                    .GroupBy(x => x.value)
                    .Select(x => x.Count())
                    .OrderBy(x => x)
                    .ToList();

                return groups[0] == 2 && groups[1] == 3;
            }

            var inputHands = input
                .Split(';')
                .Select(parseHand);

            var outputHands = inputHands
                .Where(isFullHouse);

            var output = string.Join(";", outputHands.Select(formatHand));
            return output;
        }

        #endregion

        #region Problem 3

        public static string SolveProblem3()
        {
            var numberOfYears = 10;
            var initialYear = 2018;

            var days = Enumerable.Range(initialYear, numberOfYears)
                .Select(year => new DateTime(year, 12, 25));

            var output = string.Join(",", days.Select(x => x.DayOfWeek.ToString()));
            return output;
        }

        #endregion

        #region Problem 4

        public static string SolveProblem4(string dictionary, string input)
        {
            var dictionaryWords = dictionary.Split(',');

            bool isAnagram(string word1, string word2)
            {
                if (word1.Length != word2.Length)
                    return false;

                var word1ByLetter = word1
                    .GroupBy(x => x)
                    .ToDictionary(x => x.Key, x => x.Count());

                return word2
                    .GroupBy(x => x)
                    .All(x => word1ByLetter.ContainsKey(x.Key) && x.Count() == word1ByLetter[x.Key]);
            }

            var anagramWords = dictionaryWords.Where(x => isAnagram(x, input));

            var output = string.Join(",", anagramWords);
            return output;
        }

        #endregion

        #region Problem 5

        public static string SolveProblem5(string input)
        {
            var inputNames = input.Split(',')
                .Select(x => x.Trim());

            var namesGroupedByInitials = inputNames
                .GroupBy(x => new string(x.Split(' ').Select(y => y.First()).ToArray()))
                .Where(x => x.Count() > 1);

            var output = string.Join("; ", namesGroupedByInitials
                .Select(x => string.Join(", ", x)));

            return output;
        }

        #endregion

        #region Problem 6

        public static string SolveProblem6(string input)
        {
            const string timeFormat = @"h\:mm\:ss";
            var culture = CultureInfo.InvariantCulture;

            TimeSpan parseTime(string x)
                => TimeSpan.ParseExact(x, timeFormat, culture);

            (TimeSpan start, TimeSpan end) parseTimeRange(string x)
            {
                var regionParts = x.Split('-');
                return (start: parseTime(regionParts[0]), end: parseTime(regionParts[1]));
            }

            string formatTime(TimeSpan x)
                => x.ToString(timeFormat, culture);

            string formatTimeRange((TimeSpan start, TimeSpan end) x)
                => $@"{formatTime(x.start)}-{formatTime(x.end)}";

            var inputItems = input.Split(';');
            var inputRanges = inputItems.Select(parseTimeRange);
            
            var videoStart = TimeSpan.Zero;
            var videoEnd = TimeSpan.FromHours(2);

            var outputRanges = new[] { videoStart }
                .Concat(inputRanges.SelectMany(x => new[] { x.start, x.end }))
                .Concat(new[] { videoEnd })
                .Select((value, index) => (value: value, index: index))
                .GroupBy(x => x.index / 2, x => x.value)
                .Select(x => x.ToArray())
                .Select(x => (start: x[0], end: x[1]))
                .Where(x => x.end - x.start > TimeSpan.Zero);

            var outputItems = outputRanges
                .Select(formatTimeRange);

            var output = string.Join(";", outputItems);
            return output;
        }

        #endregion
    }
}