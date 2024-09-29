using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDY.DataStructures;

public class EnhancedArray
{
    public void Resize<T>(ref T[] source, int newSize)
    {
        if (newSize <= 0 || source == null) return;
        T[] newArray = new T[newSize];
        Buffer.BlockCopy(source,0, newArray, 0, Buffer.ByteLength(source));
        source = newArray;
    }

    public static void PrintArray<T>(T[] array) 
    {
        Console.WriteLine("{" + String.Join(", ", array) + "}");
    }
}
