﻿using System;
using System.Diagnostics.Metrics;
using System.IO;
using AOC2024.Common;


namespace AOCDay4
{
    public class WordSearch
    {
        static void Main(string[] args)
        {
            List<string> lines = Utilities.Parse_Input("input.txt");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}