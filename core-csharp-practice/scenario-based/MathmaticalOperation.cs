//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraning.ScenarioBased
//{
//    internal class MathmaticalOperation
//    {
//        // 1. Factorial
//        public static long Factorial(int n)
//        {
//            if (n < 0)
//                return -1;

//            long fact = 1;
//            for (int i = 1; i <= n; i++)
//            {
//                fact *= i;
//            }
//            return fact;
//        }

//        // 2. Prime Check
//        public static bool IsPrime(int n)
//        {
//            if (n <= 1)
//                return false;

//            for (int i = 2; i <= n / 2; i++)
//            {
//                if (n % i == 0)
//                    return false;
//            }
//            return true;
//        }

//        // 3. GCD
//        public static int GCD(int a, int b)
//        {
//            if (a < 0) a = -a;
//            if (b < 0) b = -b;

//            while (b != 0)
//            {
//                int temp = b;
//                b = a % b;
//                a = temp;
//            }
//            return a;
//        }

//        // 4. Fibonacci
//        public static int Fibonacci(int n)
//        {
//            if (n < 0)
//                return -1;

//            if (n == 0) return 0;
//            if (n == 1) return 1;

//            int a = 0, b = 1, c = 0;
//            for (int i = 2; i <= n; i++)
//            {
//                c = a + b;
//                a = b;
//                b = c;
//            }
//            return c;
//        }

//        // Main Method
//        public static void Main()
//        {
//            int choice;
//            do
//            {
//                Console.WriteLine("\n=== Math Utility Menu ===");
//                Console.WriteLine("1. Factorial");
//                Console.WriteLine("2. Prime Check");
//                Console.WriteLine("3. GCD");
//                Console.WriteLine("4. Fibonacci");
//                Console.WriteLine("5. Exit");
//                Console.Write("Enter your choice: ");

//                choice = int.Parse(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        Console.Write("Enter a number: ");
//                        int factNum = int.Parse(Console.ReadLine());
//                        long fact = Factorial(factNum);
//                        if (fact == -1)
//                            Console.WriteLine("Factorial not defined for negative numbers.");
//                        else
//                            Console.WriteLine("Factorial = " + fact);
//                        break;

//                    case 2:
//                        Console.Write("Enter a number: ");
//                        int primeNum = int.Parse(Console.ReadLine());
//                        Console.WriteLine(IsPrime(primeNum)
//                            ? "Number is Prime"
//                            : "Number is Not Prime");
//                        break;

//                    case 3:
//                        Console.Write("Enter first number: ");
//                        int a = int.Parse(Console.ReadLine());
//                        Console.Write("Enter second number: ");
//                        int b = int.Parse(Console.ReadLine());
//                        Console.WriteLine("GCD = " + GCD(a, b));
//                        break;

//                    case 4:
//                        Console.Write("Enter n: ");
//                        int fibNum = int.Parse(Console.ReadLine());
//                        int fib = Fibonacci(fibNum);
//                        if (fib == -1)
//                            Console.WriteLine("Fibonacci not defined for negative numbers.");
//                        else
//                            Console.WriteLine("Fibonacci number = " + fib);
//                        break;

//                    case 5:
//                        Console.WriteLine("Exiting program...");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid choice!");
//                        break;
//                }

//            } while (choice != 5);
//        }
//    }
//}
