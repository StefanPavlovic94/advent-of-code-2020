using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Map
    {
        private const char Three = '#';
        private List<string> rows { get; }
        private Position position { get; set; }

        public Map(List<string> rows)
        {
            this.rows = rows;
            ResetPosition();
        }

        private Result<char> ApplyMoves(IEnumerable<Move> moves)
             => moves.Select(m => ApplyMove(m)).ToList().Last();

        public Result<char> ApplyMove(Move move)
        {
            try
            {
                switch (move.Direction)
                {
                    case Direction.Down:
                        position = new Position(position.X, position.Y + move.Skip);
                        return Result<char>.Success(rows[position.Y][position.X]);

                    case Direction.Right:

                        if (position.X + move.Skip < rows[position.Y].Count())
                        {
                            position = new Position(position.X + move.Skip, position.Y);
                        }
                        else
                        {
                            position = new Position((position.X + move.Skip) - rows[position.Y].Count(), position.Y);
                        }

                        return Result<char>.Success(rows[position.Y][position.X]);

                    default:
                        throw new NotImplementedException(); ;
                }
            }
            catch
            {
                return Result<char>.Error();
            }
        }

        public int CountCharacter(IEnumerable<Move> moves, char character)
        {
            return FindPath(moves).Where(c => c == character).Count();
        }

        private List<char> FindPath(IEnumerable<Move> moves)
        {
            var characters = new List<char>();

            while (true)
            {
                var character = ApplyMoves(moves);

                if (character.Status != ResultStatus.Ok) break;

                characters.Add(character.Value);
            }

            ResetPosition();
            return characters;
        }

        private void ResetPosition()
        {
            position = new Position(0, 0);
        }
    }
}