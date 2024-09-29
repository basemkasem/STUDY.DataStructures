using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

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

    public static T GetAt<T>(T[] source, int index, int sizeOf)
    {
        if (index < 0) return default(T);
        ref byte zeroAddress = ref MemoryMarshal.GetArrayDataReference((Array)source);
        ref byte indexRefrence = ref Unsafe.Add(ref zeroAddress, index * sizeOf);
        ref T item = ref Unsafe.As<byte, T>(ref indexRefrence);

        return item;
    }
}
