using System;
using System.Collections.Generic;

interface ICuttingService
{
    void Execute();
}

abstract class WoodCuttingBase
{
    protected int rodLength;
    protected int[] prices;

    public WoodCuttingBase(int rodLength, int[] prices)
    {
        this.rodLength = rodLength;
        this.prices = prices;
    }

    // DP logic with cut tracking
    protected int MaxRevenue(int length, out int[] cut)
    {
        int[] dp = new int[length + 1];
        cut = new int[length + 1];

        for (int i = 1; i <= length; i++)
        {
            int max = int.MinValue;

            for (int j = 1; j <= i; j++)
            {
                if (prices[j] + dp[i - j] > max)
                {
                    max = prices[j] + dp[i - j];
                    cut[i] = j;
                }
            }
            dp[i] = max;
        }
        return dp[length];
    }

    protected List<int> GetCutList(int[] cut, int length)
    {
        List<int> result = new List<int>();
        while (length > 0)
        {
            result.Add(cut[length]);
            length -= cut[length];
        }
        return result;
    }

    protected void PrintCuts(List<int> cuts)
    {
        Console.Write("Cut Strategy: ");
        foreach (int c in cuts)
            Console.Write(c + " ");
        Console.WriteLine();
    }
}

class FurnitureCutting : WoodCuttingBase, ICuttingService
{
    public FurnitureCutting(int rodLength, int[] prices)
        : base(rodLength, prices) { }

    public void Execute()
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine(" Custom Furniture Manufacturing");
            DisplayPrices();

            Console.WriteLine("\nMENU");
            Console.WriteLine("1. Scenario A – Maximize Revenue");
            Console.WriteLine("2. Scenario B – Revenue with Waste Constraint");
            Console.WriteLine("3. Scenario C – Max Revenue + Min Waste");
            Console.WriteLine("4. Exit");

            Console.Write("\nEnter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ScenarioA();
                    break;

                case 2:
                    ScenarioB();
                    break;

                case 3:
                    ScenarioC();
                    break;

                case 4:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            if (choice != 4)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

        } while (choice != 4);
    }

    private void ScenarioA()
    {
        int[] cut;
        int revenue = MaxRevenue(rodLength, out cut);
        var cuts = GetCutList(cut, rodLength);

        Console.WriteLine("\n Scenario A: Maximum Revenue");
        Console.WriteLine($"Revenue = {revenue}");
        PrintCuts(cuts);
        Console.WriteLine($"Waste = 0 ft");
    }

    private void ScenarioB()
    {
        Console.Write("\nEnter allowed waste (ft): ");
        int maxWaste = int.Parse(Console.ReadLine());

        int bestRevenue = -1;
        int bestUsed = 0;
        List<int> bestCuts = null;

        for (int used = rodLength; used >= rodLength - maxWaste; used--)
        {
            int[] cut;
            int revenue = MaxRevenue(used, out cut);

            if (revenue > bestRevenue)
            {
                bestRevenue = revenue;
                bestUsed = used;
                bestCuts = GetCutList(cut, used);
            }
        }

        Console.WriteLine("\n Scenario B: Waste-Constrained Result");
        Console.WriteLine($"Revenue = {bestRevenue}");
        Console.WriteLine($"Waste = {rodLength - bestUsed} ft");
        PrintCuts(bestCuts);
    }

    private void ScenarioC()
    {
        Console.Write("\nEnter max allowed waste (ft): ");
        int maxWaste = int.Parse(Console.ReadLine());

        int bestRevenue = -1;
        int minWaste = int.MaxValue;
        List<int> bestCuts = null;

        for (int used = rodLength; used >= rodLength - maxWaste; used--)
        {
            int[] cut;
            int revenue = MaxRevenue(used, out cut);
            int waste = rodLength - used;

            if (revenue > bestRevenue ||
               (revenue == bestRevenue && waste < minWaste))
            {
                bestRevenue = revenue;
                minWaste = waste;
                bestCuts = GetCutList(cut, used);
            }
        }

        Console.WriteLine("\n Scenario C: Best Balanced Solution");
        Console.WriteLine($"Revenue = {bestRevenue}");
        Console.WriteLine($"Waste = {minWaste} ft");
        PrintCuts(bestCuts);
    }

    private void DisplayPrices()
    {
        Console.WriteLine("\nLength(ft)\tPrice");
        for (int i = 1; i < prices.Length; i++)
            Console.WriteLine($"{i}\t\t{prices[i]}");
    }
}

class FurnitureManufacturing
{
    static void Main()
    {
        Console.WriteLine(" Furniture Manufacturing Optimization System");

        Console.Write("\nEnter rod length (ft): ");
        int rodLength = int.Parse(Console.ReadLine());

        int[] prices = new int[rodLength + 1];
        Console.WriteLine("\nEnter price for each size:");
        for (int i = 1; i <= rodLength; i++)
        {
            Console.Write($"Price for {i} ft: ");
            prices[i] = int.Parse(Console.ReadLine());
        }

        ICuttingService service =
            new FurnitureCutting(rodLength, prices);

        service.Execute();
    }
}
