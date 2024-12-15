using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using AOC2024.Common;

namespace AOCDay5
{
    public class Queue
    {
        public static Dictionary<int, List<int>> OrderRules = new();
        public static List<List<int>> UpdatePages = new();
        static void Main(string[] args)
        {
            int accumulator = 0;
            int reorderAccumulator = 0;
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


            }
            foreach (var pages in UpdatePages)
            {
                var res = CheckOrdering(pages);

                reorderAccumulator += res;
            }
            Console.WriteLine($"accumulator: {accumulator}, reordered{reorderAccumulator}");
        }

        public static int CheckOrdering(List<int> pageList)
        {
            Dictionary<int, int> indices = new Dictionary<int, int>();
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
                            {
                                return ReformatPageList(pageList, indices, ruleIndex, pageIndex);
                            }
                        }
                    }
                }
            }

            return 0;
        }

        public static int ReformatPageList(List<int> pageList, Dictionary<int, int> indices, int ruleIndex, int pageIndex)
        {
            bool needsReformatting = false;
            var pageNumber = pageList[pageIndex];
            int temp = pageList[ruleIndex];
            pageList[ruleIndex] = pageList[pageIndex];
            pageList[pageIndex] = temp;

            indices[pageList[ruleIndex]] = ruleIndex;
            indices[pageList[pageIndex]] = pageIndex;

            foreach (var page in pageList)
            {
                if (OrderRules.ContainsKey(page))
                {
                    foreach (var rule in OrderRules[page])
                    {
                        if (
                            indices.TryGetValue(rule, out var rulePageIndex) &&
                            indices.TryGetValue(page, out var currentPageIndex)
                            )
                        {
                            if (currentPageIndex >= rulePageIndex)
                            {
                                needsReformatting = true;
                                return ReformatPageList(pageList, indices, rulePageIndex, currentPageIndex);
                            }
                        }
                    }
                }
            }
            if (!needsReformatting)
                return pageList[(pageList.Count - 1) / 2];
            return 0;
        }

    }
}
