namespace Display.DisplayOnConsole.cs;

using Display.UserInteraction;

public static class DisplayDictionaryElementsOnConsole
{
    public static void Display<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
    {
        IDisplayDictionary displayDictionary = new DisplayDictionaryOnConsole(
            new DisplayOnConsole()
        );
        displayDictionary.Display(dictionary);
    }
}