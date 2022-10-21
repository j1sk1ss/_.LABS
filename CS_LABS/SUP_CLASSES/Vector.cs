using System;
using System.Linq;
namespace CS_LABS.SUP_CLASSES;

public class Vector
{
    protected int[] Array { get; set; }
    public int Count { get; protected set; }
    public Vector()
    { Array = System.Array.Empty<int>();
       Count = 0; }
    public Vector(int[] array)
    { Array = array;
        Count = array.Length; }
    public static Vector operator +(Vector obj1, Vector obj2)
    { Vector ar = new()
        { Array = obj1.Array.Concat(obj2.Array).ToArray(),
            Count = obj1.Count + obj2.Count };
        return ar; }
    public int this[int key]
    { get => Array[key];
        set => SetElement(key, value); }
    private void SetElement(int index, int value) {
        Array[index] = value; }
    public void Include(int value, int position)
    { var ar = new int[Array.Length + 1];
        for (var j = 0; j < Array.Length + 1; j++)
            if (j < position) ar[j] = Array[j];
            else
            { if (j == position) ar[j++] = value;
               ar[j] = Array[j - 1]; }
        Array = ar;
        Count = ar.Length; }
    public void Delete(int position)
    {var ar = new int[Array.Length - 1];
        for (var j = 0; j < ar.Length; j++)
            if (j < position) ar[j] = Array[j]; 
            else { if (j >= position) ar[j] = Array[j + 1]; }
        Array = ar;
        Count = ar.Length; }
    public void Push(int value)
    { var ar = new int[Array.Length + 1];
        for (var j = 0; j < Array.Length; j++) ar[j] = Array[j];
        ar[^1] = value;
        Array = ar;
        Count++; }
    public string Print()
    { return Array.Aggregate("", (current, t) => current + (t + "; ")); }
}