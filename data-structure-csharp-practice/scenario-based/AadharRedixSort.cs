using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure
{
    internal class AadharRedixSort
    {
        public static void RedixSort(long[] arr)
        {
            long max = arr[0];
            for (int i =1 ; i < arr.Length;i++) 
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            for(long exp =1; max/exp >0; exp *=10)
            {
                CountSort(arr, exp);
            }
        }
        static void CountSort(long[] arr , long exp)
        {
            int n = arr.Length;
            long[] output = new long[n];
            int[] count = new int[10];
            for (int i = 0; i < n; i++)
            {
                int digit = (int)((arr[i] / exp) % 10);
                count[digit]++;
            }

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int digit = (int)((arr[i] / exp) % 10);
                output[count[digit] - 1] = arr[i];
                count[digit]--;
            }

            for (int i = 0; i < n; i++)
                arr[i] = output[i];
        }

        //Binary Search
        static int BinarySearch(long[] arr, long target)
        {
            int low = 0, high = arr.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
        static void Main()
        {
            Console.Write("Enter how many Aadhar numbers: ");
            int n = Convert.ToInt32(Console.ReadLine());

            long[] aadhar = new long[n];

            Console.WriteLine("Enter Aadhar numbers (12-digit):");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Aadhar " + (i + 1) + ": ");
                aadhar[i] = Convert.ToInt64(Console.ReadLine());
            }

            //  Scenario A Sort
            RedixSort(aadhar);

            Console.WriteLine("\n Sorted Aadhar Numbers:");
            for (int i = 0; i < n; i++)
                Console.WriteLine(aadhar[i]);

            //  Scenario B Search
            Console.Write("\nEnter Aadhar number to search: ");
            long search = Convert.ToInt64(Console.ReadLine());

            int index = BinarySearch(aadhar, search);

            if (index != -1)
                Console.WriteLine(" Found at index: " + index);
            else
                Console.WriteLine(" Not Found!");

            //  Scenario C Stability
            Console.WriteLine("\n Radix Sort is STABLE, so same prefix order remains same.");
        }
    }
}
