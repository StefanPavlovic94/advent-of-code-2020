using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class PathFinder
    {

        Map map;

        public PathFinder(List<string> rows)
        {
            map = new Map(rows);
        }

        public int CountThrees(List<Move> moves)
        {
            var characters = new List<char>();
            var processMap = true;

            while (processMap)
            {
                var character = map.ApplyMoves(moves);
                characters.Add(character.Item2);
                processMap = character.Item1;
            }

            return characters.Where(c => c == '#').Count();
        }

    }

}
