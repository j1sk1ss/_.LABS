using CS_LABS.INTERFACES;
namespace CS_LABS.SUP_CLASSES;
public class MyStack<T> : Vector<T>, IVector<T> {
    public void Clear() {
        Array.Clear();
    }
    public bool Contains(T value) {
        return Array.Contains(value);
    }
    public T Pop() {
        var ans = Array[^1];
        var ar = new T[Count - 1];
        for (var j = 0; j < Count - 1; j++) {
            ar[j] = Array[j];
        }
        Count--;
        return ans;
    }
    public T Peek()
    {
        return Array[^1];
    }
}