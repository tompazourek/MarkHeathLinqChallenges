using System;
using Xunit;

namespace MarkHeathLinqChallenges.Tests
{
    public class LinqChallenge1Tests
    {
        [Fact]
        public void Problem1()
        {
            const string input = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
            const string expectedOutput = "1. Davis, 2. Clyne, 3. Fonte, 4. Hooiveld, 5. Shaw, 6. Davis, 7. Schneiderlin, 8. Cork, 9. Lallana, 10. Rodriguez, 11. Lambert";
            var actualOutput = LinqChallenge1Solution.SolveProblem1(input);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem2()
        {
            const string input = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";
            const string expectedOutput = "Luke Shaw, 12/07/1995 (age 23); Gaston Ramirez, 02/12/1990 (age 27); Adam Lallana, 10/05/1988 (age 30); Jason Puncheon, 26/06/1986 (age 32); Jos Hooiveld, 22/04/1983 (age 35); Kelvin Davis, 29/09/1976 (age 41)";
            var now = new DateTime(2018, 07, 22);

            var actualOutput = LinqChallenge1Solution.SolveProblem2(input, now);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem3()
        {
            const string input = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            const string expectedOutput = "38:23";

            var actualOutput = LinqChallenge1Solution.SolveProblem3(input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem4()
        {
            const int inputX = 3;
            const int inputY = 3;
            var expectedOutput = new[]
            {
                "0,0",
                "0,1",
                "0,2",
                "1,0",
                "1,1",
                "1,2",
                "2,0",
                "2,1",
                "2,2",
            };

            var actualOutput = LinqChallenge1Solution.SolveProblem4(inputX, inputY);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem5()
        {
            const string input = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";
            const string expectedOutput = "00:45,00:47,00:46,00:43,00:43,00:47,00:48,00:42,00:46,00:48";

            var actualOutput = LinqChallenge1Solution.SolveProblem5(input);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Problem6()
        {
            const string input = "2,5,7-10,11,17-18";
            const string expectedOutput = "2,5,7,8,9,10,11,17,18";

            var actualOutput = LinqChallenge1Solution.SolveProblem6(input);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}