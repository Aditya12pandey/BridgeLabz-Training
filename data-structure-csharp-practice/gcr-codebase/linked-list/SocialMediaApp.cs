using System;
using System.Collections.Generic;

class UserProfile
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<int> FriendIds { get; set; }

    public UserProfile()
    {
        FriendIds = new List<int>();
    }

    public void Display()
    {
        Console.WriteLine($"User ID: {UserId}, Name: {Name}, Age: {Age}");
    }
}

class UserNode
{
    public UserProfile Data;
    public UserNode Next;

    public UserNode(UserProfile user)
    {
        Data = user;
        Next = null;
    }
}

class SocialMediaLinkedList
{
    private UserNode head;

    // Add User
    public void AddUser(UserProfile user)
    {
        UserNode newNode = new UserNode(user);
        newNode.Next = head;
        head = newNode;
        Console.WriteLine("User added successfully.");
    }

    // Find User by ID
    private UserProfile FindUser(int userId)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.Data.UserId == userId)
                return temp.Data;
            temp = temp.Next;
        }
        return null;
    }

    // Add Friend Connection
    public void AddFriendConnection(int id1, int id2)
    {
        UserProfile u1 = FindUser(id1);
        UserProfile u2 = FindUser(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("One or both users not found.");
            return;
        }

        if (!u1.FriendIds.Contains(id2))
            u1.FriendIds.Add(id2);

        if (!u2.FriendIds.Contains(id1))
            u2.FriendIds.Add(id1);

        Console.WriteLine("Friend connection added.");
    }

    // Remove Friend Connection
    public void RemoveFriendConnection(int id1, int id2)
    {
        UserProfile u1 = FindUser(id1);
        UserProfile u2 = FindUser(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("One or both users not found.");
            return;
        }

        u1.FriendIds.Remove(id2);
        u2.FriendIds.Remove(id1);

        Console.WriteLine("Friend connection removed.");
    }

    // Display Friends of a User
    public void DisplayFriends(int userId)
    {
        UserProfile user = FindUser(userId);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.WriteLine($"Friends of {user.Name}:");
        foreach (int fid in user.FriendIds)
            Console.Write(fid + " ");
        Console.WriteLine();
    }

    // Find Mutual Friends
    public void FindMutualFriends(int id1, int id2)
    {
        UserProfile u1 = FindUser(id1);
        UserProfile u2 = FindUser(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("One or both users not found.");
            return;
        }

        Console.WriteLine("Mutual Friends:");
        bool found = false;

        foreach (int fid in u1.FriendIds)
        {
            if (u2.FriendIds.Contains(fid))
            {
                Console.Write(fid + " ");
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No mutual friends.");
        else
            Console.WriteLine();
    }

    // Search User by ID
    public void SearchById(int id)
    {
        UserProfile user = FindUser(id);
        if (user != null)
            user.Display();
        else
            Console.WriteLine("User not found.");
    }

    // Search User by Name
    public void SearchByName(string name)
    {
        UserNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Data.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                temp.Data.Display();
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("User not found.");
    }

    // Count Friends for Each User
    public void CountFriends()
    {
        UserNode temp = head;

        while (temp != null)
        {
            Console.WriteLine($"{temp.Data.Name} has {temp.Data.FriendIds.Count} friends.");
            temp = temp.Next;
        }
    }
}

class SocialMediaApp
{
    static void Main()
    {
        SocialMediaLinkedList network = new SocialMediaLinkedList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Social Media Friend Connections ---");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Add Friend Connection");
            Console.WriteLine("3. Remove Friend Connection");
            Console.WriteLine("4. Display Friends of User");
            Console.WriteLine("5. Find Mutual Friends");
            Console.WriteLine("6. Search User by ID");
            Console.WriteLine("7. Search User by Name");
            Console.WriteLine("8. Count Friends for Each User");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    UserProfile user = new UserProfile();
                    Console.Write("User ID: ");
                    user.UserId = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    user.Name = Console.ReadLine();
                    Console.Write("Age: ");
                    user.Age = int.Parse(Console.ReadLine());
                    network.AddUser(user);
                    break;

                case 2:
                    Console.Write("User ID 1: ");
                    int u1 = int.Parse(Console.ReadLine());
                    Console.Write("User ID 2: ");
                    int u2 = int.Parse(Console.ReadLine());
                    network.AddFriendConnection(u1, u2);
                    break;

                case 3:
                    Console.Write("User ID 1: ");
                    int r1 = int.Parse(Console.ReadLine());
                    Console.Write("User ID 2: ");
                    int r2 = int.Parse(Console.ReadLine());
                    network.RemoveFriendConnection(r1, r2);
                    break;

                case 4:
                    Console.Write("User ID: ");
                    network.DisplayFriends(int.Parse(Console.ReadLine()));
                    break;

                case 5:
                    Console.Write("User ID 1: ");
                    int m1 = int.Parse(Console.ReadLine());
                    Console.Write("User ID 2: ");
                    int m2 = int.Parse(Console.ReadLine());
                    network.FindMutualFriends(m1, m2);
                    break;

                case 6:
                    Console.Write("User ID: ");
                    network.SearchById(int.Parse(Console.ReadLine()));
                    break;

                case 7:
                    Console.Write("Name: ");
                    network.SearchByName(Console.ReadLine());
                    break;

                case 8:
                    network.CountFriends();
                    break;

                case 0:
                    Console.WriteLine("Exiting Social Media System...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);
    }
}
