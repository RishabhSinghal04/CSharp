
using System.Numerics;

namespace Linq.UserInteraction;

public class DisplayCollectionOnConsole : IDisplayCollection
{
    public void Display<T>(IEnumerable<T> collection, in string separator)
    {
        if (!collection.Any())
        {
            Console.WriteLine("Collection is empty");
            return;
        }
        bool isFloatingPoint = typeof(IFloatingPoint<>).IsAssignableFrom(typeof(T));

        if (isFloatingPoint)
        {
            foreach (var item in collection)
            {
                Console.Write(string.Format("{0:F4}", item) + separator);
            }
        }
        else
        {
            foreach (var item in collection)
            {
                Console.Write($"{item}{separator}");
            }
        }
        Console.WriteLine("\b\b \b");
    }

    public void Display<TKey, TValue>(IDictionary<TKey, TValue> collection)
    {
        if (!collection.Any())
        {
            Console.WriteLine("Collection is empty");
            return;
        }

        foreach (var item in collection)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }

    public void Display<TKey, TValue>(ILookup<TKey, TValue> collection)
    {
        if (!collection.Any())
        {
            Console.WriteLine("Collection is empty");
            return;
        }

        foreach (var key in collection)
        {
            Console.Write($"{key.Key} : ");
            foreach (var value in key)
            {
                Console.WriteLine($"{value}");
            }
        }
    }
}