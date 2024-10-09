using System.Collections;
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
// Console.WriteLine($"Has Data: {myQueue.HasData()}");
// myQueue.Enqueue(15);
// myQueue.Enqueue(35);
// myQueue.Enqueue(17);
// myQueue.Print();
// Console.WriteLine($"Has Data: {myQueue.HasData()}");
// while (myQueue.HasData())
// {
//     Console.WriteLine("Top Element: " + myQueue.Dequeue());
//     Console.WriteLine("Queue Size: " + myQueue.Size());
//     myQueue.Print();
// }

#endregion

#region QueueArrayTesting

// QueueArray<int> queueArray = new QueueArray<int>();
//
// Console.WriteLine(queueArray.HasData());
// queueArray.Enqueue(1);
// queueArray.Enqueue(5);
// queueArray.Enqueue(7);
// queueArray.Enqueue(10);
// Console.WriteLine(queueArray.HasData());
//
// queueArray.Print();
//
// while (queueArray.HasData())
// {
//     Console.WriteLine($"Top data: {queueArray.Dequeue()}");
//     Console.WriteLine($"Size: {queueArray.Size}");
//     queueArray.Print();
// }


#endregion

#region DictionaryTesting

// DataStructures.Dictionary<string, string> dictionary = new DataStructures.Dictionary<string, string>();
// dictionary.Print();
//
// dictionary.Set("Sinar", "sinar@gmail.com");
// dictionary.Set("Elvis", "elvis@gmail.com");
// dictionary.Print();
//
// dictionary.Set("Tane", "tane@gmail.com");
// dictionary.Set("Gerti", "gerti@gmail.com");
// dictionary.Set("Arist", "arist@gmail.com");
//
// dictionary.Set("rArist", "rarist@gmail.com");
// dictionary.Set("tArist", "tarist@gmail.com");
// dictionary.Set("yArist", "yarist@gmail.com");
//
// dictionary.Print();
//
// Console.WriteLine(dictionary.Get("Tane"));
// Console.WriteLine(dictionary.Get("Elviaadsdfg"));
// Console.WriteLine(dictionary.Get("Sinar"));
// Console.WriteLine(dictionary.Get("Elviaaa"));
//
// dictionary.Remove("Sinar");
// dictionary.Remove("Elvis");
// dictionary.Remove("Tane");
// dictionary.Remove("Gerti");
// dictionary.Remove("Arist");
// dictionary.Print();
// dictionary.Set("Sinar", "sinar@gmail.com");
// dictionary.Print();
#endregion

#region HashTesting

// Hash.Hash32("Hello world");
//
// Hash.Hash64("Hello world");
// string x = "Hello world";
// Console.WriteLine(x.GetHashCode().ToString("x"));

    
#endregion

#region HashTableTesting
// HashTable<string, string> table = new HashTable<string, string>();
// table.Print();
// table.Set("Sinar", "sinar@gmail.com");
// table.Set("Elvis", "elvis@gmail.com");
// table.Set("Tane", "tane@gmail.com");
// table.Print();
// // Console.WriteLine("[get] " + table.Get("Sinar"));
// // //Console.WriteLine("[get] " + table.Get("Tane"));
// table.Set("Gerti", "gerti@gmail.com");
// table.Set("Arist", "arist@gmail.com");
// table.Print();
// // Console.WriteLine("[get] " + table.Get("Sinar"));
#endregion

#region BinaryTreeTesting
// BinaryTree<char> tree = new BinaryTree<char>();
// tree.Insert('A');
// tree.Insert('B');
// tree.Insert('C');
// tree.Insert('D');
// tree.Insert('E');
// tree.Insert('F');
// tree.Insert('G');
// tree.Insert('H');
// tree.Insert('I');
// tree.Print();
// Console.WriteLine();
//
// Console.WriteLine($"Height = {tree.Height()}");
// Console.WriteLine();
//
// tree.PreOrderTraversal();
//
// tree.InOrderTraversal();
//
// tree.PostOrderTraversal();
#endregion

#region BinarySearchTreeTesting
// BinaryTree<int> tree = new BinaryTree<int>();

// tree.BSInsert(4);
// tree.BSInsert(6);
// tree.BSInsert(7);
// tree.BSInsert(5);
// tree.BSInsert(2);
// tree.BSInsert(1);
// tree.BSInsert(3);
// tree.Print();
//
// tree.BSDelete(4);
// tree.Print();
// tree.BSDelete(6);
// tree.Print();
// tree.BSDelete(3);
// tree.BSDelete(5);
// tree.Print();
// tree.BSDelete(7);
// tree.Print();
// tree.BSDelete(2);
// tree.Print();
// tree.BSDelete(1);
// tree.Print();

  
// tree.BSInsert(1);
// tree.BSInsert(2);
// tree.BSInsert(3);
// tree.BSInsert(4);
// tree.BSInsert(5);
// tree.BSInsert(6);
// tree.BSInsert(7);
// tree.Print();
//
// tree.Balance();
// tree.Print();
#endregion

#region HeapTesting
// Heap<int> heap = new Heap<int>();
// heap.Insert(24);
// heap.Insert(32);
// heap.Insert(16);
// heap.Insert(45);
// heap.Insert(20);
// heap.Insert(53);
// heap.Insert(14);
// heap.Insert(27);
//
// heap.Print();
//
// heap.DrawHeap();
//
// Console.WriteLine();
// Console.WriteLine(heap.Pop());
// heap.DrawHeap();
// Console.WriteLine();
//
// Console.WriteLine(heap.Pop());
// Console.WriteLine();
// heap.DrawHeap();
// Console.WriteLine();
//
// Console.WriteLine(heap.Pop());
// Console.WriteLine();
// heap.DrawHeap();
// Console.WriteLine();
//
// Console.WriteLine(heap.Pop());
// Console.WriteLine();
// heap.DrawHeap();
// Console.WriteLine();
//
// Console.WriteLine(heap.Pop());
// Console.WriteLine();
// heap.DrawHeap();
// Console.WriteLine();
//
// Console.WriteLine(heap.Pop());
// Console.WriteLine();
// heap.DrawHeap();
// Console.WriteLine();
//
// Console.WriteLine(heap.Pop());
// Console.WriteLine();
// heap.DrawHeap();
// Console.WriteLine();
//
// Console.WriteLine(heap.Pop());
// Console.WriteLine();
// heap.DrawHeap();
// Console.WriteLine();

#endregion

#region PriorityQueueTesting

PriorityQueue<int> queue = new PriorityQueue<int>();
queue.Enqueue(5, 24);
queue.Enqueue(5, 32);
queue.Enqueue(3, 16);
queue.Enqueue(3, 45);
queue.Enqueue(1, 20);
queue.Enqueue(1, 53);
queue.Enqueue(2, 14);
queue.Enqueue(2, 27);

queue.Print();
queue.DrawHeap();

while(queue.HasData()){
    PqNode<int> result = queue.Dequeue();
    Console.WriteLine(result.Data + "[" + result.Priority+ "]");
}
#endregion