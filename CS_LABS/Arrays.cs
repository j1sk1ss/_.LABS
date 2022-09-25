using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_LABS;

public class Arrays
{
    private readonly Random _random = new Random();
    public int[] FillArrayOfInts(int maxRand, int size)
    {
        var ar = new int[size];
        for (var i = 0; i < ar.Length; i++) ar[i] = _random.Next() % maxRand;
        return ar;
    }

    public static string PrintArray(IEnumerable<int> array)
    {
        return array.Aggregate("", (current, t) => current + (" " + t));
    }
    public int[] UniteArrays(int[] array1, int[] array2)
    {
        var unary = new int[array1.Length + array2.Length];
        for (var i = 0; i < array1.Length; i++) unary[i] = array1[i];
        for (var i = array1.Length; i < array1.Length + array2.Length; i++) unary[i] = array2[i - array1.Length];
        return unary;
    }
    public static IEnumerable<int> Sort(int[] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            for (var j = 0; j < array.Length; j++)
            {
                var tmp = array[j];
                if (j >= array.Length - 1 || tmp <= array[j + 1]) continue;
                    tmp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = tmp;
            }
        }
        return array;
    }
}