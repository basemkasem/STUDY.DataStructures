namespace DataStructures;

public class QueueArray<T>
{
    private T[] _queue;
    private int _initialSize;
    private int _topIndex;
    private int _lastIndex;

    public int Size { get; private set; }
    
    public QueueArray()
    {
        _initialSize = 4;
        _queue = new T[_initialSize];
        _topIndex = 0;
        _lastIndex = -1;
        Size = 0;
    }
    private void Resize()
    {
        if (_lastIndex < _queue.Length - 1) return;
        Console.WriteLine("Array is resizing...");
        T[] newArray = new T[_queue.Length + _initialSize];
        Buffer.BlockCopy(_queue,0, newArray, 0, Buffer.ByteLength(_queue));
        _queue = newArray;
    }
    public void Enqueue(T item)
    {
        _lastIndex++;
        if (!HasData())
        {
            _queue[_topIndex] = item;
        }
        else
        {
            _queue[_lastIndex] = item;
        }

        Size++;
    }

    public T Dequeue()
    {
        if (!HasData()) return default;
        T result = _queue[_topIndex];
        _queue[_topIndex] = default;
        _topIndex++;
        Size--;
        return result;
    }

    public T Peek()
    {
        return _queue[_topIndex];
    }

    public bool HasData()
    {
        return Size > 0;
    }

    public void Print()
    {
        for (int i = 0 ; i <= _queue.Length - 1 ; i++)
        {
            if (AreEqual(_queue[i], default))
            {
                continue;
            }
            Console.Write($"{_queue[i]} <- ");
        }
        Console.WriteLine("null");
    }
    
    public bool AreEqual(T data1, T data2)
    {
        return EqualityComparer<T>.Default.Equals(data1, data2);
    }
    
}