using AdventOfCode2020;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DayThree();

        }

        public static void DayOne() 
        {
            var delimiters = new char[] { '\r', '\n' };

            var input = Resources.DayOne.Split(delimiters)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .Select(s => int.Parse(s));
            
            var dayOne = new ReportFixer(input);

            var result = dayOne.FindSumPair(2020);
            var multipliedResult = result.Item1 * result.Item2;

            var resultTriplet = dayOne.FindSumTriplet(2020);
            var multipledTripletResult = resultTriplet.Item1 * resultTriplet.Item2 * resultTriplet.Item3;
        }

        public static void DayTwo() 
        {
            var delimiters = new char[] { '\r', '\n' };

            var input = Resources.DayTwo.Split(delimiters)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim());

            var policyPasswords = new PolicyPasswordProcessor().ReadPolicyPasswordPairs(input);
            var validPasswords = new PolicyPasswordProcessor().ReturnValidPasswords(policyPasswords);
        }

        public static void DayThree()
        {
            var delimiters = new char[] { '\r', '\n' };

            var input = Resources.DayThree.Split(delimiters)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToList();

            var path1ThreesCount = new PathFinder(input).CountThrees(new List<Move>() { new Move(Direction.Right, 1), new Move(Direction.Down, 1) });
            var path2ThreesCount = new PathFinder(input).CountThrees(new List<Move>() { new Move(Direction.Right, 3), new Move(Direction.Down, 1) });
            var path3ThreesCount = new PathFinder(input).CountThrees(new List<Move>() { new Move(Direction.Right, 5), new Move(Direction.Down, 1) });
            var path4ThreesCount = new PathFinder(input).CountThrees(new List<Move>() { new Move(Direction.Right, 7), new Move(Direction.Down, 1) });
            var path5ThreesCount = new PathFinder(input).CountThrees(new List<Move>() { new Move(Direction.Right, 1), new Move(Direction.Down, 2) });

            var threeCount = path1ThreesCount * path2ThreesCount * path3ThreesCount * path4ThreesCount * path5ThreesCount;
        }
    }
}
