using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day5
{
    public class Plane 
    {
        private readonly uint numberOfRows;
        private readonly uint numberOfColumns;

        public Plane(uint numberOfRows, uint numberOfColumns)
        {
            this.numberOfRows = numberOfRows;
            this.numberOfColumns = numberOfColumns;
        }

        public Seat ApplyPass(Pass pass) 
        {          
            var rowsArea = new Area(0, numberOfRows);
            var columnsArea = new Area(0, numberOfColumns);

            foreach (var direction in pass.Directions)
            {
                (rowsArea, columnsArea) = ApplyDirection(direction, rowsArea, columnsArea);
            }

            if (rowsArea.HigherBound != rowsArea.LowerBound && columnsArea.HigherBound != columnsArea.LowerBound) 
            {
                throw new Exception();
            }

            return new Seat(rowsArea.HigherBound, columnsArea.LowerBound);

        }

        private (Area rowsArea, Area columnsArea) ApplyDirection(Direction direction, Area rowsArea, Area columnsArea) 
        {
            switch (direction)
            {
                case Direction.RowsLowerHalf:
                    return (rowsArea.LowerHalf(), columnsArea);
                case Direction.RowsUpperHalf:
                    return (rowsArea.UpperHalf(), columnsArea);
                case Direction.ColumnsLowerHalf:
                    return (rowsArea, columnsArea.LowerHalf());
                case Direction.ColumnsUpperHalf:
                    return (rowsArea, columnsArea.UpperHalf());
                default:
                    throw new ArgumentException();
            }
        }
    }

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

    public enum Direction 
    {
        RowsLowerHalf,
        RowsUpperHalf,
        ColumnsLowerHalf,
        ColumnsUpperHalf
    }
}
