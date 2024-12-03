using System;
using System.Diagnostics.Metrics;
using System.IO;
using AOC2024.Common;


namespace AOCDay1
{
    public class Historian
    {
        private static SimilarityDict counter = new();
        public static void Main(string[] args)
        {
            List<int> left_ids = [];
            List<int> right_ids = [];
            List<string> lines = Utilities.Parse_Input("input.txt");
            foreach (var line in lines)
            {
                var ids = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int leftId = int.Parse(ids[0]);
                int rightId = int.Parse(ids[1]);

                left_ids.Add(leftId);
                counter.Increment(leftId, SimilarityDict.ListType.left_ids);
                right_ids.Add(rightId);
                counter.Increment(rightId, SimilarityDict.ListType.right_ids);

                counter.PrintData();
            }

            Quicksort(left_ids, 0, left_ids.Count - 1);
            Quicksort(right_ids, 0, right_ids.Count - 1);
            FindTotalDistanceBetweenLists(left_ids, right_ids);
            // Console.WriteLine(left_ids.Count);

        }

        static int Partition(List<int> arr, int left, int right)
        {
            int pivot = arr[left];
            int i = left + 1;
            int j = right;

            while (true)
            {
                while (i <= j && arr[i] <= pivot) i++;
                while (i <= j && arr[j] > pivot) j--;

                if (i <= j)
                {
                    SwapArrayValues(arr, i, j);
                    i++;
                    j--;
                }
                else
                {
                    SwapArrayValues(arr, left, j);
                    return j;
                }
            }
        }

        static void Quicksort(List<int> arr, int left, int right)
        {
            if (left >= right) return;
            int pivot = Partition(arr, left, right);
            Quicksort(arr, left, pivot - 1);
            Quicksort(arr, pivot + 1, right);
        }

        static void SwapArrayValues(List<int> arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static int FindTotalDistanceBetweenLists(List<int> arr1, List<int> arr2)
        {
            int distanceDifferance = 0;
            for (int i = 0; i < arr1.Count; i++)
            {
                // Console.WriteLine($"left: {arr1[i]}, right: {arr2[i]} | diff = {Math.Abs(arr1[i] - arr2[i])}");
                distanceDifferance += Math.Abs(arr1[i] - arr2[i]);
            }
            // Console.WriteLine();
            // Console.WriteLine(distanceDifferance);
            return distanceDifferance;
        }
    }
}
