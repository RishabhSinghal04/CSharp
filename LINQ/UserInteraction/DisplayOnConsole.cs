namespace Linq.UserInteraction;

public class DisplayOnConsole : IDisplay
{
    public void Display(in string message)
    {
        Console.WriteLine(message);
    }
}