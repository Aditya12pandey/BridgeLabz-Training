using System;
using System.Collections.Generic;

class BankingSystem
{
    class WithdrawalRequest
    {
        public int AccountNo;
        public double Amount;

        public WithdrawalRequest(int accountNo, double amount)
        {
            AccountNo = accountNo;
            Amount = amount;
        }
    }

    static void Main()
    {
        // Dictionary -> AccountNo -> Balance
        Dictionary<int, double> accounts = new Dictionary<int, double>();

        // Queue -> Withdrawal requests
        Queue<WithdrawalRequest> withdrawalQueue = new Queue<WithdrawalRequest>();

        Console.Write("Enter number of accounts: ");
        int accCount = Convert.ToInt32(Console.ReadLine());

        // Taking account details
        for (int i = 0; i < accCount; i++)
        {
            Console.Write("\nEnter Account Number: ");
            int accNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Balance: ");
            double balance = Convert.ToDouble(Console.ReadLine());

            accounts[accNo] = balance;
        }

        // Display all accounts
        Console.WriteLine("\n All Accounts (Dictionary):");
        foreach (var acc in accounts)
        {
            Console.WriteLine("Account: " + acc.Key + " Balance: " + acc.Value);
        }

        // SortedDictionary -> balance -> list of accounts (handles same balance)
        SortedDictionary<double, List<int>> sortedByBalance = new SortedDictionary<double, List<int>>();

        foreach (var acc in accounts)
        {
            int accNo = acc.Key;
            double balance = acc.Value;

            if (!sortedByBalance.ContainsKey(balance))
                sortedByBalance[balance] = new List<int>();

            sortedByBalance[balance].Add(accNo);
        }

        Console.WriteLine("\n Customers Sorted by Balance (SortedDictionary):");
        foreach (var item in sortedByBalance)
        {
            double balance = item.Key;
            foreach (int accNo in item.Value)
            {
                Console.WriteLine("Account: " + accNo + " Balance: " + balance);
            }
        }

        // Withdrawal requests input
        Console.Write("\nEnter number of withdrawal requests: ");
        int reqCount = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < reqCount; i++)
        {
            Console.Write("\nEnter Account Number for withdrawal: ");
            int accNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Withdrawal Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            withdrawalQueue.Enqueue(new WithdrawalRequest(accNo, amount));
        }

        // Processing withdrawal requests
        Console.WriteLine("\n Processing Withdrawals (Queue):");

        while (withdrawalQueue.Count > 0)
        {
            WithdrawalRequest req = withdrawalQueue.Dequeue();

            if (!accounts.ContainsKey(req.AccountNo))
            {
                Console.WriteLine(" Account " + req.AccountNo + " not found!");
                continue;
            }

            double currentBalance = accounts[req.AccountNo];

            if (req.Amount <= currentBalance)
            {
                accounts[req.AccountNo] = currentBalance - req.Amount;
                Console.WriteLine(" Withdrawal Successful: Account " + req.AccountNo +
                                  " New Balance: " + accounts[req.AccountNo]);
            }
            else
            {
                Console.WriteLine(" Insufficient Balance in Account " + req.AccountNo +" (Balance: " + currentBalance + ")");
            }
        }

        // Final balances
        Console.WriteLine("\n Final Account Balances:");
        foreach (var acc in accounts)
        {
            Console.WriteLine("Account: " + acc.Key + " Balance: " + acc.Value);
        }
    }
}
