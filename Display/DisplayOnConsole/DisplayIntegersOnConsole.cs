namespace Display.DisplayOnConsole.cs;

using Display.UserInteraction;

public static class DisplayIntegersOnConsole
{
    public static void Display<T>(IEnumerable<T> collection, string separator)
    {
        IDisplayEnumerable displayEnumerable = new DisplayEnumerableOnConsole(
            new DisplayOnConsole()
        );
        displayEnumerable.Display(collection, separator);
    }
}