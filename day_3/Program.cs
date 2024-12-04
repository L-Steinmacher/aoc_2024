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
            int total = 0;
            TestLineProcessing();
            List<string> lines = Utilities.Parse_Input("input.txt");
            foreach (var line in lines)
            {
                total += MulFinder(line);
            }
            Console.WriteLine(total);
        }

        private static int MulFinder(string line)
        {
            int accumulator = 0;

            string pattern = @"mul\((\d+),(\d+)\)";

            foreach (Match match in Regex.Matches(line, pattern))
            {
                int val1 = int.Parse(match.Groups[1].Value);
                int val2 = int.Parse(match.Groups[2].Value);
                int product = val1 * val2;
                accumulator += product;
            }
            return accumulator;
        }

        public static void TestLineProcessing()
        {
            string testLine = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul ( 32,  3)mul(4*, mul(6,9!, ?(12,34),mul(32,64]then(mul(11,8)mul(8,5))";
            int result = MulFinder(testLine);

            // Expected calculation:
            // mul(2,4) = 8
            // mul(5,5) = 25
            // mul(11,8) = 88
            // mul(8,5) = 40
            // Total: 8 + 25 + 88 + 40 = 161

            if (result == 161)
            {
                Console.WriteLine("Test Passed: Correct result of 161");
            }
            else
            {
                Console.WriteLine($"Test Failed: Expected 161, but got {result}");
                throw new Exception($"Test failed. Expected 161, got {result}");
            }
        }
    }
}