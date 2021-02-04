using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class DayTwo
    {
        public IEnumerable<PolicyPasswordPair> ReadPolicyPasswordPairs(IEnumerable<string> input)
            => input.Select(i => i.Split(' ')).Select(i => new PolicyPasswordPair(Transform(i), i.LastOrDefault()));

        public int ReturnValidPasswords(IEnumerable<PolicyPasswordPair> policyPasswordPairs) 
            => policyPasswordPairs.Where(p => p.Policy.IsValidPassword(p.Password)).Count();
        

        private static Policy Transform(string[] input)
        {
            if (!int.TryParse(input[0].Split('-').FirstOrDefault(), out int position1) 
                || !int.TryParse(input[0].Split('-').LastOrDefault(), out int position2)) 
            {
                throw new ArgumentException(); 
            }
           
            var character = input[1].FirstOrDefault();

            return new Policy(new List<int>() { position1, position2}, character);
        } 
    }

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

    public class PolicyPasswordPair
    {
        public readonly string Password;
        public Policy Policy { get; }

        public PolicyPasswordPair(Policy policy, string password)
        {
            Policy = policy;
            this.Password = password;
        }

    }
}
