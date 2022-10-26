using System;
using CS_LABS.SUP_CLASSES;

namespace CS_LABS.LABS;

public class Quest7
{
    public void Main()
    { var vector = new Vector<int>();
        for (var i = 0; i < 10; i++) vector.Push(i);
        Console.WriteLine(vector.Print());
        vector.Include(99, 5);
        vector.Include(99, 9);
        Console.WriteLine(vector.Print());

        vector.Delete(3);
        Console.WriteLine(vector.Print());
        Console.WriteLine(vector.Count); }
}