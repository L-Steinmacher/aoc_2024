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
            int initialTrend = report[0] - report[1];
            int safeStep = 3;
            for (int i = 1; i < report.Count; i++)
            {

                int currTrend = report[i - 1] - report[i];
                // Console.WriteLine($"currDiff: {currDiff}");

                if (Math.Sign(currTrend) != Math.Sign(initialTrend))
                {
                    safe = false;
                    break;
                }

                if (Math.Abs(currTrend) > safeStep)
                {
                    safe = false;
                    break;
                }
            }

            return safe;
        }
    }
}