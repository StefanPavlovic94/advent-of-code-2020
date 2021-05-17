using System;

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
}
