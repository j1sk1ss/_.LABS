using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_LABS.SUP_CLASSES;

public class Arrays
{
    public static int[] ResizeArray(int[] array, int newSize)
    {
        var newArray = new int[newSize];
            for (var i = 0; i < array.Length; i++) newArray[i] = array[i];
        return newArray;
    }
    private readonly Random _random = new Random();
    public int[] FillArrayOfInts(int maxRand, int size)
    {
        var ar = new int[size];
        for (var i = 0; i < ar.Length; i++) ar[i] = _random.Next() % maxRand;
        return ar;
    }
    public double[] FillArrayOfDoubles(double maxRand, int size)
    {
        var ar = new double[size];
        for (var i = 0; i < ar.Length; i++) ar[i] = _random.NextDouble() % maxRand;
        return ar;
    }
    public int[,] FillDoubleArrayOfInts(int x, int y, int maxRand)
    {
        var array = new int[x, y];
        for (var i = 0; i < x; i++)
        for (var j = 0; j < y; j++)
            array[i, j] = _random.Next() % maxRand - 50;
        return array;
    }
    public static string PrintDoubleArray(int[,] array)
    {
        var matrix = "";
        for (var i = 0; i < array.GetLength(0); i++)
        {
            matrix += "\n";
            for (var j = 0; j < array.GetLength(1); j++) matrix += array[i,j] + " ";
        }
        return matrix;
    }
    public static string PrintArray(IEnumerable<int> array)
    {
        return array.Aggregate("", (current, t) => current + (" " + t));
    }
    public static string PrintDoubleArray(IEnumerable<double> array)
    {
        return array.Aggregate("", (current, t) => current + (" " + t));
    }
    public static IEnumerable<int> UniteArrays(int[] array1, int[] array2)
    {
        var ar = new int[array1.Length + array2.Length];
        int a = 0, b = 0, i = 0;
        while (a < array1.Length && b < array2.Length)
            if (array1[a] < array2[b]) ar[i++] = array1[a++];
                else ar[i++] = array2[b++];
        while (a < array1.Length) ar[i++] = array1[a++];
        while (b < array2.Length) ar[i++] = array2[b++];
        return ar;
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

    public static string PrintLowerTriangle(int[,] matrix)
    {
        var triangle = "";
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            triangle += "\n";
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (j <= i) triangle += matrix[i, j] + " ";
            }   
        }
        return triangle;
    }
}