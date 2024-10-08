using DataStructures.DoubleLinkedList;
namespace DataStructures;

public class Queue<T>
{
    private DoubleLinkedList<T> _queue;
    

    public Queue()
    {
        _queue = new DoubleLinkedList<T>();
    }

    public void Enqueue(T item)
    {
        _queue.InsertLast(item);
    }

    public T Dequeue()
    {
        if (!HasData()) return default;
        T result = _queue.Head.Data;
        _queue.DeleteHead();
        return result;
    }

    public T Peek()
    {
        return _queue.Head.Data;
    }

    public bool HasData()
    {
        return Size() > 0;
    }

    public int Size()
    {
        return _queue.Length;
    }

    public void Print()
    {
        _queue.PrintList();
    }
    
}