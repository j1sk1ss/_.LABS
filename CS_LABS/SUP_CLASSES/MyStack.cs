using System;

namespace CS_LABS.SUP_CLASSES;

public class MyStack : Vector
{
    public void Clear()
    {
        Array = System.Array.Empty<int>();
    }

    public bool Contains(int value)
    {
        for (var i = 0; i < Count; i++)
            if (Array[i] == value)
                return true;
        return false;
    }

    public int Pop()
    {
        var ans = Array[^1];
        var ar = new int[Count - 1];
        for (var j = 0; j < Count - 1; j++)
        {
            ar[j] = Array[j];
        }

        Count--;
        return ans;
    }

    public int Peek()
    {
        return Array[^1];
    }
}