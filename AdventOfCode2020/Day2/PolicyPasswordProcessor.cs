using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class PolicyPasswordProcessor
    {
        public IEnumerable<PolicyPasswordPair> ReadPolicyPasswordPairs(IEnumerable<string> rawPolicyPasswords)
            => rawPolicyPasswords.Select(rawPolicyPassword => rawPolicyPassword.Split(' '))
            .Select(rawPolicyPassword => new PolicyPasswordPair(Transform(rawPolicyPassword), rawPolicyPassword.LastOrDefault()));

        public int GetValidPasswords(IEnumerable<PolicyPasswordPair> policyPasswordPairs)
            => policyPasswordPairs.Where(p => p.Policy.IsValidPassword(p.Password)).Count();


        private static Policy Transform(string[] input)
        {
            if (input == null || !input.Any())
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(input[0].Split('-').FirstOrDefault(), out int position1)
                || !int.TryParse(input[0].Split('-').LastOrDefault(), out int position2))
            {
                throw new ArgumentException();
            }

            var character = input[1].FirstOrDefault();

            return new Policy(new List<int>() { position1, position2 }, character);
        }
    }
}
