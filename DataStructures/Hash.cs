using System.Text;

namespace DataStructures;

public class Hash
{
    public static uint Hash32(string str)
    {
        uint offsetBasis = 2166136261;
        uint FNVPrime = 16777619; 
        
        byte[] data = Encoding.UTF8.GetBytes(str);
        
        uint hash = offsetBasis;
        for (int i = 0; i < data.Length; i++)
        {
            hash ^= data[i];
            hash = hash * FNVPrime;
        }

        Console.WriteLine(str + ", " + hash + ", " + hash.ToString("x"));
        return hash;
    }
    
    public static ulong Hash64(string str)
    {
        ulong offsetBasis = 14695981039346656037;
        ulong FNVPrime = 1099511628211; 
        
        byte[] data = Encoding.UTF8.GetBytes(str);
        
        ulong hash = offsetBasis;
        for (int i = 0; i < data.Length; i++)
        {
            hash ^= data[i];
            hash = hash * FNVPrime;
        }

        Console.WriteLine(str + ", " + hash + ", " + hash.ToString("x"));
        return hash;
    }
}