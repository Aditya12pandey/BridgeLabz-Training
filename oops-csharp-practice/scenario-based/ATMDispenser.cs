using System;
using System.Collections.Generic;

class ATMDispenser
{
    static void DispenseCash(int amount, int[] denominations)
    {
        Dictionary<int, int> notesUsed = new Dictionary<int, int>();

        foreach (int note in denominations)
        {
            if (amount >= note)
            {
                int count = amount / note;
                amount = amount % note;
                notesUsed[note] = count;
            }
        }

        if (amount == 0)
        {
            Console.WriteLine("\nCash Dispensed Successfully:");
            foreach (var item in notesUsed)
            {
                Console.WriteLine($"₹{item.Key} x {item.Value}");
            }
        }
        else
        {
            Console.WriteLine("\nExact change is NOT possible.");
            Console.WriteLine("Fallback option:");

            int dispensed = 0;
            foreach (var item in notesUsed)
            {
                dispensed += item.Key * item.Value;
            }

            Console.WriteLine($"Closest possible amount dispensed: ₹{dispensed}");
        }
    }

    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("\n===== ATM Dispenser Menu =====");
            Console.WriteLine("1. Scenario A (All Notes Available)");
            Console.WriteLine("2. Scenario B (₹500 Removed)");
            Console.WriteLine("3. Scenario C (Fallback Example)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter amount: ");
                    int amountA = Convert.ToInt32(Console.ReadLine());

                    int[] notesA = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
                    DispenseCash(amountA, notesA);
                    break;

                case 2:
                    Console.Write("Enter amount: ");
                    int amountB = Convert.ToInt32(Console.ReadLine());

                    int[] notesB = { 200, 100, 50, 20, 10, 5, 2, 1 }; // ₹500 removed
                    DispenseCash(amountB, notesB);
                    break;

                case 3:
                    Console.Write("Enter amount: ");
                    int amountC = Convert.ToInt32(Console.ReadLine());

                    int[] notesC = { 20, 10 }; // Limited notes
                    DispenseCash(amountC, notesC);
                    break;

                case 4:
                    Console.WriteLine("Thank you for using ATM!");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 4);
    }
}
