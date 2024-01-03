
using GameDataParser.App;
using GameDataParser.DataAccess;
using GameDataParser.Logging;
using GameDataParser.UserInteraction;
// using GameDataParser.Model;

/* static void VideoGamesSerializer()
{
    VideoGame game1 = new()
    {
        Title = "Resident Evil 4 Remake",
        ReleaseYear = 2023,
        Rating = 5.0m
    };

    VideoGame game2 = new()
    {
        Title = "Age of Empires 4",
        ReleaseYear = 2021,
        Rating = 4.9m
    };

    VideoGame game3 = new()
    {
        Title = "Oxygen Not Included",
        ReleaseYear = 2017,
        Rating = 4.8m
    };

    VideoGame game4 = new()
    {
        Title = "Red Dead Redemtpion II",
        ReleaseYear = 2018,
        Rating = 4.8m
    };

    VideoGame game5 = new()
    {
        Title = "Portal 2",
        ReleaseYear = 2011,
        Rating = 4.8m
    };

    VideoGame game6 = new()
    {
        Title = "Frostpunk",
        ReleaseYear = 2017,
        Rating = 4.7m
    };

    VideoGame game7 = new()
    {
        Title = "Stardew Valley",
        ReleaseYear = 2016,
        Rating = 4.9m
    };

    List<VideoGame> gameList = new() { game1, game2, game3, game4, game5,
                            game6, game7 };
    var options = new JsonSerializerOptions { WriteIndented = true };

    string jsonString = JsonSerializer.Serialize(gameList, options);
    File.WriteAllText("ListOfGames.json", jsonString);
} */

// VideoGamesSerializer();

ConsoleUserInteractor consoleUserInteractor = new();
Logger logger = new("log.txt");

GameDataParserConsoleApp consoleApp = new(
    new ConsoleUserInteractor(),
    new DisplayGames(consoleUserInteractor),
    new VideoGamesDeserializer(consoleUserInteractor),
    new LocalFileReader());

try
{
    consoleApp.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! The application has experienced an unexpected error.");
    logger.Log(ex);
}

Console.WriteLine("\nPress any key to exit....");
Console.ReadKey();