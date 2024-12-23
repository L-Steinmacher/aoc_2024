using System;
using AOC2024.Common;
using AOC2024.Base;

namespace AOC7
{
    public class Day7Solution : DayBase
    {
        public Day7Solution(string inputFile = "input.txt") : base(inputFile) { }

        public override void Solve()
        {
            var lines = ParseInput();

            foreach (var line in lines)
            {
                // Your day's solution logic here
            }

            Console.WriteLine("Solution complete.");
        }

        public static void Main(string[] args)
        {
            new Day7Solution().Run();
        }
    }
}
