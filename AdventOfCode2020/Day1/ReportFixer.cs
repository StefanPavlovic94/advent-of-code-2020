using AdventOfCode2020.Extensions;
using Ardalis.Result;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class ReportFixer
    {
        private IEnumerable<int> input { get; }

        public ReportFixer(IEnumerable<int> input)
        {
            if (input == null)
            {
                throw new ReportsNullException();
            }

            this.input = input.OrderBy(i => i);
        }

        public Result<Pair> FindSumPair(int sum)
        {
            if (sum % 2 == 0 && input.Where(i => i == (sum / 2)).Count() > 1)
            {
                return new Pair(sum / 2);
            }

            var secondHalf = GetSecondHalf(input, sum);
            var firstHalf = GetFirstHalf(input, sum);

            var result = firstHalf
                .Where(i => secondHalf.Contains(sum - i))
                .ToList();

            if (!result.Any()) 
            {
                return Result<Pair>.NotFound(); 
            }

            var firstResult = result.First();
            return new Pair(firstResult, sum - firstResult);
        }

        public Result<Triplet> FindSumTriplet(int sum)
        {
            var result = input
                    .Select(value => FindSumPair(sum - value))
                    .Where(result => result.IsSuccess() && result.Value.IsInCollection(input))
                    .Select(result => result.Value)
                    .Select(pair => new Triplet(sum - (pair.Sum), pair.X, pair.Y))
                    .FirstOrDefault();

            return result != null 
                ? Result<Triplet>.Success(result) 
                : Result<Triplet>.NotFound();
        }

        private List<int> GetFirstHalf(IEnumerable<int> input, int sum)
            => input.Where(i => i <= sum / 2).ToList();

        private List<int> GetSecondHalf(IEnumerable<int> input, int sum)
            => input.Where(i => i > sum / 2).ToList();
    }
}