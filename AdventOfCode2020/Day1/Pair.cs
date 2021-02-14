using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Pair
    {
        public int X { get; }
        public int Y { get; }

        public int Sum => X + Y;

        public Pair(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Pair(int xy)
        {
            X = xy;
            Y = xy;
        }

        public int Multiply()
        {
            return X * Y;
        }

        public bool IsInCollection(IEnumerable<int> collection)
         => collection.Contains(X) && collection.Contains(Y);

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var pair = (Pair)obj;

            return (this.X == pair.X && this.Y == pair.Y) || (this.X == pair.Y && this.Y == this.X);
        }
    }
}