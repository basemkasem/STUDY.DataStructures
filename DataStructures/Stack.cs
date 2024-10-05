using DataStructures.DoubleLinkedList;

namespace DataStructures;

public class Stack<T>
{
    private DoubleLinkedList<T> _dataList;

    public Stack()
    {
        _dataList = new DoubleLinkedList<T>();
    }

    public void Push(T item)
    {
        _dataList.InsertFirst(item);
    }
    public T Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty.");
        T head = _dataList.Head.Data;
        _dataList.DeleteHead();
        return head;
    }
    public T Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty.");
        return _dataList.Head.Data;
    }
    public bool IsEmpty()
    {
        return _dataList.Length <= 0;
    }
    public void Print()
    {
        _dataList.PrintList();
    }
    public int Size()
    {
        return _dataList.Length;
    }
}