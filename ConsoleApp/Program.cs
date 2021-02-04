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
            DayOne();
            DayTwo();

        }

        public static void DayOne() 
        {
            var delimiters = new char[] { '\r', '\n' };

            var input = Resources.DayOne.Split(delimiters)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .Select(s => int.Parse(s));
            
            var dayOne = new DayOne(input);

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

            var policyPasswords = new DayTwo().ReadPolicyPasswordPairs(input);
            var validPasswords = new DayTwo().ReturnValidPasswords(policyPasswords);
        }
    }
}
