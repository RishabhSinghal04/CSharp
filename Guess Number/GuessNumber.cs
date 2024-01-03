
using System;

class GuessNumber
{
    private const ushort MAX_TURNS = 16;
    private static void Game()
    {
        Random @Random = new();
        const short MAX = 1001, MIN = -1000;
        short randonInteger = (short)@Random.Next(MIN, MAX);
        string? userInput;

        Console.Write($"""There is a random integer between "{MIN}" to "{MAX}" (both inclusive).""");
        Console.WriteLine($" Can you guess it in {MAX_TURNS} turns?");
        Console.WriteLine("Press 'Y' or 'y' to start the game");
        userInput = Console.ReadLine();

        if (userInput == null)
        {
            return;
        }
        if (userInput.Equals("y") || userInput.Equals("Y"))
        {
            ushort numOfTurns = BeginGame(randonInteger);

            if (numOfTurns == 0)
            {
                return;
            }
            Console.WriteLine(numOfTurns <= MAX_TURNS
                ? $"\nCongrats, you guess the number in {numOfTurns} turns."
                : $"\n{randonInteger} is the random integer\nBetter Luck Next Time!");
        }
    }

    private static ushort BeginGame(in short randonInteger)
    {
        ushort numOfTurns = 0;
        short guessInteger;
        do
        {
            string? userInput;

            Console.WriteLine("\n----> Enter an integer or press 'Q' or 'q' to quit:-");
            userInput = Console.ReadLine();
            bool isParsed = short.TryParse(userInput, out guessInteger);

            if (userInput == null)
            {
                continue;
            }
            else if (string.Equals(userInput, "Q", StringComparison.OrdinalIgnoreCase))
            {
                numOfTurns = 0;
                break;
            }
            else if (!isParsed)
            {
                continue;
            }
            ++numOfTurns;

            if (guessInteger > randonInteger)
            {
                Console.WriteLine($"\t{guessInteger} is greater than random integer");

            }
            else if (guessInteger < randonInteger)
            {
                Console.WriteLine($"\t{guessInteger} is less than random integer");
            }

        }
        while (guessInteger != randonInteger && numOfTurns <= MAX_TURNS);
        return numOfTurns;
    }

    static void Main()
    {
        Game();

        Console.WriteLine("\nPress any key to exit....");
        Console.ReadKey();
    }
}