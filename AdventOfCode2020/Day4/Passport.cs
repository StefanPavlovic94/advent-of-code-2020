using System.Collections.Generic;

namespace AdventOfCode2020.Day4
{
    public class Passport 
    { 
        public IEnumerable<PassportField> Fields { get; }

        public Passport(IEnumerable<PassportField> Fields)
        {
            this.Fields = Fields;
        }
    }
}
