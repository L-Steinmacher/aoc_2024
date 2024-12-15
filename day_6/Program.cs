using System;
using AOC2024.Base;

namespace AOCDay6
{
    public class Day6Solution : DayBase
    {
        public Day6Solution(string inputFile = "input.txt") : base(inputFile) { }

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
            new Day6Solution().Run();
        }
    }
}
