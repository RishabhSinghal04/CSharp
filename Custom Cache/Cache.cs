

public class Cache<TKey, TData>
{
    private readonly Dictionary<TKey, TData> _cachedData = new();

    public TData Get(TKey key, Func<TKey, TData> getForFirstTime)
    {
        if (!_cachedData.ContainsKey(key))
        {
            _cachedData[key] = getForFirstTime(key);
        }
        return _cachedData[key];
    }
}
