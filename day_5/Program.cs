using System;
using System.Collections.Generic;
using System.Dynamic;
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
            int accumulator = 0;
            var lines = Utilities.Parse_Input("input.txt");
            foreach (var line in lines)
            {
                if (line == "")
                {
                    continue;
                }

                if (line.Length <= 5)
                {
                    var digits = line.Split('|');
                    int before = int.Parse(digits[0]);
                    int after = int.Parse(digits[1]);
                    if (!OrderRules.ContainsKey(before))
                    {
                        OrderRules[before] = new();
                    }
                    OrderRules[before].Add(after);
                }
                else
                {
                    UpdatePages.Add(line.Split(',').Select(int.Parse).ToList());
                }

                // Console.WriteLine(line);
            }
            foreach (var pages in UpdatePages)
            {
                accumulator += CheckOrdering(pages);
            }
            Console.WriteLine(accumulator);
        }

        public static int CheckOrdering(List<int> pageList)
        {
            var indices = new Dictionary<int, int>();
            for (int i = 0; i < pageList.Count; i++)
            {
                indices[pageList[i]] = i;
            }

            foreach (var pageNumber in pageList)
            {
                if (OrderRules.ContainsKey(pageNumber))
                {
                    foreach (var rule in OrderRules[pageNumber])
                    {
                        if (indices.TryGetValue(rule, out var ruleIndex) &&
                            indices.TryGetValue(pageNumber, out var pageIndex))
                        {
                            if (pageIndex >= ruleIndex) // Rule violated
                                return 0;
                        }
                    }
                }
            }

            return pageList[(pageList.Count - 1) / 2];
        }
    }
}
