using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Policy
    {
        List<int> Positions { get; }
        public char Character { get; }

        public Policy(
            List<int> positions,
            char character)
        {
            Positions = positions;
            Character = character;
        }

        public bool IsValidPassword(string password)
        {
            if (password == null) return false;

            return password.Where((character, i) => Positions.Contains(i + 1) && character == Character).Count() == 1;
        }
    }
}
