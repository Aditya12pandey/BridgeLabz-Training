using System;

class NumberGuessingGame
{
    static void Main()
    {
        Console.WriteLine("Think of a number between 1 and 100.");
        Console.WriteLine("I will try to guess it!");

        int min = 1, max = 100;
        bool guessed = false;

        while (!guessed)
        {
            int guess = GenerateGuess(min, max);
            string feedback = GetUserFeedback(guess);

            if (feedback == "correct")
            {
                Console.WriteLine("Yay! I guessed your number: " + guess);
                guessed = true;
            }
            else if (feedback == "high")
            {
                max = guess - 1;
            }
            else if (feedback == "low")
            {
                min = guess + 1;
            }
            else
            {
                Console.WriteLine("Invalid input. Please type 'high', 'low', or 'correct'.");
            }
        }
    }

    static int GenerateGuess(int min, int max)
    {
        Random rand = new Random();
        return rand.Next(min, max + 1);
    }

    static string GetUserFeedback(int guess)
    {
        Console.Write($"Is {guess} too high, too low, or correct? ");
        return Console.ReadLine().ToLower();
    }
}
