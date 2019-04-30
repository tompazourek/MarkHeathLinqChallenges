using Xunit;

namespace MarkHeathLinqChallenges.Tests
{
    public class LinqChallenge3Tests
    {
        [Fact]
        public void Problem1()
        {
            const string input = "1,2,1,1,0,3,1,0,0,2,4,1,0,0,0,0,2,1,0,3,1,0,0,0,6,1,3,0,0,0";
            const int expectedOutput = 4;
            var actualOutput = LinqChallenge3Solution.SolveProblem1(input);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem2()
        {
            const string input = "4♣ 5♦ 6♦ 7♠ 10♥;10♣ Q♥ 10♠ Q♠ 10♦;6♣ 6♥ 6♠ A♠ 6♦;2♣ 3♥ 3♠ 2♠ 2♦;2♣ 3♣ 4♣ 5♠ 6♠";
            const string expectedOutput = "10♣ Q♥ 10♠ Q♠ 10♦;2♣ 3♥ 3♠ 2♠ 2♦";
            var actualOutput = LinqChallenge3Solution.SolveProblem2(input);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem3()
        {
            const string expectedOutput = "Tuesday,Wednesday,Friday,Saturday,Sunday,Monday,Wednesday,Thursday,Friday,Saturday";
            var actualOutput = LinqChallenge3Solution.SolveProblem3();

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem4()
        {
            const string dictionary = "parts,traps,arts,rats,starts,tarts,rat,art,tar,tars,stars,stray";
            const string input = "star";
            const string expectedOutput = "arts,rats,tars";
            var actualOutput = LinqChallenge3Solution.SolveProblem4(dictionary, input);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem5()
        {
            const string input = "Santi Cazorla, Per Mertesacker, Alan Smith, Thierry Henry, Alex Song, Paul Merson, Alexis Sánchez, Robert Pires, Dennis Bergkamp, Sol Campbell";
            const string expectedOutput = "Santi Cazorla, Sol Campbell; Per Mertesacker, Paul Merson; Alan Smith, Alex Song, Alexis Sánchez";
            var actualOutput = LinqChallenge3Solution.SolveProblem5(input);

            Assert.Equal(expectedOutput, actualOutput);
        }
        
        [Fact]
        public void Problem6()
        {
            const string input = "0:00:00-0:00:05;0:55:12-1:05:02;1:37:47-1:37:51";
            const string expectedOutput = "0:00:05-0:55:12;1:05:02-1:37:47;1:37:51-2:00:00";
            var actualOutput = LinqChallenge3Solution.SolveProblem6(input);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}