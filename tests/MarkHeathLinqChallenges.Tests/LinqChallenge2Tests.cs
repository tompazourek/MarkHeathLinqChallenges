using System.Linq;
using Xunit;

namespace MarkHeathLinqChallenges.Tests
{
    public class LinqChallenge2Tests
    {
        [Fact]
        public void Problem1()
        {
            const string input = "10,5,0,8,10,1,4,0,10,1";
            const int expectedOutput = 48;
            var actualOutput = LinqChallenge2Solution.SolveProblem1(input);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem2()
        {
            const string input = "c6";
            var expectedOutput = new []
            {
                "b7",
                "a8",

                "d5",
                "e4",
                "f3",
                "g2",
                "h1",

                "d7",
                "e8",

                "b5",
                "a4",
            };
            var actualOutput = LinqChallenge2Solution.SolveProblem2(input);

            Assert.Equal(expectedOutput.OrderBy(x => x), actualOutput.OrderBy(x => x));
        }

        [Fact]
        public void Problem3()
        {
            const string input = "0,6,12,18,24,30,36,42,48,53,58,63,68,72,77,80,84,87,90,92,95,96,98,99,99,100,99,99,98,96,95,92,90,87,84,80,77,72,68,63,58,53,48,42,36,30,24,18,12,6,0,-6,-12,-18,-24,-30,-36,-42,-48,-53,-58,-63,-68,-72,-77,-80,-84,-87,-90,-92,-95,-96,-98,-99,-99,-100,-99,-99,-98,-96,-95,-92,-90,-87,-84,-80,-77,-72,-68,-63,-58,-53,-48,-42,-36,-30,-24,-18,-12,-6";
            var expectedOutput = new[] {
                "24",
                "53",
                "77",
                "92",
                "99",
                "96",
                "84",
                "63",
                "36",
                "6",
                "-24",
                "-53",
                "-77",
                "-92",
                "-99",
                "-96",
                "-84",
                "-63",
                "-36",
                "-6",
            };

            var actualOutput = LinqChallenge2Solution.SolveProblem3(input);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem4()
        {
            const string input = "Yes,Yes,No,Yes,No,Yes,No,No,No,Yes,Yes,Yes,Yes,No,Yes,No,No,Yes,Yes";
            const int expectedOutput = 3;
            var actualOutput = LinqChallenge2Solution.SolveProblem4(input);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem5()
        {
            const string input = "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog";
            var expectedOutput = new []
            {
                new LinqChallenge2Solution.Problem5Count("Dog", 5),
                new LinqChallenge2Solution.Problem5Count("Cat", 3),
                new LinqChallenge2Solution.Problem5Count("Other", 4),
            };
            var actualOutput = LinqChallenge2Solution.SolveProblem5(input);

            Assert.Equal(expectedOutput, actualOutput);
        }
        
        [Fact]
        public void Problem6()
        {
            const string input = "A5B10CD3";
            const string expectedOutput = "AAAAABBBBBBBBBBCDDD";
            var actualOutput = LinqChallenge2Solution.SolveProblem6(input);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}