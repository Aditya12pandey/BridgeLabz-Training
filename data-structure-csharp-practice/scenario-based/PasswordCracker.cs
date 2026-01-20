using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure
{
    internal class PasswordCracker
    {
        static bool found = false;      // to stop once password matched
        static long attempts = 0;       // count tries

        static void CrackPassword(char[] chars, char[] current, int index, string password)
        {
            if (found) return; // Scenario B stop if already found

            // If length completed
            if (index == current.Length)
            {
                attempts++;
                string guess = new string(current);

                Console.WriteLine("Trying: " + guess);

                if (guess == password)
                {
                    Console.WriteLine("\n Password Found: " + guess);
                    found = true;
                }
                return;
            }

            // Backtracking logic
            for (int i = 0; i < chars.Length; i++)
            {
                current[index] = chars[i];                
                CrackPassword(chars, current, index + 1, password); // explore
            }
        }

        static void Main()
        {
            Console.WriteLine(" Password Cracker Simulator (Backtracking) ");

            Console.Write("Enter password length (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter allowed characters (example: abc123): ");
            string set = Console.ReadLine();

            Console.Write("Enter password to crack: ");
            string password = Console.ReadLine();

            char[] chars = set.ToCharArray();
            char[] current = new char[n];

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Scenario A + B
            CrackPassword(chars, current, 0, password);

            sw.Stop();

            Console.WriteLine("\n Result ");
            if (!found)
                Console.WriteLine(" Password NOT found in given charset and length!");
            else
                Console.WriteLine(" Vault Unlocked!");

            Console.WriteLine("\nTotal Attempts: " + attempts);
            Console.WriteLine("Time Taken: " + sw.ElapsedMilliseconds + " ms");

            // Scenario C: Complexity
            Console.WriteLine("\n Complexity (Scenario C) ");
            Console.WriteLine("Time Complexity: O(k^n)");
            Console.WriteLine("Where k = character set size = " + chars.Length);
            Console.WriteLine("And n = password length = " + n);
            Console.WriteLine("Space Complexity: O(n) (recursion + current password array)");

        }
    }
}
