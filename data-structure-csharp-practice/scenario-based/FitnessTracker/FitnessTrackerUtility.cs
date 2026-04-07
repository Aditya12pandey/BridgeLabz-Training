using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.FitnessTracker
{
    internal class FitnessTrackerUtility : IFitnessTracker
    {
        private CustomUserList users;

        public FitnessTrackerUtility()
        {
            users = new CustomUserList();
        }

        public void AddUser(string name, int steps)
        {
            if (users.Size() >= 20)
            {
                Console.WriteLine(" Group limit reached (max 20 users).");
                return;
            }

            if (steps < 0)
            {
                Console.WriteLine(" Steps cannot be negative!");
                return;
            }

            int index = users.FindIndexByName(name);
            if (index != -1)
            {
                Console.WriteLine(" User already exists! Use Update option.");
                return;
            }

            users.Add(new UserSteps(name, steps));
            Console.WriteLine(" User Added Successfully!");
        }

        public void UpdateSteps(string name, int newSteps)
        {
            if (newSteps < 0)
            {
                Console.WriteLine(" Steps cannot be negative!");
                return;
            }

            int index = users.FindIndexByName(name);
            if (index == -1)
            {
                Console.WriteLine(" User not found!");
                return;
            }

            users.Get(index).SetSteps(newSteps);
            Console.WriteLine(" Steps Updated Successfully!");

            // Real-time resorting due to frequent updates
            SortByStepsDesc();
        }

        public void DisplayAllUsers()
        {
            Console.WriteLine("\n All Users:");
            users.Display();
        }

        public void SortByStepsDesc()
        {
            if (users.Size() <= 1)
                return;

            // Bubble Sort DESC (highest steps first)
            for (int i = 0; i < users.Size() - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < users.Size() - 1 - i; j++)
                {
                    if (users.Get(j).Steps < users.Get(j + 1).Steps)
                    {
                        Swap(j, j + 1);
                        swapped = true;
                    }
                }

                // Optimization: if no swap, already sorted
                if (!swapped)
                    break;
            }
        }

        private void Swap(int i, int j)
        {
            UserSteps temp = users.Get(i);
            users.Set(i, users.Get(j));
            users.Set(j, temp);
        }

        public void DisplayLeaderboard()
        {
            if (users.Size() == 0)
            {
                Console.WriteLine("No users available to display leaderboard!");
                return;
            }

            SortByStepsDesc();

            Console.WriteLine("\n DAILY LEADERBOARD (Highest Steps First)");
            for (int i = 0; i < users.Size(); i++)
            {
                Console.WriteLine($"Rank {i + 1}: {users.Get(i).Name} - {users.Get(i).Steps} steps");
            }
        }
    }
}
