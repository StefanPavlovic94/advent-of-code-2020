using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Pair
    {
        public int X { get; }
        public int Y { get; }

        public Pair(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int Multiply() 
        {
            return X * Y;
        }

        public bool IsInCollection(IEnumerable<int> collection)
         => collection.Contains(X) && collection.Contains(Y);
    }
}