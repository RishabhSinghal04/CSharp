
public class Filter
{
    public static IEnumerable<T> FilterBy<T>(Func<T, bool> predicate,
        IEnumerable<T> collection)
    {
        List<T> result = new();
        foreach (var item in collection)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
}