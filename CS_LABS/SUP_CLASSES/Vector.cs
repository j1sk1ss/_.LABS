using System;
using System.Linq;

namespace CS_LABS.SUP_CLASSES;
internal class Vector
{
    private int[] _array;
    public int Count { get; set; }
    public Vector()
    { _array = Array.Empty<int>();
       Count = 0; }
    public Vector(int[] array)
    { _array = array;
        Count = array.Length; }
    public static Vector operator +(Vector obj1, Vector obj2)
    { Vector ar = new()
        { _array = obj1._array.Concat(obj2._array).ToArray(),
            Count = obj1.Count + obj2.Count };
        return ar; }
    public int this[int key]
    { get => GetElement(key);
        set => SetElement(key, value); }
    private int GetElement(int index) {
        return _array[index]; }
    private void SetElement(int index, int value) {
        _array[index] = value; }
    public void Include(int value, int position)
    { var ar = new int[_array.Length + 1];
        for (var j = 0; j < _array.Length + 1; j++)
            if (j < position) ar[j] = _array[j];
            else
            { if (j == position) ar[j++] = value;
               ar[j] = _array[j - 1]; }
        _array = ar;
        Count = ar.Length; }
    public void Delete(int position)
    {var ar = new int[_array.Length - 1];
        for (var j = 0; j < ar.Length; j++)
            if (j < position) ar[j] = _array[j];
            else { if (j >= position) ar[j] = _array[j + 1]; }
        _array = ar;
        Count = ar.Length; }
    public void Push(int value)
    { var ar = new int[_array.Length + 1];
        for (var j = 0; j < _array.Length; j++) ar[j] = _array[j];
        ar[^1] = value;
        _array = ar; }
    public string Print()
    { return _array.Aggregate("", (current, t) => current + (t + "; ")); }
}