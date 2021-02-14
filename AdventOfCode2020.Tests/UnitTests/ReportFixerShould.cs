using Ardalis.Result;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2020.Tests.UnitTests
{
    public class ReportFixerShould
    {
        [Fact]
        public void ThrowExceptionForNullReports() 
            => Assert.Throws<ReportsNullException>(() => new ReportFixer(null));



        [Theory]
        [MemberData(nameof(OnePossibleResultCollections))]
        public void FindExpectedPair_WhenOnlyOnePossibleSolution(IEnumerable<int> report, int sum, Pair expectedPair) 
        {
           var result = new ReportFixer(report)
                .FindSumPair(sum);

            Assert.Equal(ResultStatus.Ok, result.Status);
            Assert.Equal(expectedPair, result.Value);
        }

        public void ReturnResultNotFound_WhenThereIsNoSolution(IEnumerable<int> report, int sum) 
        {
        
        }

        public static IEnumerable<object[]> OnePossibleResultCollections() {
            yield return new object[] { new List<int> { -1, 1, 2, 3, 5, 10 }, 5 , new Pair(2, 3)};
            yield return new object[] { new List<int> { -20, 300, 400, 500, 600 }, 1000, new Pair(400, 600) };
            yield return new object[] { new List<int> { 1, 2, 2, 3 }, 4, new Pair(2, 2) };
            yield return new object[] { new List<int> { -2, 6, 2, 3 }, 4, new Pair(-2, 6) };
        }

        public static IEnumerable<object[]> NoResultCollections()
        {
            yield return new object[] { new List<int> { -1, 1, 2, 3, 5, 10 }, 6 };
            yield return new object[] { new List<int> { -20, 300, 300, 500, 600 }, 1000 };
            yield return new object[] { new List<int> { -1, -2, 1, 2, 19 }, 4 };
        }
    }
}
