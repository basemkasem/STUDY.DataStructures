using System.Text;

namespace DataStructures;

public class HashTable<TKey, TValue> where TKey : class
{
    private KeyValuePair[] _entries;
    private int _intialSize;
    private int _entriesCount;

    public HashTable()
    {
        _intialSize = 3;
        _entriesCount = 0;
        _entries = new KeyValuePair[_intialSize];   
    }
    
    public int Hash(TKey key)
    {
        uint fnvOffsetBasis = 2166136261;
        uint fnvPrime = 16777619; 
        
        byte[] data = Encoding.ASCII.GetBytes(key.ToString());
        
        uint hash = fnvOffsetBasis;
        for (int i = 0; i < data.Length; i++)
        {
            hash = hash ^ data[i];
            hash = hash * fnvPrime;
        }

        Console.WriteLine($"[Hash] {key.ToString()}, {hash}, {hash.ToString("x")}, {hash % (uint)_entries.Length}");
        return (int)(hash % (uint)_entries.Length);
    }

    public int CollisionHandling(TKey key, int hash, bool set)
    {
        int newHash;
        for (int i = 1; i < _entries.Length; i++)
        {
            newHash = (hash + i) % _entries.Length;
            Console.WriteLine("[coll] " + key.ToString() + " " + hash + ", new hash: " + newHash);
            if (set && (_entries[newHash] == null || _entries[newHash].Key == key))
            {
                return newHash;
            }
            else if (!set && _entries[newHash].Key == key)
            {
                return newHash;
            }
        }
        return -1;
    }

    public void AddToEntry(TKey key, TValue value)
    {
        int hash = Hash(key);
        if (_entries[hash] != null && _entries[hash].Key != key)
        {
            hash = CollisionHandling(key, hash, true);
        }

        if (hash == -1)
        {
            throw new KeyNotFoundException("Invalid hashtable!");
        }

        if (_entries[hash] == null)
        {
            KeyValuePair newPair = new KeyValuePair(key, value);
            _entries[hash] = newPair;
            _entriesCount++;
        }
        else if (_entries[hash].Key == key)
        {
            _entries[hash].Value = value;
        }
        else
        {
            throw new KeyNotFoundException("Invalid hashtable!");
        }
    }
    
    public void ResizeOrNot()
    {
        if(_entriesCount < _entries.Length ) return;
        
        int newSize = _entries.Length * 2;
        Console.WriteLine($"Resizing array from {_entries.Length} entries to {newSize} entries.");
        KeyValuePair[] entriesCopy = new KeyValuePair[_entries.Length];
        Array.Copy(_entries,  entriesCopy, _entries.Length);
        _entries = new KeyValuePair[newSize];
        _entriesCount = 0;

        for (int i = 0; i < entriesCopy.Length; i++)
        {
            if(entriesCopy[i] == null) continue;
            AddToEntry(entriesCopy[i].Key, entriesCopy[i].Value);
        }
    }

    public void Set(TKey key, TValue value)
    {
        ResizeOrNot();
        AddToEntry(key, value);
    }

    public TValue Get(TKey key)
    {
        int hash = Hash(key);
        if (_entries[hash] != null && _entries[hash].Key != key)
        {
            CollisionHandling(key, hash, false);
        }

        if (hash == -1 || _entries[hash] == null)
        {
            return default;
        }

        if (_entries[hash].Key == key)
        {
            return _entries[hash].Value;
        }
        else
        {
            throw new KeyNotFoundException("Invalid hashtable!");
        }
    }
    
    public int Size() => _entriesCount;

    public void Print()
    {
        Console.WriteLine("==================");
        Console.WriteLine($"[Size]: {Size()}");

        for (int i = 0; i < _entries.Length; i++)
        {
            if (_entries[i] == null) Console.WriteLine($"[{i}] null");
            else
                Console.WriteLine($"[{i}] {_entries[i].Key}: {_entries[i].Value}");
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