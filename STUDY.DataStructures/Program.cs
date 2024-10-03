using DataStructures;

//int[] array = { 1, 2, 3 };
//Console.WriteLine(array.Length);
//EnhancedArray.PrintArray(array);

//EnhancedArray newResizedArray = new EnhancedArray();
//newResizedArray.Resize<int>(ref array, 7);

//Console.WriteLine(array.Length);
//EnhancedArray.PrintArray(array);


//var item = EnhancedArray.GetAt(array, 2, sizeof(int));
//Console.WriteLine(item);

LinkedList list = new LinkedList();
list.InsertLast(1);
list.InsertLast(2);
list.InsertLast(3);
list.InsertAfter(2, 7);
list.InsertAfter(1, 65);
list.InsertAfter(2, 90);
list.InsertBefore(1, 99);
list.DeleteNode(0);
list.PrintList();