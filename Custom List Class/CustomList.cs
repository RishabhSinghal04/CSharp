namespace CustomListClass;

public class CustomList<T>
{
    private T[] _items = new T[10];
    private int _size = 0;

    public int Length { get => _size; init { } }

    public T this[int index]
    {
        get
        {
            ValidateIndex(index);
            return _items[index];
        }

        set
        {
            ValidateIndex(index);
            _items[index] = value;
        }
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new ArgumentOutOfRangeException($"Index {index} out of bounds");
        }
    }

    public void Add(T item)
    {
        if (_size >= _items.Length)
        {
            T[] newItems = new T[_items.Length * 2];

            for (int index = 0; index < _items.Length; ++index)
            {
                newItems[index] = _items[index];
            }
            _items = newItems;
        }
        _items[_size] = item;
        ++_size;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new ArgumentOutOfRangeException($"Index {index} out of range");
        }

        --_size;
        for (int i = index; i < _size; ++i)
        {
            _items[i] = _items[i + 1];
        }
        _items[_size] = default!;
    }
}