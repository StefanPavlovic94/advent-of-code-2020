using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Map
    {
        private readonly List<string> rows;
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height => rows.Count();

        public Map(List<string> rows)
        {
            this.rows = rows;
            X = Y = 0;
        }

        public Tuple<bool, char> ApplyMoves(List<Move> moves)
        {
            return moves.Select(m => ApplyMove(m)).ToList().Last();
        }

        public Tuple<bool, char> ApplyMove(Move move)
        {
            try
            {
                switch (move.Direction)
                {
                    case Direction.Down:
                        Y = Y + move.Skip;
                        return new Tuple<bool, char>(true, rows[Y][X]);
                    case Direction.Right:

                        if (X + move.Skip < rows[Y].Count())
                        {
                            X = X + move.Skip;
                        }
                        else
                        {
                            X = (X + move.Skip) - rows[Y].Count();
                        }

                        return new Tuple<bool, char>(true, rows[Y][X]);
                    default:
                        throw new NotImplementedException(); ;
                }
            }
            catch
            {

                return new Tuple<bool, char>(false, ' ');
            }
        }

    }

}
