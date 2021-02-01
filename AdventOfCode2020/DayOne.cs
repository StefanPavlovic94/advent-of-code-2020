using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public static class DayOne
    {
        public static Tuple<int, int> FindSumPair(IEnumerable<int> input, int sum)
        {
            var orderedInput = input.OrderBy(i => i);
            var firstHalf = orderedInput.TakeWhile(i => i < sum / 2).ToList();
            var secondHalf = orderedInput.SkipWhile(i => i >= sum / 2 && i < sum).ToList();

            var result = firstHalf.Where(i => secondHalf.Contains(sum - i)).ToList();

            if (!result.Any()) return null;

            return new Tuple<int, int>(result.Single(), sum - result.Single());

        }

        public static Tuple<int, int, int> FindSumTriplet(IEnumerable<int> input, int sum)
        {
            var orderedInput = input.OrderByDescending(i => i).ToList();

            foreach (var item in orderedInput)
            {
                var res = FindSumPair(orderedInput, sum - item);

                if (res?.Item2 != null && orderedInput.Contains(res.Item1) && orderedInput.Contains(res.Item2))
                {
                    return new Tuple<int, int, int>(item, res.Item1, res.Item2);
                }
            }

            throw new ArgumentException();
        }
    }
}
