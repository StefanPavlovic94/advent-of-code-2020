namespace AdventOfCode2020.Day5
{
    public class Area 
    {
        public uint LowerBound { get; }
        public uint HigherBound { get; }

        public Area(uint lowerBound, uint higherBound)
        {
            LowerBound = lowerBound;
            HigherBound = higherBound;
        }

        public Area LowerHalf() 
        {
            return new Area(LowerBound, LowerBound + (HigherBound - LowerBound) / 2);
        }

        public Area UpperHalf() 
        {
            return new Area(LowerBound + (HigherBound + 1 - LowerBound) / 2, HigherBound);
        }
    }
}
