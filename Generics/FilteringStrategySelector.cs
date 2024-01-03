
using System.Numerics;

public class FilteringStrategySelector<T> where T : INumber<T>
{
    private readonly Dictionary<string, Func<T, bool>> _filteringStrategies = new()
    {
        {"positive", number => number >= (dynamic)0},
        {"negative", number => number < (dynamic)0},
        {"even", number => number % (dynamic)2 == 0},
        {"odd", number => number % (dynamic)2 == 1},
    };

    public IEnumerable<string> FilteringStrategiesNames => _filteringStrategies.Keys;

    public Func<T, bool> Select(string filteringType)
    {
        if (!_filteringStrategies.ContainsKey(filteringType))
        {
            throw new NotSupportedException($"{filteringType} is not a valid type");
        }
        return _filteringStrategies[filteringType];
    }
}
