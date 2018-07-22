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

        public static IEnumerable<Problem2Player> SolveProblem2(string input)
        {
            var inputItems = input.Split(new[] { "; " }, StringSplitOptions.None);

            var outputItems = inputItems
                .Select(x => x.Split(new[] { ", " }, StringSplitOptions.None))
                .Select(x => new Problem2Player(x[0], DateTime.ParseExact(x[1], "dd/MM/yyyy", CultureInfo.InvariantCulture)));

            var output = outputItems.OrderByDescending(x => x.DateOfBirth);
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

        public static TimeSpan SolveProblem3(string input)
        {
            var inputItems = input.Split(',');
            var inputTimeSpans = inputItems.Select(x => TimeSpan.ParseExact(x, @"m\:ss", CultureInfo.InvariantCulture));
            var output = inputTimeSpans.Aggregate(TimeSpan.Zero, (item, result) => result + item);
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

        public static IEnumerable<TimeSpan> SolveProblem5(string input)
        {
            var inputItems = input.Split(',');
            var inputTimes = inputItems.Select(x => TimeSpan.ParseExact(x, @"mm\:ss", CultureInfo.InvariantCulture)).ToList();
            var inputTimesHead = inputTimes.Take(1);
            var inputTimesTail = inputTimes.Skip(1);

            var output = inputTimesHead.Concat(inputTimes.Zip(inputTimesTail, (x, y) => y - x));
            return output;
        }

        #endregion

        #region Problem 6

        public static IEnumerable<int> SolveProblem6(string input)
        {
            var output = input.Split(',')
                .Select(x => x.Split('-').Select(int.Parse).ToArray())
                .SelectMany(x => x.Length == 1
                    ? new[] { x[0] }
                    : Enumerable.Range(x[0], x[1] - x[0] + 1));

            return output;
        }

        #endregion
    }
}

