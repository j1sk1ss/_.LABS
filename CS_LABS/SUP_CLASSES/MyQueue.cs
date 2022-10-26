using System;
using System.Linq;
using CS_LABS.INTERFACES;
namespace CS_LABS.SUP_CLASSES;
public class MyQueue<T> : Vector<T>, IVector<T> {
    public void Clear() {
        Array.Clear();
    }
    public bool Contains(T value) {
        return Array.Contains(value);
    }
    public T Dequeue() {
        var ans = Array[0];
        var ar = new T[Count - 1];
        for (var j = 1; j < Count; j++) ar[j] = Array[j - 1];
        Array = ar.ToList();
        Count--;
        return ans;
    }
    public T Peek() {
        return Array[0];
    }
}