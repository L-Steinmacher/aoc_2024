using System;
using System.Collections.Generic;
using System.Linq;
using AOC2024.Common;
using Microsoft.VisualBasic;

namespace AOCDay5
{
    public class Queue
    {
        public static Dictionary<int, List<int>> OrderRules = new();
        public static List<List<int>> UpdatePages = new();
        static void Main(string[] args)
        {
            var lines = Utilities.Parse_Input("input.txt");
            foreach (var line in lines)
            {
                if (line == "")
                {
                    continue;
                }
                else if (line.Length <= 5)
                {
                    var digits = line.Split('|');
                    int before = int.Parse(digits[0]);
                    int after = int.Parse(digits[1]);
                    if (!OrderRules.ContainsKey(before))
                    {
                        OrderRules[before] = new List<int>();
                        OrderRules[before].Add(after);
                    }
                }
                else
                {
                    UpdatePages.Add(line.Split(',').Select(int.Parse).ToList());
                }

                // Console.WriteLine(line);
            }
            foreach (var line in UpdatePages)
            {
                string outputString = line.Select(x => x.ToString()).Aggregate((a, b) => a + " " + b);
                Console.WriteLine(outputString);
            }
        }
    }
}
