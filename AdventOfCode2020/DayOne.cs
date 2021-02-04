using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class DayOne
    {
        private IEnumerable<int> input;

        public DayOne(IEnumerable<int> input)
        {
            this.input = input.OrderBy(i => i);
        }

        public Tuple<int, int> FindSumPair(int sum)
        {
            if (sum % 2 == 0 && input.Where( i => i == (sum / 2)).Count() > 1) 
            {
                return new Tuple<int, int>(sum / 2, sum / 2);
            }

            var firstHalf = input.Where(i => i < sum / 2).ToList();
            var secondHalf = input.Where(i => i >= (sum / 2) && i <= sum).ToList();

            var result = firstHalf.Where(i => secondHalf.Contains(sum - i)).ToList();

            if (!result.Any()) return null;

            return new Tuple<int, int>(result.First(), sum - result.First());

        }

        public Tuple<int, int, int> FindSumTriplet(int sum)
        {
            foreach (var item in input)
            {
                var res = FindSumPair(sum - item);

                if (res?.Item2 != null && input.Contains(res.Item1) && input.Contains(res.Item2))
                {
                    return new Tuple<int, int, int>(item, res.Item1, res.Item2);
                }
            }

            throw new ArgumentException();
        }
    }
}
