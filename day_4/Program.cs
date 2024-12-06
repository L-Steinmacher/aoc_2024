using System;
using System.Diagnostics.Metrics;
using System.IO;
using AOC2024.Common;
using ExtensionMethods;

namespace AOCDay4
{

    public class WordSearch
    {
        static void Main(string[] args)
        {
            List<string> lines = Utilities.Parse_Input("input.txt");
            List<List<string>> letterArray = lines.Select(line => line.Split("").ToList()).ToList();
            foreach (var line in lines)
            {
                var result = line.AllIndexesOf("X");
                foreach (var r in result)
                {
                    Console.WriteLine(r);
                }
            }
            for (int i = 0; i < letterArray.Count; i++)
            {

            }
        }

        public int FindXMAS()
        {
            return 0;
        }
    }
}