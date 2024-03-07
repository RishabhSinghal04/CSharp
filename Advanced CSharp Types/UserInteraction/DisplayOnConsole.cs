namespace AdvancedCSharpTypes.UserInteraction;

public class DisplayOnConsole : IDisplay
{
    private readonly string nullExceptionMessage = "Argument is null";
    public void Display<T>(T message)
    {
        if (message is null)
        {
            throw new ArgumentNullException($"{nameof(message)} {nullExceptionMessage}");
        }
        Console.Write(message);
    }

    public void DisplayLine<T>(T message)
    {
        if (message is null)
        {
            throw new ArgumentNullException($"{nameof(message)} {nullExceptionMessage}");
        }
        Console.WriteLine(message);
    }
}