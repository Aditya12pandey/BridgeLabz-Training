using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace review
{
    internal class BankMain
    {
        public static void Main(string[] args)
        {


            IBankAccount account = new BankAccount("ACC101", 5000);

            Console.WriteLine(" Welcome to Banking App ");
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            Console.WriteLine ("enter amount to deposite");
            double amnt = Convert.ToDouble(Console.ReadLine());
            account.deposit(amnt);
            Console.WriteLine("enter amount to Withdraw");
            double withdramAmnt = Convert.ToDouble(Console.ReadLine());

            account.withdraw(withdramAmnt);

            Console.WriteLine($"Final Balance: ₹{account.checkBalance()}");
        }
    }
}
