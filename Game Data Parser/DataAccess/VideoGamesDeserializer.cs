using System.Text.Json;
using GameDataParser.Model;
using GameDataParser.UserInteraction;

namespace GameDataParser.DataAccess;

public class VideoGamesDeserializer : IVideoGamesDeserializer
{
    private readonly IUserInteractor _userInteractor;

    public VideoGamesDeserializer(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public List<VideoGame>? DeserializeFrom(
        string fileName, string fileContent)
    {
        try
        {
            return JsonSerializer.Deserialize<List<VideoGame>>(fileContent);
        }
        catch (JsonException ex)
        {
            _userInteractor.DisplayError(
                $"JSON in {fileName} file was not in a valid format. JSON BODY");
            _userInteractor.DisplayError(fileContent);

            throw new JsonException($"{ex.Message} The file is {fileName}", ex);
        }
    }
}
