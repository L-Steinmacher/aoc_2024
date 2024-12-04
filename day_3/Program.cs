using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.RegularExpressions;
using AOC2024.Common;

namespace AOCDay3
{
    class MemoryRecovery
    {
        static void Main(string[] args)
        {
            List<string> lines = Utilities.Parse_Input("input.txt");
            foreach (var line in lines)
            {
                // Console.WriteLine(line);
                MulFinder(line);
            }
        }

        private static void MulFinder(string line)
        {
            int accumulator = 0;
            var pairs = new List<(int, int)>();
            string pattern = @"mul\((\d+),\s*(\d+)\)";

            foreach (Match match in Regex.Matches(line, pattern))
            {
                Console.WriteLine("'{0}' found at index {1}.", match.Value, match.Index);
                // accumulator += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                // Console.WriteLine(accumulator);
            }
        }
    }
}