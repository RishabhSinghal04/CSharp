namespace Linq.UserInteraction;

public interface IDisplayCollection
{
    void Display<T>(IEnumerable<T> collection, in string separator);
}