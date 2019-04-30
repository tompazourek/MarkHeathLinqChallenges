using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MarkHeathLinqChallenges
{
    /// <summary>
    /// https://markheath.net/post/lunchtime-linq-challenge
    /// </summary>
    public static class LinqChallenge1Solution
    {
        #region Problem 1

        public static string SolveProblem1(string input)
        {
            var inputItems = input.Split(new [] { ", " }, StringSplitOptions.None);
            var outputItems = inputItems.Select((x, i) => $"{i + 1}. {x}");
            var output = string.Join(", ", outputItems);
            return output;
        }

        #endregion

        #region Problem 2

        public static string SolveProblem2(string input, DateTime now)
        {
            var inputItems = input.Split(new[] { "; " }, StringSplitOptions.None);

            const string dateFormat = "dd/MM/yyyy";
            var culture = CultureInfo.InvariantCulture;

            (string name, DateTime dateOfBirth) parsePlayer(string x)
            {
                var parts = x.Split(new[] { ", " }, StringSplitOptions.None);
                var name = parts[0];
                var dateOfBirth = DateTime.ParseExact(parts[1], dateFormat, culture);
                return (name, dateOfBirth);
            }

            int getAge(DateTime dateOfBirth)
            {
                var yearDifference = now.Year - dateOfBirth.Year;
                if (now.Month > dateOfBirth.Month)
                    return yearDifference;

                if (now.Month == dateOfBirth.Month && now.Day >= dateOfBirth.Day)
                    return yearDifference;

                return yearDifference - 1;
            }

            string formatPlayer((string name, DateTime dateOfBirth) x) 
                => x.name + ", " + x.dateOfBirth.ToString(dateFormat, culture) + $" (age {getAge(x.dateOfBirth)})";

            var inputPlayers = inputItems.Select(parsePlayer);
            var outputPlayers = inputPlayers.OrderByDescending(x => x.dateOfBirth);
            var outputItems = outputPlayers.Select(formatPlayer);
            var output = string.Join("; ", outputItems);
            return output;
        }

        public class Problem2Player
        {
            public Problem2Player(string name, DateTime dateOfBirth)
            {
                Name = name;
                DateOfBirth = dateOfBirth;
            }

            public string Name { get; }
            public DateTime DateOfBirth { get; }

            public int GetAge(DateTime now)
            {
                var yearDifference = now.Year - DateOfBirth.Year;
                if (now.Month > DateOfBirth.Month)
                    return yearDifference;

                if (now.Month == DateOfBirth.Month && now.Day >= DateOfBirth.Day)
                    return yearDifference;

                return yearDifference - 1;
            }

            protected bool Equals(Problem2Player other) => string.Equals(Name, other.Name) && DateOfBirth.Equals(other.DateOfBirth);

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Problem2Player) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ DateOfBirth.GetHashCode();
                }
            }
        }

        #endregion

        #region Problem 3

        public static string SolveProblem3(string input)
        {
            var inputItems = input.Split(',');

            const string timeFormat = @"m\:ss";
            var culture = CultureInfo.InvariantCulture;

            var inputTimeSpans = inputItems.Select(x => TimeSpan.ParseExact(x, timeFormat, culture));
            var outputTimeSpan = inputTimeSpans.Aggregate(TimeSpan.Zero, (item, result) => result + item);
            
            var output = outputTimeSpan.ToString(timeFormat, culture);
            return output;
        }

        #endregion

        #region Problem 4

        public static IEnumerable<string> SolveProblem4(int inputX, int inputY)
        {
            var sequenceX = Enumerable.Range(0, inputX);
            var sequenceY = Enumerable.Range(0, inputY);

            var output = sequenceX.SelectMany(x => sequenceY.Select(y => $"{x},{y}"));
            return output;
        }

        #endregion

        #region Problem 5

        public static string SolveProblem5(string input)
        {
            const string timeFormat = @"mm\:ss";
            var culture = CultureInfo.InvariantCulture;

            var inputItems = input.Split(',');
            var inputTimes = inputItems.Select(x => TimeSpan.ParseExact(x, timeFormat, culture)).ToList();
            var inputTimesHead = inputTimes.Take(1);
            var inputTimesTail = inputTimes.Skip(1);

            var outputTimes = inputTimesHead.Concat(inputTimes.Zip(inputTimesTail, (x, y) => y - x));
            var outputItems = outputTimes.Select(x => x.ToString(timeFormat, culture));
            var output = string.Join(",", outputItems);
            return output;
        }

        #endregion

        #region Problem 6

        public static string SolveProblem6(string input)
        {
            var inputItems = input.Split(',').Select(x => x.Split('-').Select(int.Parse).ToArray());

            var outputItems = inputItems
                .SelectMany(x => x.Length == 1
                    ? new[] { x[0] }
                    : Enumerable.Range(x[0], x[1] - x[0] + 1));

            var output = string.Join(",", outputItems.Select(x => x.ToString()));
            return output;
        }

        #endregion
    }
}

