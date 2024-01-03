using System.Numerics;

namespace Generics.UserInteraction;

public class DisplayListOfNumbers : IDisplayListOfNumbers
{
    public void Display<T>(IEnumerable<T> items)
        where T : INumber<T>
    {
        foreach (var item in items)
        {
            Console.Write($"{item}, ");
        }
        Console.Write("\b\b \b" + Environment.NewLine);
    }
}