namespace AdventOfCode2020
{
    public class Move
    {
        public Direction Direction { get; }
        public int Skip { get; }


        public Move(Direction direction, int fields)
        {
            this.Direction = direction;
            this.Skip = fields;
        }
    }

}
