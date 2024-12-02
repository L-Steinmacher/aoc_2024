using System;
using System.IO;

namespace AOCDay1
{
    public class Project
    {
        public static void Main(string[] args)
        {
            List<string> lines = Parse_Input("input.txt");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        static List<string> Parse_Input(string path)
        {
            List<string> result = [];
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
