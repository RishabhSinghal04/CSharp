
using GameDataParser.DataAccess;
using GameDataParser.Model;
using GameDataParser.UserInteraction;

namespace GameDataParser.App;

public class GameDataParserConsoleApp
{
    private readonly IUserInteractor _userInteractor;
    private readonly IDisplayGames _displayGames;
    private readonly IVideoGamesDeserializer _videoGamesDeserializer;
    private readonly IFileReader _fileReader;

    public GameDataParserConsoleApp(
        IUserInteractor userInteractor, IDisplayGames displayGames,
        IVideoGamesDeserializer videoGamesDeserializer, IFileReader fileReader)
    {
        _userInteractor = userInteractor;
        _displayGames = displayGames;
        _videoGamesDeserializer = videoGamesDeserializer;
        _fileReader = fileReader;
    }

    public void Run()
    {
        string fileName = _userInteractor.ReadValidFilePath();
        var fileContent = _fileReader.Read(fileName);
        List<VideoGame>? videoGames = _videoGamesDeserializer.DeserializeFrom(
            fileName, fileContent);
        _displayGames.Display(videoGames);
    }
}
