namespace DataStructures;

public class PriorityQueue<T> where T : IComparable<T>
{
    private PqNode<T>[] _dataList; 
    private int _initialSize;
    private int _entriesCount;
    
    public PriorityQueue()
    {
        _initialSize = 8;
        _entriesCount = 0;
        _dataList = new PqNode<T>[_initialSize];
    }

    public void Enqueue(int priority, T item)
    {
        ResizeOrNot();
        int i = _entriesCount;
        _dataList[i] = new PqNode<T>() {Data = item, Priority = priority };
        _entriesCount++;
        
        int parentIndex = (i - 1) / 2;
        while (i != 0 && _dataList[i].Priority.CompareTo(_dataList[parentIndex].Priority) < 0)
        {
            PqNode<T> temp = _dataList[i];
            _dataList[i] = _dataList[parentIndex];
            _dataList[parentIndex] = temp;
            i = parentIndex;
            parentIndex = (i - 1) / 2;
        }

    }

    public PqNode<T> Dequeue()
    {
        if (_entriesCount == 0) return default;
        int i = 0;
        PqNode<T> deletedNode = _dataList[i];
        
        _dataList[i] = _dataList[_entriesCount - 1];
        _dataList[_entriesCount - 1] = default;
        _entriesCount--;
        int leftIndex = (2 * i) + 1;

        while (leftIndex < _entriesCount)
        {
            //leftIndex = (2 * i) + 1;
            int rightIndex = (2 * i) + 2;
            
            int smallest = leftIndex;

            if (_dataList[rightIndex] != null && _dataList[rightIndex].Priority.CompareTo(_dataList[leftIndex].Priority) < 0)
            {
                smallest = rightIndex;
            }
            
            if (_dataList[smallest].Priority.CompareTo(_dataList[i].Priority) >= 0)
            {
                break;
            }

            PqNode<T> temp = _dataList[i];
            _dataList[i] = _dataList[smallest];
            _dataList[smallest] = temp;
            
            i = smallest;
            leftIndex = (2 * i) + 1;
        }
    return deletedNode;
    }

    public bool HasData()
    {
        return _entriesCount > 0;
    }
    
    public void Print()
    {
        for (int i = 0; i < _entriesCount; i++)
        {
            Console.Write(_dataList[i].Data + " -> ");
        }
        Console.WriteLine();
    
    }

    public void DrawHeap()
    {
        int height = (int)Math.Ceiling(Math.Log2(_entriesCount + 1)) - 1;
    
        int maxLevelNodes = (int)Math.Pow(2, height);
        int maxSpace = maxLevelNodes * 2;
    
        for (int level = 0; level <= height; level++)
        {
            int levelNodes = (int)Math.Pow(2, level);
            int spaceBetween = maxSpace / levelNodes;
    
            for (int i = 0; i < levelNodes && (int)Math.Pow(2, level) - 1 + i < _entriesCount; i++)
            {
                int index = (int)Math.Pow(2, level) - 1 + i;
                Console.Write(new string(' ', spaceBetween / 2));
                Console.Write(_dataList[index].Data);
                Console.Write(new string(' ', spaceBetween / 2));
            }
            Console.WriteLine();
        }
    }
    
    public void ResizeOrNot()
    {
        if(_entriesCount < _dataList.Length - 1) return;
        
        int newSize = _dataList.Length + _initialSize;
        Console.WriteLine($"Resizing array from {_dataList.Length} entries to {newSize} entries.");
        
        PqNode<T>[] newArray = new PqNode<T>[newSize];
        Array.Copy(_dataList, newArray, _dataList.Length);
        _dataList = newArray;
    }
    
}
public class PqNode<T>
     {
         public T Data{get;set;}
         public int Priority { get; set; }
 
     }