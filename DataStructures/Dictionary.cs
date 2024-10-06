namespace DataStructures;

public class Dictionary<TKey, TValue> where TKey : class
{
    private KeyValuePair[] _entries;
    private int _intialSize;
    private int _entriesCount;

    public Dictionary()
    {
        _intialSize = 3;
        _entries = new KeyValuePair[_intialSize];
    }

    public void Set(TKey key, TValue value)
    {
        for (int i = 0; i < _entries.Length; i++)
        {
            if ( _entries[i] != null && _entries[i].Key.Equals(key))
            {
                _entries[i].Value = value;
                return;
            }
        }
        ResizeOrNot();
        _entries[_entriesCount] = new KeyValuePair(key, value);
        _entriesCount++;
    }

    public TValue Get(TKey key)
    {
        for (int i = 0; i < _entries.Length; i++)
        {
            if ( _entries[i] != null && _entries[i].Key == key)
            {
                return _entries[i].Value;
            }
        }

        Console.WriteLine("Key not found");
        return default;
    }

    public bool Remove(TKey key)
    {
        for (int i = 0; i < _entries.Length; i++)
        {
            if (_entries[i] != null && _entries[i].Key.Equals(key))
            {
                _entries[i] = _entries[_entriesCount - 1];
                _entries[_entriesCount - 1] = null;
                _entriesCount--;
                return true;
            }
        }

        return false;
    }
    public void ResizeOrNot()
    {
        if(_entriesCount < _entries.Length - 1) return;
        
        int newSize = _entries.Length + _intialSize;
        Console.WriteLine($"Resizing array from {_entries.Length} entries to {newSize} entries.");
        
        KeyValuePair[] newArray = new KeyValuePair[newSize];
        Array.Copy(_entries, newArray, _entries.Length);
        _entries = newArray;
    }
    
    public int Size() => _entriesCount;

    public void Print()
    {
        Console.WriteLine("==================");
        Console.WriteLine($"[Size]: {Size()}");

        for (int i = 0; i < _entriesCount; i++)
        {
            if (_entries[i] == null) continue;
            Console.WriteLine($"{_entries[i].Key}: {_entries[i].Value}");
        }

        Console.WriteLine("===================");
    }
    class KeyValuePair
    {
        public TKey Key { get; }
        public TValue Value { get; set; }

        public KeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}