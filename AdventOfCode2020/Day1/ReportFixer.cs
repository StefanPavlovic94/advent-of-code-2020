using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class ReportFixer
    {
        private IEnumerable<int> input;

        public ReportFixer(IEnumerable<int> input)
        {
            this.input = input.OrderBy(i => i);
        }

        public Result<Pair> FindSumPair(int sum)
        {
            if (sum % 2 == 0 && input.Where(i => i == (sum / 2)).Count() > 1)
            {
                return new Pair(sum / 2, sum / 2);
            }

            var firstHalf = input.Where(i => i < sum / 2).ToList();
            var secondHalf = input.Where(i => i >= (sum / 2) && i <= sum).ToList();

            var result = firstHalf.Where(i => secondHalf.Contains(sum - i)).ToList();

            if (!result.Any()) return Result<Pair>.NotFound();

            return new Pair(result.First(), sum - result.First());
        }

        public Result<Triplet> FindSumTriplet(int sum)
        {
            var result = input.Select(value => new { value, pairResult = FindSumPair(sum - value) })
                        .Where(valuePairResult => valuePairResult.pairResult.Status == ResultStatus.Ok && valuePairResult.pairResult.Value.IsInCollection(input))
                        .Select(valuePairResultPair => new Triplet(valuePairResultPair.value, valuePairResultPair.pairResult.Value.X, valuePairResultPair.pairResult.Value.Y))
                        .FirstOrDefault();

            return result != null 
                ? Result<Triplet>.Success(result) 
                : Result<Triplet>.NotFound();
        }
    }
}