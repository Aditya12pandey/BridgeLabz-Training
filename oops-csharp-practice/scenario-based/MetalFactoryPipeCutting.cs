using System;

interface ICutOptimizer
{
    void Execute();
}

abstract class RodCuttingBase
{
    protected int rodLength;
    protected int[] prices;

    public RodCuttingBase(int rodLength, int[] prices)
    {
        this.rodLength = rodLength;
        this.prices = prices;
    }

    // Dynamic Programming with cut tracking
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

    protected void PrintCuts(int[] cut, int length)
    {
        Console.Write("Best Cut Strategy: ");
        while (length > 0)
        {
            Console.Write(cut[length] + " ");
            length -= cut[length];
        }
        Console.WriteLine();
    }

    protected void DisplayPriceChart()
    {
        Console.WriteLine("\nLength\tPrice");
        for (int i = 1; i < prices.Length; i++)
            Console.WriteLine($"{i}\t{prices[i]}");
    }
}

class MetalFactoryCutting : RodCuttingBase, ICutOptimizer
{
    public MetalFactoryCutting(int rodLength, int[] prices)
        : base(rodLength, prices) { }

    public void Execute()
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine(" Metal Factory Pipe Cutting");
            DisplayPriceChart();

            Console.WriteLine("\nMENU");
            Console.WriteLine("1. Scenario A – Find Best Cut");
            Console.WriteLine("2. Scenario B – Add Custom Length Price");
            Console.WriteLine("3. Scenario C – Non-Optimized Revenue");
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

    // Scenario A
    private void ScenarioA()
    {
        int[] cut;
        int revenue = MaxRevenue(rodLength, out cut);

        Console.WriteLine("\n Scenario A: Optimized Revenue");
        Console.WriteLine($"Maximum Revenue = {revenue}");
        PrintCuts(cut, rodLength);
    }

    // Scenario B
    private void ScenarioB()
    {
        Console.Write("\nEnter custom length to update: ");
        int len = int.Parse(Console.ReadLine());

        if (len < 1 || len > rodLength)
        {
            Console.WriteLine(" Invalid length!");
            return;
        }

        Console.Write("Enter new price: ");
        prices[len] = int.Parse(Console.ReadLine());

        int[] cut;
        int revenue = MaxRevenue(rodLength, out cut);

        Console.WriteLine("\n Scenario B: After Custom Order");
        Console.WriteLine($"Updated Revenue = {revenue}");
        PrintCuts(cut, rodLength);
    }

    // Scenario C
    private void ScenarioC()
    {
        int nonOptimized = prices[rodLength];
        int[] cut;
        int optimized = MaxRevenue(rodLength, out cut);

        Console.WriteLine("\n Scenario C: Without Optimization");
        Console.WriteLine($"Non-Optimized Revenue = {nonOptimized}");
        Console.WriteLine($"Optimized Revenue = {optimized}");
        Console.WriteLine($"Loss per Rod = {optimized - nonOptimized}");
    }
}

class  MetalFactoryPipeCutting
{
    static void Main()
    {
        Console.WriteLine(" Metal Factory Optimization System");

        int rodLength = 8;
        int[] prices = new int[rodLength + 1];

        Console.WriteLine("\nEnter price chart for rod length 8:");
        for (int i = 1; i <= rodLength; i++)
        {
            Console.Write($"Price for length {i}: ₹");
            prices[i] = int.Parse(Console.ReadLine());
        }

        ICutOptimizer optimizer =
            new MetalFactoryCutting(rodLength, prices);

        optimizer.Execute();
    }
}
