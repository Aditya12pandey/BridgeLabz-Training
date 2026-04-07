using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.array.level2
{
    internal class LargestAndSecondLargest2
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int maxDigit = 10;
            int[] digits = new int[maxDigit];
            int index = 0;

            while (number != 0)
            {
                if (index == maxDigit)
                {
                    maxDigit = maxDigit + 10;
                    int[] temp = new int[maxDigit];

                    for (int i = 0; i < index; i++)
                    {
                        temp[i] = digits[i];
                    }

                    digits = temp;
                }

                digits[index] = number % 10;
                index++;

                number = number / 10;
            }

            int largest = 0;
            int secondLargest = 0;

            for (int i = 0; i < index; i++)
            {
                if (digits[i] > largest)
                {
                    secondLargest = largest;
                    largest = digits[i];
                }
                else if (digits[i] > secondLargest && digits[i] != largest)
                {
                    secondLargest = digits[i];
                }
            }

            Console.WriteLine("\nDigits stored in array:");
            for (int i = 0; i < index; i++)
            {
                Console.Write(digits[i] + " ");
            }

            Console.WriteLine($"\n\nLargest digit = {largest}");
            Console.WriteLine($"Second largest digit = {secondLargest}");
        }


    }
}
