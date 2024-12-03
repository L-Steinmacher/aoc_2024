using System;
using System.Diagnostics.Metrics;
using System.IO;

namespace AOC2024.Common
{
    public class Utilities
    {
        public static List<string> Parse_Input(string path)
        {
            List<string> result = new();
            var file_contents = File.ReadAllLines(path);
            for (int i = 0; i < file_contents.Length; i++)
            {
                string line = file_contents[i];
                result.Add(line);
            }
            return result;
        }
    }

}