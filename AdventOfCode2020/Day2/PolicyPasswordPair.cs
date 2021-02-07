namespace AdventOfCode2020
{
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