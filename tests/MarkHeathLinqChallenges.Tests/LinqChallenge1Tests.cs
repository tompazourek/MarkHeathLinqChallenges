using System;
using System.Collections.Generic;
using System.Linq;
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
            var now = new DateTime(2018, 07, 22);

            IList<LinqChallenge1Solution.Problem2Player> expectedOutput = new []
            {
                new LinqChallenge1Solution.Problem2Player ("Luke Shaw", new DateTime(1995, 07, 12)),
                new LinqChallenge1Solution.Problem2Player ("Gaston Ramirez", new DateTime(1990, 12, 02)),
                new LinqChallenge1Solution.Problem2Player ("Adam Lallana", new DateTime(1988, 05, 10)),
                new LinqChallenge1Solution.Problem2Player ("Jason Puncheon", new DateTime(1986, 06, 26)),
                new LinqChallenge1Solution.Problem2Player ("Jos Hooiveld", new DateTime(1983, 04, 22)),
                new LinqChallenge1Solution.Problem2Player ("Kelvin Davis", new DateTime(1976, 09, 29)),
            };
            var expectedAges = new[] { 23, 27, 30, 32, 35, 41 };
            
            var actualOutput = LinqChallenge1Solution.SolveProblem2(input).ToList();
            var actualAges = actualOutput.Select(x => x.GetAge(now)).ToList();

            Assert.Equal(expectedOutput, actualOutput);
            Assert.Equal(expectedAges, actualAges);
        }

        [Fact]
        public void Problem3()
        {
            const string input = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            var expectedOutput = TimeSpan.FromSeconds(2303);

            var actualOutput = LinqChallenge1Solution.SolveProblem3(input);

            Assert.Equal(expectedOutput, actualOutput);
        }
        
        [Fact]
        public void Problem4()
        {
            const int inputX = 3;
            const int inputY = 3;
            var expectedOutput = new []
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
            var expectedOutput = new []
            {
                TimeSpan.FromSeconds(45),
                TimeSpan.FromSeconds(47),
                TimeSpan.FromSeconds(46),
                TimeSpan.FromSeconds(43),
                TimeSpan.FromSeconds(43),
                TimeSpan.FromSeconds(47),
                TimeSpan.FromSeconds(48),
                TimeSpan.FromSeconds(42),
                TimeSpan.FromSeconds(46),
                TimeSpan.FromSeconds(48),
            };

            var actualOutput = LinqChallenge1Solution.SolveProblem5(input);

            Assert.Equal(expectedOutput, actualOutput);
        }
        
        [Fact]
        public void Problem6()
        {
            const string input = "2,5,7-10,11,17-18";
            var expectedOutput = new [] { 2, 5, 7, 8, 9, 10, 11, 17, 18 }.ToList();

            var actualOutput = LinqChallenge1Solution.SolveProblem6(input).ToList();

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}