
namespace GameDataParser.UserInteraction;

public interface IUserInteractor
{
    string ReadValidFilePath();
    void DisplayMessage(in string message);
    void DisplayError(in string message);

}
