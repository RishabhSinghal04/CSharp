namespace Display.UserInteraction;

public class DisplayOnConsole : IDisplay
{
    public void Display<T>(T message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }
        Console.Write(message);
    }

    public void DisplayLine<T>(T message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }
        Console.WriteLine(message);
    }
}