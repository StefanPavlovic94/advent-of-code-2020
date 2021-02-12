using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day4
{
    public class PassportBuilder
    {
        public const string BirthYear = "byr";
        public const string IssueYear = "iyr";
        public const string ExpirationYear = "eyr";
        public const string Height = "hgt";
        public const string HairColor = "hcl";
        public const string EyeColor = "ecl";
        public const string PassportId = "pid";
        public const string CountryId = "cid";

        private IPasswordPolicy Policy { get; set; }

        private PassportBuilder(IPasswordPolicy Policy)
        {
            this.Policy = Policy;
        }

        public static PassportBuilder Create(IPasswordPolicy policy)
        {
            if (policy == null) return null;
            return new PassportBuilder(policy);
        }

        public Passport CreatePassport(IEnumerable<PassportField> fields) 
        {
            return Policy.IsValidPassword(fields)
                ? new Passport(fields)
                : null;
        }

    }
}
