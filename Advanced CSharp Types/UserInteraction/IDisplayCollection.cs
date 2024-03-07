namespace AdvancedCSharpTypes.UserInteraction;

public interface IDisplayEnumerable
{
    void Display<T>(IEnumerable<T> enumerable, string separator = ", ", int precision = 4);
}

public interface IDisplayDictionary
{
    void Display<TKey, TValue>(IDictionary<TKey, TValue> dictionary);
}

public interface IDisplayLookup
{
    void Display<TKey, TValue>(ILookup<TKey, TValue> lookup);
}