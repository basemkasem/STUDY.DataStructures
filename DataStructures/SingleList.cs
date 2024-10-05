namespace DataStructures;

public class LinkedListNode
{
    public int Data { get; set; }
    public LinkedListNode Next { get; set; }

    public LinkedListNode(int data)
    {
        Data = data;
    }
}

public class LinkedListIterator
{
    private LinkedListNode? _currentNode;

    public LinkedListIterator()
    {
        _currentNode = null;
    }

    public LinkedListIterator(LinkedListNode node)
    {
        _currentNode = node;
    }

    public int Data()
    {
        return _currentNode.Data;
    }

    public LinkedListIterator Next()
    {
        _currentNode = _currentNode.Next;
        return this;
    }

    public LinkedListNode Current()
    {
        return _currentNode;
    }
}

public class LinkedList
{
    private LinkedListNode Head { get; set; }
    private LinkedListNode Tail { get; set; }
    public int Length { get; private set; }

    public void InsertLast(int data)
    {
        LinkedListNode newNode = new LinkedListNode(data);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
        }

        Length++;
    }

    public void InsertAfter(int data, int newData)
    {
        LinkedListNode currentNode = Find(data);
        if (currentNode == null)
        {
            Console.WriteLine("The given data doesn't exist");
            return;
        }

        LinkedListNode newNode = new LinkedListNode(newData);
        newNode.Next = currentNode.Next;
        currentNode.Next = newNode;
        if (newNode.Next == null)
        {
            this.Tail = newNode;
        }

        Length++;
    }

    public void InsertBefore(int data, int newData)
    {
        LinkedListNode currentNode = Find(data);
        if (currentNode == null)
        {
            Console.WriteLine("The given data doesn't exist");
            return;
        }

        LinkedListNode newNode = new LinkedListNode(newData);
        newNode.Next = currentNode;
        LinkedListNode currentNodeParent = FindParent(currentNode);
        if (currentNodeParent == null)
        {
            Head = newNode;
        }
        else
        {
            currentNodeParent.Next = newNode;
        }

        Length++;
    }

    public void DeleteNode(LinkedListNode node)
    {
        if (node == null)
        {
            Console.WriteLine("The given data doesn't exist");
            return;
        }

        if (Head == Tail) Head = Tail = null;
        else if (node == Head) Head = node.Next;
        else
        {
            LinkedListNode nodeParent = FindParent(node);
            nodeParent.Next = node.Next;
            if (node == Tail)
            {
                Tail = nodeParent;
            }
            else
            {
                nodeParent.Next = node.Next;
            }
        }

        Length--;
    }

    public void DeleteNode(int data)
    {
        LinkedListNode node = Find(data);
        if (node == null)
        {
            Console.WriteLine("The given data doesn't exist");
            return;
        }

        if (Head == Tail) Head = Tail = null;
        else if (node == Head) Head = node.Next;
        else
        {
            LinkedListNode nodeParent = FindParent(node);
            nodeParent.Next = node.Next;
            if (node == Tail)
            {
                Tail = nodeParent;
            }
            else
            {
                nodeParent.Next = node.Next;
            }
        }

        Length--;
    }

    public LinkedListNode Find(int data)
    {
        for (LinkedListIterator itr = Begin(); itr.Current() != null; itr.Next())
        {
            if (itr.Data() == data)
                return itr.Current();
        }

        return null;
    }

    public LinkedListNode FindParent(LinkedListNode node)
    {
        for (LinkedListIterator itr = Begin(); itr.Current() != null; itr.Next())
        {
            if (itr.Current().Next == node)
                return itr.Current();
        }

        return null;
    }

    public void PrintList()
    {
        LinkedListIterator itr;
        for (itr = Begin(); itr.Current() != null; itr.Next())
        {
            Console.Write($"{itr.Data()} -> ");
        }

        Console.WriteLine("null");
    }

    public int Sum()
    {
        int sum = 0;
        for (LinkedListIterator itr = Begin(); itr.Current() != null; itr.Next())
        {
            sum += itr.Data();
        }

        return sum;
    }

    private LinkedListIterator Begin()
    {
        LinkedListIterator iterator = new LinkedListIterator(Head);
        return iterator;
    }
}