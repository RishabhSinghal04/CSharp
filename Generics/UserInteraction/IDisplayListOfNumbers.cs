using System.Numerics;

namespace Generics.UserInteraction;

public interface IDisplayListOfNumbers
{
    void Display<T>(IEnumerable<T> items)
        where T : INumber<T>;
}