using AdventOfCode2020;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var delimiters = new char[] { '\r', '\n' };

            var input = Resources.DayOne.Split(delimiters)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim());

            DayOne(input);
        }

        public static void DayOne(IEnumerable<string> input)
        {
            var reportInput = input.Select(i => int.Parse(i)).ToList();

            var reportFixer = new ReportFixer(reportInput);

            var resultPair = reportFixer.FindSumPair(2020).Multiply();
            var resultTriplet = reportFixer.FindSumTriplet(2020).Multiply();
        }

        public static void DayTwo(IEnumerable<string> input)
        {
            var passwordPolicyProcessor = new PolicyPasswordProcessor();
            var policyPasswords = passwordPolicyProcessor.ReadPolicyPasswordPairs(input);
            var validPasswords = passwordPolicyProcessor.GetValidPasswords(policyPasswords);
        }

        public static void DayThree(IEnumerable<string> input)
        {
            var threeCharacter = '#';
            var listOfRows = new Map(input.ToList());
            var path1ThreesCount = listOfRows.CountCharacter(new List<Move>() { new Move(Direction.Right, 1), new Move(Direction.Down, 1) }, threeCharacter);
            var path2ThreesCount = listOfRows.CountCharacter(new List<Move>() { new Move(Direction.Right, 3), new Move(Direction.Down, 1) }, threeCharacter);
            var path3ThreesCount = listOfRows.CountCharacter(new List<Move>() { new Move(Direction.Right, 5), new Move(Direction.Down, 1) }, threeCharacter);
            var path4ThreesCount = listOfRows.CountCharacter(new List<Move>() { new Move(Direction.Right, 7), new Move(Direction.Down, 1) }, threeCharacter);
            var path5ThreesCount = listOfRows.CountCharacter(new List<Move>() { new Move(Direction.Right, 1), new Move(Direction.Down, 2) }, threeCharacter);

            var threeCount = path1ThreesCount * path2ThreesCount * path3ThreesCount * path4ThreesCount * path5ThreesCount;
        }
    }
}