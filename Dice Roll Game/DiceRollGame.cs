
var random = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);
GameResult gameResult = guessingGame.Play();

GuessingGame.DisplayResult(gameResult);
Console.WriteLine("\nPress a key to exit....");
Console.ReadKey();
