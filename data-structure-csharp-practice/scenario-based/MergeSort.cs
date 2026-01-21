using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure
{
    internal class MergeSortResult
    {

        //  Merge Sort
        static void MergeSort(int[] arr, int left, int right)
        {
            if (left >= right) return;

            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; i++)
                L[i] = arr[left + i];

            for (int j = 0; j < n2; j++)
                R[j] = arr[mid + 1 + j];

            int iIndex = 0, jIndex = 0, k = left;

            while (iIndex < n1 && jIndex < n2)
            {
                if (L[iIndex] <= R[jIndex])
                    arr[k++] = L[iIndex++];
                else
                    arr[k++] = R[jIndex++];
            }

            while (iIndex < n1) arr[k++] = L[iIndex++];
            while (jIndex < n2) arr[k++] = R[jIndex++];
        }

        //  Merge Two Sorted Arrays
        static int[] MergeTwoSortedArrays(int[] a, int[] b)
        {
            int[] res = new int[a.Length + b.Length];
            int i = 0, j = 0, k = 0;

            while (i < a.Length && j < b.Length)
            {
                if (a[i] <= b[j])
                    res[k++] = a[i++];
                else
                    res[k++] = b[j++];
            }

            while (i < a.Length) res[k++] = a[i++];
            while (j < b.Length) res[k++] = b[j++];

            return res;
        }

        static void Main()
        {
            Console.Write("Enter number of cities: ");
            int cities = int.Parse(Console.ReadLine());

            int[][] cityMarks = new int[cities][];

            //  Input marks for each city
            for (int c = 0; c < cities; c++)
            {
                Console.Write($"\nEnter city name {c + 1}: ");
                string cityName = Console.ReadLine();

                Console.Write($"Enter number of students in {cityName}: ");
                int n = int.Parse(Console.ReadLine());

                cityMarks[c] = new int[n];

                Console.WriteLine($"Enter marks for {cityName}:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Mark {i + 1}: ");
                    cityMarks[c][i] = int.Parse(Console.ReadLine());
                }

                // Sort city marks using Merge Sort
                MergeSort(cityMarks[c], 0, cityMarks[c].Length - 1);

                Console.WriteLine($" Sorted marks of {cityName}: {string.Join(" ", cityMarks[c])}");
            }

            // Merge all cities into one final sorted array
            int[] finalRankList = new int[0];

            for (int c = 0; c < cities; c++)
            {
                finalRankList = MergeTwoSortedArrays(finalRankList, cityMarks[c]);
            }

            Console.WriteLine(" Final State-Wise Rank List (Sorted Marks)");
            Console.WriteLine(string.Join(" ", finalRankList));
        }
    }
}
