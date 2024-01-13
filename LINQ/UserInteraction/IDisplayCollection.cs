namespace Linq.UserInteraction;

public interface IDisplayCollection
{
    void Display<T>(IEnumerable<T> collection, in string separator);
    void Display<TKey, TValue>(IDictionary<TKey, TValue> collection);
    void Display<TKey, TValue>(ILookup<TKey, TValue> collection);
}