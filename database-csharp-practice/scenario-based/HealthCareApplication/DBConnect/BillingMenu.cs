using System;

public class BillingMenu
{
    private readonly BillingUtility _utility;

    public BillingMenu(BillingUtility utility)
    {
        _utility=utility;
    }

    public void Show()
    {
        while (true)
        {
            Console.WriteLine("--- Billing & Payments Menu ---");
            Console.WriteLine("1. Generate Bill for Visit");
            Console.WriteLine("2. Record Payment");
            Console.WriteLine("3. View Outstanding Bills");
            Console.WriteLine("4. Generate Revenue Report");
            Console.WriteLine("5. Back");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    _utility.GenerateBill();
                    break;
                case 2:
                    _utility.RecordPayment();
                    break;
                case 3:
                    _utility.ViewOutstandingBills();
                    break;
                case 4:
                    _utility.GenerateRevenueReport();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
