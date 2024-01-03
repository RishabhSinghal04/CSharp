
using GameDataParser.Model;

namespace GameDataParser.UserInteraction;

public class DisplayGames : IDisplayGames
{
    private readonly IUserInteractor _userInteractor;

    public DisplayGames(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void Display(List<VideoGame>? videoGames)
    {
        if (videoGames?.Any() != true)
        {
            _userInteractor.DisplayMessage("No games are present in input file.");
            return;
        }

        string newLine = Environment.NewLine;
        _userInteractor.DisplayMessage($"{newLine}Loaded Games are:-{newLine}");

        foreach (var videoGame in videoGames)
        {
            _userInteractor.DisplayMessage($"{videoGame}{newLine}");
        }
    }
}