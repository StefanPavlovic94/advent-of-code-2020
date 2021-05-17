using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day5
{

    public class Pass
    {
        public ImmutableList<Direction> Directions { get; private set; }

        public Pass(string primitivePass)
        {
            Directions = primitivePass.Select(CharToDirection).ToImmutableList();
        }

        private Direction CharToDirection(char primitiveDirection) 
        {
            switch (primitiveDirection)
            {
                case 'F': return Direction.RowsLowerHalf;
                case 'B': return Direction.RowsUpperHalf;
                case 'L': return Direction.ColumnsLowerHalf;
                case 'R': return Direction.ColumnsUpperHalf;
                default:
                    throw new ArgumentException($"{primitiveDirection} is not known direction");
            }
        }
    }
}
