using System;
using CS_LABS.SUP_CLASSES;

namespace CS_LABS.LABS;

public class Quest7
{
    public void Main()
    { var vector = new Vector();
        for (var i = 0; i < 10; i++) vector.Push(i);
        Console.WriteLine(vector.Print());
            vector.Include(99,5);
            vector.Include(99,9);
            Console.WriteLine(vector.Print());
            var sum = 0;
        for (var j = 0; j < vector.Count; j++)
        { sum += vector[j]; }
        vector.Delete(3);
        Console.WriteLine(vector.Print());
        Console.WriteLine(vector.Count); }
}