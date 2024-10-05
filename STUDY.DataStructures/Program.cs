using DataStructures;
using DataStructures.DoubleLinkedList;

#region EnhancedArrayTesting

//int[] array = { 1, 2, 3 };
//Console.WriteLine(array.Length);
//EnhancedArray.PrintArray(array);

//EnhancedArray newResizedArray = new EnhancedArray();
//newResizedArray.Resize<int>(ref array, 7);

//Console.WriteLine(array.Length);
//EnhancedArray.PrintArray(array);

//var item = EnhancedArray.GetAt(array, 2, sizeof(int));
//Console.WriteLine(item);

#endregion

#region SinglLinkedListTesting

// LinkedList list = new LinkedList();
// list.InsertLast(1);
// list.InsertLast(2);
// list.InsertLast(3);
// list.InsertAfter(2, 7);
// list.InsertAfter(1, 65);
// list.InsertAfter(2, 90);
// list.InsertBefore(1, 99);
// list.DeleteNode(0);
// list.PrintList();

#endregion

#region DoublyLinkedListTesting

// DoubleLinkedList<int> list = new DoubleLinkedList<int>();
// list.InsertLast(1);
// list.InsertLast(2);
// list.InsertLast(3);
// list.InsertAfter(2, 7);
// list.InsertAfter(1, 65);
// // list.InsertAfter(2, 90);
// list.InsertBefore(1, 65);
// //list.DeleteNode(65);
// list.PrintList();
// Console.WriteLine(list.Length);
//
// DoubleLinkedList<string> strList = new DoubleLinkedList<string>();
// strList.InsertLast("Hello");
// strList.InsertLast("World");
// strList.InsertAfter("Hello","my");
// strList.InsertBefore("Hello","Welcome");
// strList.DeleteNode("null");
// strList.PrintList();
// Console.WriteLine(strList.Length);

#endregion

#region StackTesting

// DataStructures.Stack<int> myStack = new DataStructures.Stack<int>();
// Console.WriteLine($"Is empty: {myStack.IsEmpty()}");
// myStack.Push(15);
// myStack.Push(35);
// myStack.Push(146);
// myStack.Push(23);
// myStack.Push(85);
// Console.WriteLine($"Is empty: {myStack.IsEmpty()}");
// // Console.WriteLine($"Length: {myStack.Size()}");
// // Console.WriteLine(myStack.Peek());
// //Console.WriteLine(myStack.Pop());
// myStack.Print();
// while (!myStack.IsEmpty())
// {
//     Console.WriteLine(myStack.Pop());
//     Console.WriteLine(myStack.Size());
//     myStack.Print();
// }


// StackArray<int> myStackArray = new StackArray<int>();
// Console.WriteLine($"Is empty: {myStackArray.IsEmpty()}");
// myStackArray.Push(1);
// myStackArray.Push(5);
// myStackArray.Push(87);
// myStackArray.Push(54);
// myStackArray.Push(99);
//
// myStackArray.Print();
// // //Console.WriteLine($"Is empty: {myStackArray.IsEmpty()}");
//
// Console.WriteLine(myStackArray.Peek());
// myStackArray.Print();
//Console.WriteLine(myStackArray.Pop());
//Console.WriteLine(myStackArray.Pop());
//myStackArray.Print();
//Console.WriteLine(myStackArray.Size());
// while (!myStackArray.IsEmpty())
// {
//     Console.WriteLine(myStackArray.Pop());
//     Console.WriteLine(myStackArray.Size());
//     myStackArray.Print();
// }

#endregion

#region QueueTesting

// DataStructures.Queue<int> myQueue = new DataStructures.Queue<int>();
// Console.WriteLine($"Is empty: {myQueue.IsEmpty()}");
// myQueue.Enqueue(15);
// myQueue.Enqueue(35);
// myQueue.Enqueue(17);
// myQueue.Print();
// Console.WriteLine($"Is empty: {myQueue.IsEmpty()}");
// while (!myQueue.IsEmpty())
// {
//     Console.WriteLine("Top Element: " + myQueue.Dequeue());
//     Console.WriteLine("Queue Size: " + myQueue.Size());
//     myQueue.Print();
// }

#endregion

#region QueueArrayTesting

QueueArray<int> queueArray = new QueueArray<int>();

Console.WriteLine(queueArray.HasData());
queueArray.Enqueue(1);
queueArray.Enqueue(5);
queueArray.Enqueue(7);
queueArray.Enqueue(10);
Console.WriteLine(queueArray.HasData());

queueArray.Print();

while (queueArray.HasData())
{
    Console.WriteLine($"Top data: {queueArray.Dequeue()}");
    Console.WriteLine($"Size: {queueArray.Size}");
    queueArray.Print();
}


#endregion