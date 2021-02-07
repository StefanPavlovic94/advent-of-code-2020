namespace AdventOfCode2020
{
    public class Triplet
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Triplet(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int Multiply()
        {
            return X * Y * Z;
        }
    }
}