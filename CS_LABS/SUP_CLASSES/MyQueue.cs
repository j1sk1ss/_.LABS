namespace CS_LABS.SUP_CLASSES;
public class MyQueue : Vector
{ public void Clear() {
        Array = System.Array.Empty<int>(); }
    public bool Contains(int value) {
        for (var i = 0; i < Count; i++)
            if (Array[i] == value)
                return true;
        return false; }
    public int Dequeue()
    { var ans = Array[0];
        var ar = new int[Count - 1];
            for (var j = 1; j < Count; j++) ar[j] = Array[j - 1];
            Array = ar;
        Count--;
        return ans; }
    public int Peek() {
        return Array[0]; }
}