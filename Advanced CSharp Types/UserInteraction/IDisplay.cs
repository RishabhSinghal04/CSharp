namespace AdvancedCSharpTypes.UserInteraction;

public interface IDisplay
{
    void Display<T>(T message);
    void DisplayLine<T>(T message);
}
