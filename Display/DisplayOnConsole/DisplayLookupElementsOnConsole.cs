namespace Display.DisplayOnConsole.cs;

using Display.UserInteraction;

public static class DisplayLookupElementsOnConsole
{
    public static void Display<TKey, TValue>(ILookup<TKey, TValue> lookup)
    {
        IDisplayLookup displayLookup = new DisplayLookupOnConsole(
            new DisplayOnConsole()
        );
        displayLookup.Display(lookup);
    }
}