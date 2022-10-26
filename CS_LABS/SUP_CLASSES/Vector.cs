using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CS_LABS.SUP_CLASSES;
public class Vector<T> {
    protected List<T> Array { get; set; }
    public int Count { get; set; }
    public Vector() {
        Array = new List<T>();
        Count = 0;
    }
    public Vector(IReadOnlyCollection<T> array) {
        Array = array.ToList();
        Count = array.Count;
    }
    public static Vector<T> operator +(Vector<T> obj1, Vector<T> obj2) {
        Vector<T> ar = new() {
            Array = obj1.Array.Concat(obj2.Array).ToList(),
            Count = obj1.Count + obj2.Count
        };
        return ar;
    }
    public T this[int key] {
        get => Array[key];
        set => SetElement(key, value);
    }
    private void SetElement(int index, T value) {
        Array[index] = value;
    }
    public void Include(T value, int position)
    {
        var ar = new T[Array.Count + 1];
        for (var j = 0; j < Array.Count + 1; j++)
            if (j < position)
                ar[j] = Array[j];
            else {
                if (j == position) ar[j++] = value;
                ar[j] = Array[j - 1];
            }
        Array = ar.ToList();
        Count = ar.Length;
    }
    public void Delete(int position) {
        Array.RemoveAt(position);
    }
    public void Push(T value) {
        Array.Add(value);
    }
    public string Print() {
        return Array.Aggregate("", (current, t) => current + (t + "; "));
    }
    ~Vector() {
        Array.Clear();
        Count = 0;
    }
}