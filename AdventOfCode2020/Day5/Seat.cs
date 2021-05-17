namespace AdventOfCode2020.Day5
{
    public class Seat 
    {
        public uint SeatId { get; }

        public Seat(uint row, uint column)
        {
            SeatId = CalculateSeatId(row, column);
        }

        private uint CalculateSeatId(uint row, uint column)
            => row * 8 + column;

    }
}
