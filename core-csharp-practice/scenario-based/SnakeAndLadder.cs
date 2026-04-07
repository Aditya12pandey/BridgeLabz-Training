using System;

namespace BridgeLabzTraining.core_csharp_practice.scenario_based
{
    internal class SnakeAndLadder
    {
        // Ladder positions (start -> end)
        static int[,] ladders =
        {
            { 5, 27 }, { 9, 51 }, { 22, 60 }, { 28, 54 },
            { 44, 79 }, { 53, 69 }, { 66, 88 }, { 71, 92 }, { 85, 97 }
        };

        // Snake positions (head -> tail)
        static int[,] snakes =
        {
            { 13, 7 }, { 37, 19 }, { 80, 43 },
            { 86, 46 }, { 91, 49 }, { 99, 4 }
        };

        static Random random = new Random();

        static void Main()
        {
            StartGame();
        }

        static void StartGame()
        {
            Console.Write("Enter number of players (2–4): ");
            int playerCount = Convert.ToInt32(Console.ReadLine());

            if (playerCount < 2 || playerCount > 4)
            {
                Console.WriteLine("Invalid number of players!");
                return;
            }

            string[] players = new string[playerCount];
            int[] positions = new int[playerCount];

            for (int i = 0; i < playerCount; i++)
            {
                Console.Write($"Enter name of Player {i + 1}: ");
                players[i] = Console.ReadLine();
                positions[i] = 0;
            }

            bool gameOver = false;

            while (!gameOver)
            {
                for (int i = 0; i < playerCount; i++)
                {
                    Console.WriteLine($"\n{players[i]}'s turn. Press ENTER to roll dice...");
                    Console.ReadLine();

                    int dice = RollDice();
                    Console.WriteLine($"Dice rolled: {dice}");

                    int oldPosition = positions[i];
                    positions[i] = MovePlayer(positions[i], dice);
                    positions[i] = CheckSnakeOrLadder(positions[i]);

                    Console.WriteLine($"{players[i]} moved from {oldPosition} to {positions[i]}");

                    if (positions[i] == 100)
                    {
                        Console.WriteLine($"\n🎉 Congratulations {players[i]}! You won the game!");
                        gameOver = true;
                        break;
                    }
                }
            }
        }

        static int RollDice()
        {
            return random.Next(1, 7);
        }

        static int MovePlayer(int position, int dice)
        {
            if (position + dice <= 100)
            {
                position += dice;
            }
            else
            {
                Console.WriteLine("Move skipped! Dice exceeds 100.");
            }
            return position;
        }

        static int CheckSnakeOrLadder(int position)
        {
            for (int i = 0; i < ladders.GetLength(0); i++)
            {
                if (position == ladders[i, 0])
                {
                    Console.WriteLine($"🪜 Ladder! {position} → {ladders[i, 1]}");
                    return ladders[i, 1];
                }
            }

            for (int i = 0; i < snakes.GetLength(0); i++)
            {
                if (position == snakes[i, 0])
                {
                    Console.WriteLine($"🐍 Snake bite! {position} → {snakes[i, 1]}");
                    return snakes[i, 1];
                }
            }

            return position;
        }
    }
}
