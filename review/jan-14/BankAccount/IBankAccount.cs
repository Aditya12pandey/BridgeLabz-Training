using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace review
{
    internal interface IBankAccount
    {
        void deposit(double Amount);
        void withdraw(double Amount);

        double checkBalance();
    }
}
