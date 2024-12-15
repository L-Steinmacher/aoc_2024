using System;
using System.Collections.Generic;
using AOC2024.Common;

namespace AOC2024.Base
{
    public abstract class DayBase
    {
        protected string InputFile { get; }

        protected DayBase(string inputFile = "input.txt")
        {
            InputFile = inputFile;
        }

        // Parse input as a list of strings
        protected List<string> ParseInput()
        {
            return Utilities.Parse_Input(InputFile);
        }

        // Abstract method for solving the problem
        public abstract void Solve();

        // Main method to be inherited
        public void Run()
        {
            Console.WriteLine($"Running solution for {GetType().Name}...");
            Solve();
        }
    }
}
