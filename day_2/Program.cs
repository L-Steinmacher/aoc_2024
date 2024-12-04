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
            // List<List<int>> testCases = new()
            // {
            //     new List<int> { 7, 6, 4, 2, 1 },     // Safe without removing
            //     new List<int> { 1, 2, 7, 8, 9 },     // Unsafe
            //     new List<int> { 9, 7, 6, 2, 1 },     // Unsafe
            //     new List<int> { 1, 3, 2, 4, 5 },     // Safe by removing 3
            //     new List<int> { 8, 6, 4, 4, 1 },     // Safe by removing 4
            //     new List<int> { 1, 3, 6, 7, 9 }      // Safe without removing
            // };

            // foreach (var testCase in testCases)
            // {
            //     bool safety = AssessReportSafety(testCase);
            //     Console.WriteLine($"Report {string.Join(" ", testCase)}: {(safety ? "Safe" : "Unsafe")}");
            // }
            int safeReports = 0;
            List<List<int>> reports = new();
            List<string> lines = Utilities.Parse_Input("input.txt");
            foreach (var line in lines)
            {
                string[] reportString = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<int> report = new(Array.ConvertAll(reportString, int.Parse));
                bool safety = AssessReportSafety(report);
                if (safety) safeReports += 1;
                Console.WriteLine($"Report {string.Join(" ", line)}: {(safety ? "Safe" : "Unsafe")}");
            }
            Console.WriteLine(safeReports);

        }

        public static bool AssessReportSafety(List<int> report)
        {
            bool check = true;
            for (int i = 0; i < report.Count - 1; i++)
            {
                check = AssessConsistency(report, i, 0);
                if (check) return true;
                // return check;
            }
            return check;
        }

        public static bool AssessConsistency(List<int> report, int skipIndex, int retry)
        {
            bool ascending = false;
            bool descending = false;
            int safeStep = 3;
            for (int i = 0; i < report.Count - 1; i++)
            {
                int nextLevelIndex = i + 1;
                if (i == skipIndex) continue;
                if (nextLevelIndex == skipIndex) nextLevelIndex++;
                if (nextLevelIndex >= report.Count) continue;
                int nextLevel = report[nextLevelIndex];
                int currentLevel = report[i];
                int currDiff = currentLevel - nextLevel;

                if (currDiff > 0) descending = true;
                else if (currDiff < 0) ascending = true;
                else
                {
                    if (retry < 1)
                    {
                        retry += 1;
                        return AssessConsistency(report, nextLevelIndex, retry) || AssessConsistency(report, i, retry);
                    }
                    return false;
                }

                if (ascending && descending)
                {
                    if (retry < 1)
                    {
                        retry += 1;
                        return AssessConsistency(report, nextLevelIndex, retry) || AssessConsistency(report, i, retry);
                    }
                    return false;
                }

                if (Math.Abs(currDiff) > safeStep)
                {
                    if (retry < 1)
                    {
                        retry += 1;
                        return AssessConsistency(report, nextLevelIndex, retry) || AssessConsistency(report, i, retry);
                    }
                    return false;
                }
            }
            return true;
        }
    }
}