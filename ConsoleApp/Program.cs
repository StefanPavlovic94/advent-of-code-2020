using AdventOfCode2020;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var delimiters = new char[] { '\r', '\n'};
            
            var input = Resources.DayOne.Split(delimiters)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => int.Parse(s.Trim()));

            Console.WriteLine(input.Count());

            var result = DayOne.FindSumPair(input, 2020);
            var multipliedResult = result.Item1 * result.Item2;

            var resultTriplet = DayOne.FindSumTriplet(input, 2020);
            var multipledTripletResult = resultTriplet.Item1 * resultTriplet.Item2 * resultTriplet.Item3;
        }


    }
}
