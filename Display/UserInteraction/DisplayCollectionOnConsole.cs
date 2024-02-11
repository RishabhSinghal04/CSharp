
using System.Numerics;
using System.Text;

namespace Display.UserInteraction;

public class DisplayEnumerableOnConsole : IDisplayEnumerable
{
    private readonly IDisplay _display;

    public DisplayEnumerableOnConsole(IDisplay display)
    {
        _display = display;
    }

    public void Display<T>(IEnumerable<T> collection,
        string separator, int precision = 4)
    {
        if (collection is null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if (!collection.Any())
        {
            _display.DisplayLine("Collection is empty");
            return;
        }

        StringBuilder stringBuilder = new();
        bool isFloatingPoint = typeof(IFloatingPoint<>).IsAssignableFrom(typeof(T));

        foreach (var item in collection)
        {
            stringBuilder.Append(isFloatingPoint ?
                string.Format("{0:f" + precision + "}", item) : $"{item}")
                .Append(separator);
        }

        stringBuilder.Length -= separator.Length;
        _display.DisplayLine(stringBuilder);
    }
}

public class DisplayDictionaryOnConsole : IDisplayDictionary
{
    private readonly IDisplay _display;

    public DisplayDictionaryOnConsole(IDisplay display)
    {
        _display = display;
    }

    public void Display<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
    {
        if (dictionary is null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }
        if (!dictionary.Any())
        {
            _display.DisplayLine("Dictionary is empty");
            return;
        }

        StringBuilder stringBuilder = new();

        foreach (var item in dictionary)
        {
            stringBuilder.Append($"{item.Key} : {item.Value}{Environment.NewLine}");
        }
        _display.DisplayLine(stringBuilder);
    }
}

public class DisplayLookupOnConsole : IDisplayLookup
{
    private readonly IDisplay _display;

    public DisplayLookupOnConsole(IDisplay display)
    {
        _display = display;
    }

    public void Display<TKey, TValue>(ILookup<TKey, TValue> lookup)
    {
        if (lookup is null)
        {
            throw new ArgumentNullException(nameof(lookup));
        }
        if (!lookup.Any())
        {
            _display.DisplayLine("Lookup is empty");
            return;
        }

        StringBuilder stringBuilder = new();

        foreach (var key in lookup)
        {
            stringBuilder.Append($"{key.Key} : ");
            foreach (var value in key)
            {
                stringBuilder.Append($"{value}{Environment.NewLine}");
            }
        }
        _display.DisplayLine(stringBuilder);
    }
}