using System;

class Friends
{
    static void Main()
    {
        Console.Write("Enter age of Amar: ");
        int ageAmar = int.Parse(Console.ReadLine());

        Console.Write("Enter age of Akbar: ");
        int ageAkbar = int.Parse(Console.ReadLine());

        Console.Write("Enter age of Anthony: ");
        int ageAnthony = int.Parse(Console.ReadLine());

        Console.Write("Enter height of Amar (in cm): ");
        double heightAmar = double.Parse(Console.ReadLine());

        Console.Write("Enter height of Akbar (in cm): ");
        double heightAkbar = double.Parse(Console.ReadLine());

        Console.Write("Enter height of Anthony (in cm): ");
        double heightAnthony = double.Parse(Console.ReadLine());

        int youngestAge = ageAmar;
        string youngestFriend = "Amar";

        if (ageAkbar < youngestAge)
        {
            youngestAge = ageAkbar;
            youngestFriend = "Akbar";
        }

        if (ageAnthony < youngestAge)
        {
            youngestAge = ageAnthony;
            youngestFriend = "Anthony";
        }

        Console.WriteLine("The youngest friend is " + youngestFriend + " with age " + youngestAge);

        // Find tallest friend
        double tallestHeight = heightAmar;
        string tallestFriend = "Amar";

        if (heightAkbar > tallestHeight)
        {
            tallestHeight = heightAkbar;
            tallestFriend = "Akbar";
        }

        if (heightAnthony > tallestHeight)
        {
            tallestHeight = heightAnthony;
            tallestFriend = "Anthony";
        }

        Console.WriteLine("The tallest friend is " + tallestFriend + " with height " + tallestHeight + " cm");
    }
}
