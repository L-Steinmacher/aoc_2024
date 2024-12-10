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
            // TestWordSearchProcessing();
            lines = Utilities.Parse_Input("input.txt");
            LetterArrays = lines.Select(line =>
    line.Select(c => c.ToString()).ToList()
).ToList();
            int XMASes = 0;
            for (int i = 0; i < LetterArrays.Count; i++)
            {
                string curArray = lines[i];
                XMASes += FindXMAS(curArray, i, LetterArrays);
            }
            Console.WriteLine(XMASes);
        }

        public static int FindXMAS(string letterArray, int arrIndex, List<List<string>> matrix)
        {
            int XMASes = 0;
            for (int index = 0; index < letterArray.Length; index++)
            {
                if (letterArray[index].ToString() != XMAS[0])
                    continue;

                if (CheckDirectionalPattern(index, arrIndex, matrix, 0, -1))
                {
                    XMASes++;
                }

                if (CheckDirectionalPattern(index, arrIndex, matrix, 0, 1))
                {
                    XMASes++;
                }

                if (CheckDirectionalPattern(index, arrIndex, matrix, -1, 0))
                {
                    XMASes++;
                }

                if (CheckDirectionalPattern(index, arrIndex, matrix, 1, 0))
                {
                    XMASes++;
                }

                if (CheckDirectionalPattern(index, arrIndex, matrix, 1, -1))
                {
                    XMASes++;
                }

                if (CheckDirectionalPattern(index, arrIndex, matrix, -1, -1))
                {
                    XMASes++;
                }

                if (CheckDirectionalPattern(index, arrIndex, matrix, 1, 1))
                {
                    XMASes++;
                }

                if (CheckDirectionalPattern(index, arrIndex, matrix, -1, 1))
                {
                    XMASes++;
                }

            }
            return XMASes;
        }

        private static bool CheckDirectionalPattern(
            int columnIndex,
            int startRowIndex,
            List<List<string>> matrix,
            int columnStep,
            int rowStep)
        {
            // Check if there's enough room in both column and row directions
            if (startRowIndex + (rowStep * (XMAS.Count - 1)) < 0 ||
                startRowIndex + (rowStep * (XMAS.Count - 1)) >= matrix.Count ||
                columnIndex + (columnStep * (XMAS.Count - 1)) < 0 ||
                columnIndex + (columnStep * (XMAS.Count - 1)) >= matrix[0].Count)
            {
                return false;
            }

            for (int j = 1; j < XMAS.Count; j++)
            {
                int currentRow = startRowIndex + (rowStep * j);
                int currentColumn = columnIndex + (columnStep * j);

                // Validate current row and column are within matrix bounds
                if (currentRow < 0 || currentRow >= matrix.Count ||
                    currentColumn < 0 || currentColumn >= matrix[currentRow].Count)
                {
                    return false;
                }

                // Check if the character matches the expected XMAS character
                if (matrix[currentRow][currentColumn] != XMAS[j])
                {
                    return false;
                }
            }

            return true;
        }
        // private static bool CheckLeft(string letterArray, int startIndex)
        // {
        //     if (startIndex < XMAS.Count - 1)
        //     {
        //         // Console.WriteLine($"left: startIndex < XMAS.Count - 1 {startIndex - XMAS.Count}");
        //         return false;
        //     }

        //     for (int j = 1; j < XMAS.Count; j++)
        //     {
        //         if (letterArray[startIndex - j].ToString() != XMAS[j])
        //             return false;
        //         // Console.WriteLine($"{letterArray[startIndex - j].ToString()}: {XMAS[j]}");
        //     }
        //     Console.WriteLine("Left here");
        //     return true;
        // }

        // private static bool CheckRight(string letterArray, int startIndex)
        // {
        //     if (startIndex + XMAS.Count > letterArray.Length)
        //     {
        //         // Console.WriteLine($"right: startIndex + XMAS.Count > letterArray.Length {startIndex + XMAS.Count} {letterArray.Length}");
        //         return false;
        //     }

        //     for (int j = 1; j < XMAS.Count; j++)
        //     {
        //         if (letterArray[startIndex + j].ToString() != XMAS[j])
        //             return false;
        //         // Console.WriteLine($"{letterArray[startIndex + j].ToString()}: {XMAS[j]}");
        //     }
        //     Console.WriteLine("right here");
        //     return true;
        // }

        // private static bool CheckUp(int columnIndex, int startRowIndex, List<List<string>> matrix)
        // {
        //     if (startRowIndex - XMAS.Count < 0)
        //     {
        //         // Console.WriteLine($"up: {startRowIndex}, {XMAS.Count} out of room {startRowIndex - XMAS.Count} <  0");
        //         return false;
        //     }

        //     for (int j = 1; j < XMAS.Count; j++)
        //     {
        //         // Ensure column index is within bounds of the current row
        //         Console.WriteLine($"{string.Join("", matrix[startRowIndex - j])}, startRownIndex: {startRowIndex}, Column Index: {columnIndex} >= {matrix[startRowIndex - j][0].Length}");
        //         if (columnIndex >= matrix[startRowIndex - j].Count)
        //             return false;

        //         if (matrix[startRowIndex - j][columnIndex] != XMAS[j])
        //             return false;
        //     }
        //     Console.WriteLine("UP here ");
        //     return true;
        // }

        // private static bool CheckDown(int columnIndex, int startRowIndex, List<List<string>> matrix)
        // {
        //     // Check if there's enough room to go down
        //     if (startRowIndex + XMAS.Count > matrix.Count)
        //     {
        //         // Console.WriteLine($"down: {startRowIndex}, {XMAS.Count} out of room {startRowIndex + XMAS.Count} > {matrix.Count}");
        //         return false;
        //     }

        //     for (int j = 1; j < XMAS.Count; j++)
        //     {
        //         // Ensure column index is within bounds of the current row
        //         if (columnIndex >= matrix[startRowIndex + j].Count)
        //             return false;

        //         if (matrix[startRowIndex + j][columnIndex] != XMAS[j])
        //             return false;
        //     }

        //     Console.WriteLine("down here ");
        //     return true;
        // }

        // private static bool CheckUpRight(int columnIndex, int startRowIndex, List<List<string>> matrix)
        // {
        //     if (startRowIndex - XMAS.Count < 0 | columnIndex + XMAS.Count > matrix[0].Count)
        //     {
        //         return false;
        //     }

        //     for (int j = 1; j < XMAS.Count; j++)
        //     {
        //         // Ensure column index is within bounds of the current row
        //         // Console.WriteLine($"{string.Join("", matrix[startRowIndex - j])}, startRownIndex: {startRowIndex}, Column Index: {columnIndex} >= {matrix[startRowIndex - j][0].Length}");
        //         if (columnIndex >= matrix[startRowIndex - j].Count)
        //             return false;

        //         if (matrix[startRowIndex - j][columnIndex + j] != XMAS[j])
        //             return false;
        //     }
        //     Console.WriteLine("UP right here ");
        //     return true;
        // }
        public static void TestWordSearchProcessing()
        {
            // Test grid similar to the previous example
            List<string> testGrids = new List<string>
    {
        "MMMSXXMASM", // Grid 1
        "MSAMXMSMSA", // Grid 2
        "AMXSXMAAMM", // Grid 3
        "MSAMASMSMX", // Grid 4
        "XMASAMXAMM", // Grid 5
        "XXAMMXXAMA", // Grid 6
        "SMSMSASXSS", // Grid 7
        "SAXAMASAAA", // Grid 8
        "MAMMMXMMMM", // Grid 9
        "MXMXAXMASX"  // Grid 10
    };

            int expectedResults = 18;

            {
                lines = testGrids;
                List<List<string>> testMatrix = lines.Select(line =>
    line.Select(c => c.ToString()).ToList()
).ToList();

                int XMASes = 0;
                for (int i = 0; i < testMatrix.Count; i++)
                {
                    string curArray = lines[i];
                    XMASes += FindXMAS(curArray, i, testMatrix);
                }

                // Assert the result
                if (XMASes == expectedResults)
                {
                    Console.WriteLine("Test Passed: Correct total XMAS occurrences of 18");
                }
                else
                {
                    Console.WriteLine($"Test Failed: Expected {expectedResults}, but got {XMASes}");
                }
            }

            // Additional test cases for validation
            //         string[] edgeCases = new[]
            //         {
            //     "XMAS",        // Simple horizontal XMAS
            //     "X\nM\nA\nS",  // Simple vertical XMAS
            //     "MMXMAS",      // XMAS with prefix
            //     "XMASMM",      // XMAS with suffix
            //     "",            // Empty input
            //     "MMMMM",       // No XMAS
            //     "XMAXMASM"     // Multiple XMAS patterns
            // };

            // int acc = 0;
            // foreach (string caseLine in edgeCases)
            // {
            //     Console.WriteLine($"Testing case: {caseLine}");

            //     // Prepare the test input
            //     var caseLines = caseLine.Split('\n').ToList();
            //     Utilities.Parse_Input = (string filename) => caseLines;
            //     WordSearch.lines = caseLines;
            //     WordSearch.LetterArrays = caseLines.Select(line => line.Split("").ToList()).ToList();

            //     int caseResult = 0;
            //     for (int i = 0; i < WordSearch.LetterArrays.Count; i++)
            //     {
            //         string curArray = WordSearch.lines[i];
            //         caseResult += WordSearch.FindXMAS(curArray, i);
            //     }

            //     acc += caseResult;
            //     Console.WriteLine($"Result: {caseResult}");
            // }

            // Console.WriteLine($"Total accumulator from edge cases: {acc}");

            // // Optional: Detailed print of the test grid
            // Console.WriteLine("\nTest Grid:");
            // foreach (var row in testGrids)
            // {
            //     Console.WriteLine(row);
            // }
        }
    }
}