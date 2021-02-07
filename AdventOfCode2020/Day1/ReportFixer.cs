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

        public Pair FindSumPair(int sum)
        {
            if (sum % 2 == 0 && input.Where(i => i == (sum / 2)).Count() > 1)
            {
                return new Pair(sum / 2, sum / 2);
            }

            var firstHalf = input.Where(i => i < sum / 2).ToList();
            var secondHalf = input.Where(i => i >= (sum / 2) && i <= sum).ToList();

            var result = firstHalf.Where(i => secondHalf.Contains(sum - i)).ToList();

            if (!result.Any()) return null;

            return new Pair(result.First(), sum - result.First());
        }

        public Triplet FindSumTriplet(int sum)
        {
            foreach (var item in input)
            {
                var res = FindSumPair(sum - item);

                if (res != null && input.Contains(res.X) && input.Contains(res.Y))
                {
                    return new Triplet(item, res.X, res.Y);
                }
            }

            throw new ArgumentException();
        }
    }
}