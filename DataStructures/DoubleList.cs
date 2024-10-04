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
    private DoubleLinkedListNode<T> Head { get; set; }
    private DoubleLinkedListNode<T> Tail { get; set; }
    public int Length { get; private set; }
    private DoubleLinkedListIterator<T> Begin()
    {
        DoubleLinkedListIterator<T> iterator = new DoubleLinkedListIterator<T>(Head);
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

    public bool AreEqual(T data1, T data2)
    {
        return EqualityComparer<T>.Default.Equals(data1, data2);
    }

    public void InsertLast(T data)
    {
        DoubleLinkedListNode<T> newNode = new DoubleLinkedListNode<T>(data);
        if (Tail == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }

        Length++;
    }

    public void InsertAfter(T data, T newData)
    {
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
            Tail = newNode;
        }
        else
        {
            newNode.Previous.Next = newNode;
        }
        Length++;
    }

    public void InsertBefore(T data, T newData)
    {
        DoubleLinkedListNode<T> currentNode = Find(data);
        if (currentNode == null)
        {
            Console.WriteLine("The given data doesn't exist");
            return;
        }

        DoubleLinkedListNode<T> newNode = new DoubleLinkedListNode<T>(newData);
        newNode.Next = currentNode;
        if (currentNode == Head)
        {
            Head = newNode;
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

        if (Head == Tail)
        {
            Head = null;
            Tail = null;
        }
        else if (node.Previous == null)
        {
            Head = node.Next;
            node.Next.Previous = null;
        }
        else if (node.Next == null)
        {
            Tail = node.Previous;
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

        if (Head == Tail)
        {
            Head = null;
            Tail = null;
        }
        else if (node.Previous == null)
        {
            Head = node.Next;
            node.Next.Previous = null;
        }
        else if (node.Next == null)
        {
            Tail = node.Previous;
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

    public DoubleLinkedListNode<T> FindParent(DoubleLinkedListNode<T> node)
    {
        for (DoubleLinkedListIterator<T> itr = Begin(); itr.Current() != null; itr.Next())
        {
            if (itr.Current().Next == node)
                return itr.Current();
        }

        return null;
    }
    
    //TODO: Create CopyList Method
    
}