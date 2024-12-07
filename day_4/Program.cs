using System;
using System.Collections.Generic;
using System.Linq;
using AOC2024.Common;

namespace AOCDay4
{
    public class WordSearch
    {
        public static List<List<string>> LetterArrays = new();
        public static List<string> lines = new();
        public static List<string> XMAS = new() { "X", "M", "A", "S" };

        static void Main(string[] args)
        {
            lines = Utilities.Parse_Input("input.txt");
            LetterArrays = lines.Select(line => line.Split("").ToList()).ToList();
            int XMASes = 0;
            for (int i = 0; i < LetterArrays.Count; i++)
            {
                string curArray = lines[i];
                XMASes += FindXMAS(curArray, i);
            }
            Console.WriteLine(XMASes);
        }

        public static int FindXMAS(string letterArray, int arrIndex)
        {
            int XMASes = 0;
            for (int index = 0; index < letterArray.Length; index++)
            {
                if (letterArray[index].ToString() != XMAS[0])
                    continue;

                // Check Left
                if (CheckLeft(letterArray, index))
                    XMASes++;

                // Check Right
                if (CheckRight(letterArray, index))
                    XMASes++;

                // Check Up
                if (CheckUp(LetterArrays, index, arrIndex))
                    XMASes++;

                // Check Down
                if (CheckDown(LetterArrays, index, arrIndex))
                    XMASes++;
            }
            return XMASes;
        }

        private static bool CheckLeft(string letterArray, int startIndex)
        {
            if (startIndex < XMAS.Count - 1)
                return false;

            for (int j = 1; j < XMAS.Count; j++)
            {
                if (letterArray[startIndex - j].ToString() != XMAS[j])
                    return false;
            }
            return true;
        }

        private static bool CheckRight(string letterArray, int startIndex)
        {
            if (startIndex + XMAS.Count > letterArray.Length)
                return false;

            for (int j = 1; j < XMAS.Count; j++)
            {
                if (letterArray[startIndex + j].ToString() != XMAS[j])
                    return false;
            }
            return true;
        }

        private static bool CheckUp(List<List<string>> letterArrays, int columnIndex, int startRowIndex)
        {
            if (startRowIndex < XMAS.Count - 1)
                return false;

            for (int j = 1; j < XMAS.Count; j++)
            {
                // Ensure column index is within bounds of the current row
                if (columnIndex >= letterArrays[startRowIndex - j].Count)
                    return false;

                if (letterArrays[startRowIndex - j][columnIndex] != XMAS[j])
                    return false;
            }
            return true;
        }

        private static bool CheckDown(List<List<string>> letterArrays, int columnIndex, int startRowIndex)
        {
            // Check if there's enough room to go down
            if (startRowIndex + XMAS.Count > letterArrays.Count)
                return false;

            for (int j = 1; j < XMAS.Count; j++)
            {
                // Ensure column index is within bounds of the current row
                if (columnIndex >= letterArrays[startRowIndex + j].Count)
                    return false;

                if (letterArrays[startRowIndex + j][columnIndex] != XMAS[j])
                    return false;
            }
            return true;
        }
    }
}