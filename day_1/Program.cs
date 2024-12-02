using System;
using System.IO;

namespace AOCDay1
{
    public class Project
    {
        private Dictionary<int, int> similarityDict = new();
        public static void Main(string[] args)
        {
            List<int> left_ids = [];
            List<int> right_ids = [];
            List<string> lines = Parse_Input("input.txt");
            foreach (var line in lines)
            {
                var ids = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                left_ids.Add(int.Parse(ids[0]));
                right_ids.Add(int.Parse(ids[1]));
            }

            Quicksort(left_ids, 0, left_ids.Count - 1);
            Quicksort(right_ids, 0, right_ids.Count - 1);
            FindTotalDistanceBetweenLists(left_ids, right_ids);
            Console.WriteLine(left_ids.Count);

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
                Console.WriteLine($"left: {arr1[i]}, right: {arr2[i]} | diff = {Math.Abs(arr1[i] - arr2[i])}");
                distanceDifferance += Math.Abs(arr1[i] - arr2[i]);
            }
            Console.WriteLine();
            Console.WriteLine(distanceDifferance);
            return distanceDifferance;
        }
    }
}
