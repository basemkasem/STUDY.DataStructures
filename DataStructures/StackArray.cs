namespace DataStructures;

public class StackArray<T>
{
    private T[] _dataList;
    private int _topIndex;
    private int _initialSize;
    public StackArray()
    {
        _initialSize = 3;
        _dataList = new T[_initialSize];
        _topIndex = -1;
    }

    private void Resize()
    {
        if (_topIndex < _dataList.Length - 1) return;
        Console.WriteLine("Array is resizing...");
        T[] newArray = new T[_dataList.Length + _initialSize];
        Buffer.BlockCopy(_dataList,0, newArray, 0, Buffer.ByteLength(_dataList));
        _dataList = newArray;
    }

    public void Push(T item)
    {
        Resize();
        _dataList[++_topIndex] = item;
    }
    public T Pop()
    {
        if (_topIndex == -1) return default;
        T head = _dataList[_topIndex];
        _dataList[_topIndex] = default;
        _topIndex--;
        return head;
    }
    public T Peek()
    {
        if (_topIndex == -1) return default;
        return _dataList[_topIndex];
    }
    public bool IsEmpty()
    {
        return _topIndex < 0;
    }
    public void Print()
    {
        for (int i = _topIndex; i >= 0; i--)
        {
            Console.Write(_dataList[i] + " -> ");
        }
        Console.WriteLine();
    }

    public int Size()
    {
        return _topIndex + 1;
    }
}