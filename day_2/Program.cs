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
            List<List<int>> reports = new();
            List<string> lines = Utilities.Parse_Input("input.txt");
            foreach (var line in lines)
            {
                string[] reportString = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<int> report = new(Array.ConvertAll(reportString, int.Parse));
            }

            Console.WriteLine(reports);
        }
    }
}