using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.FitnessTracker
{
    internal class CustomUserList
    {
        private UserSteps[] arr;
        private int size;

        public CustomUserList()
        {
            arr = new UserSteps[5];
            size = 0;
        }

        public void Add(UserSteps u)
        {
            if (size == arr.Length)
            {
                Grow();
            }

            arr[size] = u;
            size++;
        }

        private void Grow()
        {
            UserSteps[] newArr = new UserSteps[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
        }

        public int Size()
        {
            return size;
        }

        public UserSteps Get(int index)
        {
            if (index < 0 || index >= size)
                return null;

            return arr[index];
        }

        public void Set(int index, UserSteps value)
        {
            if (index >= 0 && index < size)
                arr[index] = value;
        }

        public int FindIndexByName(string name)
        {
            for (int i = 0; i < size; i++)
            {
                if (arr[i].Name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }

        public void Display()
        {
            if (size == 0)
            {
                System.Console.WriteLine("No users found!");
                return;
            }

            for (int i = 0; i < size; i++)
            {
                System.Console.WriteLine($"{i + 1}. {arr[i]}");
            }
        }
    }
}
