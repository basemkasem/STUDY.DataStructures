using STUDY.DataStructures;

int[] array = { 1, 2, 3 };
Console.WriteLine(array.Length);
EnhancedArray.PrintArray(array);

EnhancedArray newResizedArray = new EnhancedArray();
newResizedArray.Resize<int>(ref array, 7);

Console.WriteLine(array.Length);
EnhancedArray.PrintArray(array);
