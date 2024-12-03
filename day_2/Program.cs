using System;
using System.Diagnostics.Metrics;
using System.IO;
using AOC2024.Common;


namespace AOCDay2
{
    public class Reports
    {

        static void Main(string[] args)
        {
            int safeReports = 0;
            List<List<int>> reports = new();
            List<string> lines = Utilities.Parse_Input("input.txt");
            foreach (var line in lines)
            {
                string[] reportString = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<int> report = new(Array.ConvertAll(reportString, int.Parse));
                bool safety = AssessReportSafety(report);
                if (safety) safeReports += 1;
            }
            Console.WriteLine(safeReports);

        }

        public static bool AssessReportSafety(List<int> report)
        {
            bool safe = true;
            bool ascending = false;
            bool descending = false;
            int safeStep = 3;
            for (int i = 1; i < report.Count; i++)
            {
                int previousLevel = report[i - 1];
                int currentLevel = report[i];
                int currDiff = previousLevel - currentLevel;
                // Console.WriteLine($"currDiff: {currDiff}");

                if (currDiff > 0) descending = true;
                else if (currDiff < 0) ascending = true;
                else
                {
                    // Console.WriteLine($"currDiff == {currDiff}");
                    safe = false;
                    break;
                }

                if (ascending && descending)
                {
                    safe = false;
                    break;
                }

                if (Math.Abs(currDiff) > safeStep)
                {
                    safe = false;
                    break;
                }
            }
            // Console.WriteLine(safe);
            return safe;
        }
    }
}