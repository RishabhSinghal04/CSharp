
using DiceRollGame.UserCommunication;

public class GuessingGame
{
    private readonly Dice _dice;
    private const int NumberOfTries = 3;

    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public GameResult Play()
    {
        var diceRollResult = _dice.Roll();
        Console.WriteLine($"Dice Rolled. Guess the number in {NumberOfTries} Tries.");
        var triesLeft = NumberOfTries;

        while (triesLeft > 0)
        {
            var guessNumber = ConsoleReader.ReadInteger("Enter a number: ");
            --triesLeft;

            if (guessNumber == diceRollResult)
            {
                return GameResult.Victory;
            }
            Console.WriteLine("Wrong Guess");
        }
        Console.WriteLine($"The number was {diceRollResult}");
        return GameResult.Loss;
    }

    public static void DisplayResult(GameResult gameResult)
    {
        string result = gameResult == GameResult.Victory
        ? "Congratulations, You Won!"
        : "You Lost :(\nBetter Luck Next Time";

        Console.WriteLine(result);
    }
}
