using System.Collections.Generic;

namespace AdventOfCode2020.Day4
{
    public interface IPasswordPolicy 
    {
        bool IsValidPassword(IEnumerable<PassportField> fields);
    }
}
