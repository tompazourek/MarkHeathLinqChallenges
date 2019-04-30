using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarkHeathLinqChallenges
{
    /// <summary>
    /// https://markheath.net/post/lunchtime-linq-challenge-2
    /// </summary>
    public static class LinqChallenge2Solution
    {
        #region Problem 1

        public static int SolveProblem1(string input)
        {
            var output = input.Split(',')
                .Select(int.Parse)
                .OrderBy(x => x)
                .Skip(3)
                .Sum();

            return output;
        }

        #endregion

        #region Problem 2

        public static IEnumerable<string> SolveProblem2(string input)
        {
            string FormatPosition((int horizontal, int vertical) x)
                => new string(new [] { (char) (x.horizontal + 'a'), (char) (x.vertical + '1') });

            (int horizontal, int vertical) ParsePosition()
                => (horizontal: input[0] - 'a', vertical: input[1] - '1');

            var bishopMoveVectors = new[]
            {
                (horizontal: +1, vertical: +1),
                (horizontal: -1, vertical: +1),
                (horizontal: +1, vertical: -1),
                (horizontal: -1, vertical: -1),
            };
            
            IEnumerable<(int horizontal, int vertical)> GenerateMoves((int horizontal, int vertical) source, (int horizontal, int vertical) moveVector)
            {
                var current = source;
                while (true)
                {
                    var newHorizontal = current.horizontal + moveVector.horizontal;
                    if (newHorizontal < 0 || newHorizontal > 7)
                        yield break;

                    var newVertical = current.vertical + moveVector.vertical;
                    if (newVertical < 0 || newVertical > 7)
                        yield break;

                    yield return current = (horizontal: newHorizontal, vertical: newVertical);
                }
            }

            var inputParsed = ParsePosition();
            var moves = bishopMoveVectors.SelectMany(x => GenerateMoves(inputParsed, x));
            var outputFormatted = moves.Select(FormatPosition);
            return outputFormatted;
        }

        #endregion

        #region Problem 3

        public static IEnumerable<string> SolveProblem3(string input)
        {
            var output = input.Split(',')
                .Select((x, i) => (item: x, index: i))
                .Where(x => x.index % 5 == 4)
                .Select(x => x.item);

            return output;
        }

        #endregion

        #region Problem 4

        public static int SolveProblem4(string input)
        {
            return input.Split(',').Aggregate(0, (result, x) => x == "Yes" ? result + 1 : result - 1);
        }

        #endregion
        
        #region Problem 5

        public static IEnumerable<Problem5Count> SolveProblem5(string input)
        {
            var output = input.Split(',')
                .GroupBy(x => x == "Dog" || x == "Cat" ? x : "Other")
                .Select(x => new Problem5Count(x.Key, x.Count()));

            return output;
        }

        public class Problem5Count
        {
            public Problem5Count(string animal, int count)
            {
                Animal = animal;
                Count = count;
            }

            public string Animal { get; }
            public int Count { get; }

            protected bool Equals(Problem5Count other) => string.Equals(Animal, other.Animal) && Count == other.Count;

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Problem5Count) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Animal != null ? Animal.GetHashCode() : 0) * 397) ^ Count;
                }
            }
        }

        #endregion

        #region Problem 6

        public static string SolveProblem6(string input)
        {
            var output = Regex.Replace(input, @"(?<Letter>[A-Z])(?<Count>[0-9]*)", match =>
            {
                var groupCountValue = match.Groups["Count"].Value;
                if (groupCountValue == string.Empty)
                    return match.Value;

                var groupLetterValue = match.Groups["Letter"];

                var letter = groupLetterValue.Value[0];
                var count = int.Parse(groupCountValue);
                return new string(letter, count);
            });

            return output;
        }

        #endregion
    }
}

