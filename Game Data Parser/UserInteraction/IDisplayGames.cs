
using GameDataParser.Model;

namespace GameDataParser.UserInteraction;

public interface IDisplayGames
{
    void Display(List<VideoGame>? videoGames);
}
