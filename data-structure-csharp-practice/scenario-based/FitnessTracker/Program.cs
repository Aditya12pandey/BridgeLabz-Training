using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.FitnessTracker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IFitnessTracker tracker = new FitnessTrackerUtility();

            while (true)
            {
                Console.WriteLine("\n FITNESS TRACKER MENU ");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Update Steps (Frequent Sync)");
                Console.WriteLine("3. Display All Users");
                Console.WriteLine("4. Display Leaderboard (Bubble Sort)");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                bool validChoice = int.TryParse(Console.ReadLine(), out int choice);

                if (!validChoice)
                {
                    Console.WriteLine(" Invalid input! Enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter User Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Steps: ");
                        int steps = Convert.ToInt32(Console.ReadLine());

                        tracker.AddUser(name, steps);
                        break;

                    case 2:
                        Console.Write("Enter User Name to Update: ");
                        string updateName = Console.ReadLine();

                        Console.Write("Enter New Steps: ");
                        int newSteps = Convert.ToInt32(Console.ReadLine());

                        tracker.UpdateSteps(updateName, newSteps);
                        break;

                    case 3:
                        tracker.DisplayAllUsers();
                        break;

                    case 4:
                        tracker.DisplayLeaderboard();
                        break;

                    case 0:
                        Console.WriteLine(" Exiting... Thank You!");
                        return;

                    default:
                        Console.WriteLine(" Invalid choice! Try again.");
                        break;
                }
            }
        }
    }
}
