namespace DataStructures.DoubleLinkedList;

public class DoubleLinkedListNode<T>
{
    public T Data { get; set; }
    public DoubleLinkedListNode<T> Next { get; set; }
    public DoubleLinkedListNode<T> Previous { get; set; }

    public DoubleLinkedListNode(T data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

public class DoubleLinkedListIterator<T>
{
    private DoubleLinkedListNode<T> _currentNode;

    public DoubleLinkedListIterator()
    {
        _currentNode = null;
    }

    public DoubleLinkedListIterator(DoubleLinkedListNode<T> node)
    {
        _currentNode = node;
    }

    public T Data()
    {
        return _currentNode.Data;
    }

    public DoubleLinkedListIterator<T> Next()
    {
        _currentNode = _currentNode.Next;
        return this;
    }

    public DoubleLinkedListNode<T> Current()
    {
        return _currentNode;
    }
}

public class DoubleLinkedList<T>
{
    private DoubleLinkedListNode<T> _head;
    private DoubleLinkedListNode<T> _tail;
    private bool _unique;
    public int Length { get; private set; }
    public DoubleLinkedList(bool unique = false)
    {
        _head = null;
        _tail = null;
        _unique = unique;
    }
    private DoubleLinkedListIterator<T> Begin()
    {
        DoubleLinkedListIterator<T> iterator = new DoubleLinkedListIterator<T>(_head);
        return iterator;
    }
    public void PrintList()
        {
            DoubleLinkedListIterator<T> itr;
            for (itr = Begin(); itr.Current() != null; itr.Next())
            {
                Console.Write($"{itr.Data()} -> ");
            }
    
            Console.WriteLine("null");
        }
    public DoubleLinkedListNode<T> Find(T data)
    {
        for (DoubleLinkedListIterator<T> itr = Begin(); itr.Current() != null; itr.Next())
        {
            //  itr.Data() == data
            //cheack Here!!!!!
            if (AreEqual(itr.Data(), data))
                return itr.Current();
        }

        return null;
    }

    public bool IsExist(T data) => Find(data) != null;
    public bool AreEqual(T data1, T data2)
    {
        return EqualityComparer<T>.Default.Equals(data1, data2);
    }

    public bool CanInsert(T data)
    {
        if (_unique && IsExist(data))
        {
            Console.WriteLine("Already exist");
            return false;
        }
        return true;
    }
    public void InsertLast(T data)
    {
        if(!CanInsert(data)) return;
        
        DoubleLinkedListNode<T> newNode = new DoubleLinkedListNode<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Previous = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }

        Length++;
    }

    public void InsertAfter(T data, T newData)
    {
        if(!CanInsert(newData)) return;
        
        DoubleLinkedListNode<T> currentNode = Find(data);
        if (currentNode == null)
        {
            Console.WriteLine("The given data doesn't exist");
            return;
        }

        DoubleLinkedListNode<T> newNode = new DoubleLinkedListNode<T>(newData);
        newNode.Next = currentNode.Next;
        newNode.Previous = currentNode;
        currentNode.Next = newNode;
        if (newNode.Next == null)
        {
            _tail = newNode;
        }
        else
        {
            newNode.Previous.Next = newNode;
        }
        Length++;
    }

    public void InsertBefore(T data, T newData)
    {
        if(!CanInsert(newData)) return;
        DoubleLinkedListNode<T> currentNode = Find(data);
        if (currentNode == null)
        {
            Console.WriteLine("The given data doesn't exist");
            return;
        }

        DoubleLinkedListNode<T> newNode = new DoubleLinkedListNode<T>(newData);
        newNode.Next = currentNode;
        if (currentNode == _head)
        {
            _head = newNode;
        }
        else
        {
            currentNode.Previous.Next = newNode;
        }
        currentNode.Previous = newNode;
        Length++;
    }

    public void DeleteNode(DoubleLinkedListNode<T> node)
    {
        if (node == null)
        {
            Console.WriteLine("The given data doesn't exist");
            return;
        }

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (node.Previous == null)
        {
            _head = node.Next;
            node.Next.Previous = null;
        }
        else if (node.Next == null)
        {
            _tail = node.Previous;
            node.Previous.Next = null;
        }
        else
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }

        node = null;
        Length--;
    }

    public void DeleteNode(T data)
    {
        DoubleLinkedListNode<T> node = Find(data);
        if (node == null)
        {
            Console.WriteLine("The given data doesn't exist");
            return;
        }

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (node.Previous == null)
        {
            _head = node.Next;
            node.Next.Previous = null;
        }
        else if (node.Next == null)
        {
            _tail = node.Previous;
            node.Previous.Next = null;
        }
        else
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }

        node = null;
        Length--;
    }
    
    //TODO: Create CopyList Method
    
}