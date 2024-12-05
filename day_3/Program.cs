using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AOC2024.Common;

namespace AOCDay3
{
    class MemoryRecovery
    {
        static void Main(string[] args)
        {
            int total = 0;
            List<string> lines = Utilities.Parse_Input("input.txt");
            foreach (var line in lines)
            {
                total += MulFinder(line);
            }
            Console.WriteLine(total);
            TestLineProcessing();
        }

        private static int MulFinder(string line)
        {
            int accumulator = 0;

            string mulPattern = @"mul\((\d+),(\d+)\)";
            var matchingIndexes = FindEnabledIndexes(line);

            foreach (Match match in Regex.Matches(line, mulPattern))
            {
                int matchIndex = match.Index;
                (int, int) matchtuple = new(0, 0);
                bool disabled = matchingIndexes.Any(tuple => matchIndex >= tuple.Item1 && matchIndex < tuple.Item2);

                if (!disabled)
                {
                    int val1 = int.Parse(match.Groups[1].Value);
                    int val2 = int.Parse(match.Groups[2].Value);
                    int product = val1 * val2;
                    accumulator += product;
                }
            }
            return accumulator;
        }

        public static List<(int, int)> FindEnabledIndexes(string line)
        {
            string doPattern = @"do\(\)";
            string dontPattern = @"don't\(\)";
            List<int> doIndexes = new();
            List<int> dontIndexes = new();
            List<(int, int)> matchingIndexes = new();

            foreach (Match match in Regex.Matches(line, doPattern))
            {
                doIndexes.Add(match.Index);
            }
            foreach (Match match in Regex.Matches(line, dontPattern))
            {
                dontIndexes.Add(match.Index);
            }
            (int, int) currentTuple = new(0, 0);

            foreach (int currentDontIndex in dontIndexes)
            {
                if (currentTuple != (0, 0) && currentDontIndex < currentTuple.Item2)
                {
                    continue;
                }
                int matchingDoIndex = doIndexes.FirstOrDefault(i => i > currentDontIndex);
                if (matchingDoIndex != 0)
                {
                    currentTuple = (currentDontIndex, matchingDoIndex);
                    matchingIndexes.Add(currentTuple);
                }
                else
                {
                    matchingIndexes.Add((currentDontIndex, line.Length));
                    break;
                }
            }
            return matchingIndexes;
        }

        public static void TestLineProcessing()
        {
            string testLine = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

            // Expected calculation:
            // mul(2,4) = 8
            // don't() excludes mul(5,5) and mul(11,8)
            // do() enables till end
            // mul(8,5) = 40
            // Total: 1+ 8 + 40 = 48

            int result = MulFinder(testLine);

            // Assert the result
            if (result == 48)
            {
                Console.WriteLine("Test Passed: Correct result of 48");
            }
            else
            {
                Console.WriteLine($"Test Failed: Expected 48, but got {result}");
            }

            // Additional test cases for validation
            string[] edgeCases = new[]
            {
        " ",                                // Empty input = 0
        "mul(2,3)mul(4,5)",                // No don't() or do() = 26
        "don't()mul(1,1)do()mul(2,2)",     // Single don't-do block = 4
        "mul(2,2)don't()mul(3,3)",         // No enabling do() after don't() = 4
        "don't()do()mul(1,1)mul(2,2)",     // don't-do with operations in between = 5
        "don't()mul(3,3)don't()do()",      // Nested don't-do patterns = 0
        "mul(1,1)do()mul(2,2)don't()",     // do() in middle 5
        "don't()mul(3,3)mul(4,4)do()mul(5,5)" // Operations outside and inside blocks= 25
    };
            int acc = 0;
            foreach (string caseLine in edgeCases)
            {
                Console.WriteLine($"Testing case: {caseLine}");
                int caseResult = MulFinder(caseLine);
                acc += caseResult;
                Console.WriteLine($"Result: {caseResult}");
            }
            Console.WriteLine(acc);
        }

    }
}