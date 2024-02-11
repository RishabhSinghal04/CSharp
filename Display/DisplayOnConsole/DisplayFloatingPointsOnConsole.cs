namespace Display.DisplayOnConsole.cs;

using Display.UserInteraction;

public static class DisplayFloatingPointsOnConsole
{
    public static void Display<T>(IEnumerable<T> collection,
        string separator, int precision = 4)
    {
        IDisplayEnumerable displayEnumerable = new DisplayEnumerableOnConsole(
            new DisplayOnConsole()
        );
        displayEnumerable.Display(collection, separator);
    }
}