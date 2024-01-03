
using System.Numerics;

namespace Linq.UserInteraction;

public class DisplayCollectionOnConsole : IDisplayCollection
{
    public void Display<T>(IEnumerable<T> collection, in string separator)
    {
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
}