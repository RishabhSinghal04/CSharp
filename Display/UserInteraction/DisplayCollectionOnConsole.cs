
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

        StringBuilder stringBuilder = new();
        bool isFloatingPoint = typeof(IFloatingPoint<>).IsAssignableFrom(typeof(T));

        foreach (var item in collection)
        {
            stringBuilder.Append(isFloatingPoint ?
                string.Format("{0:f" + precision + "}", item) : $"{item}")
                .Append(separator);
        }

        if(stringBuilder.Length == 0)
        {
            _display.DisplayLine("Collection is empty");
            return;
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
            return;
        }

        StringBuilder stringBuilder = new();

        foreach (var item in dictionary)
        {
            stringBuilder.Append($"{item.Key} : {item.Value}{Environment.NewLine}");
        }

        if(stringBuilder.Length == 0)
        {
            _display.DisplayLine("Collection is empty");
            return;
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

        StringBuilder stringBuilder = new();

        foreach (var key in lookup)
        {
            stringBuilder.Append($"{key.Key} : ");
            foreach (var value in key)
            {
                stringBuilder.Append($"{value}{Environment.NewLine}");
            }
        }
        
        if(stringBuilder.Length == 0)
        {
            _display.DisplayLine("Collection is empty");
            return;
        }
        _display.DisplayLine(stringBuilder);
    }
}