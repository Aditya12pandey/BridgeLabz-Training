using System;

public class LargestAndSecondLargest
{
    public static void Main(string[] args)
    {
        long number = Convert.ToInt64(Console.ReadLine());
        int MaxDigit = 10;
        int[] arr = new int[MaxDigit];
        int index = 0;

        while (number > 0)
        {
            arr[index] = (int)(number % 10);
            number = number / 10;
            index++;
            if (index == MaxDigit -1)
            {
                break;
            }
        }
        int largest = int.MinValue;
        int secondLargest = int.MinValue;
        for (int i = 0; i < index; i++)
        {
            if (arr[i] > largest)
            {
                secondLargest = largest;
                largest = arr[i];
            }
            else if (arr[i] > secondLargest && arr[i] != largest)
            {
                secondLargest = arr[i];
            }

        }
        Console.WriteLine("The largest digit is " + largest);
        Console.WriteLine("The second largest digit is " + secondLargest);

    }
}
