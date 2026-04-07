using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Calculator2
    {
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new ArithmeticException("Cannot divide by zero");
            }

            return a / b;
        }
    }

}
