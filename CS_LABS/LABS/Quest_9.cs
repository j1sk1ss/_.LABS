using System;
using System.Collections.Generic;
using CS_LABS.SUP_CLASSES;

namespace CS_LABS.LABS;

public class Quest9
{
    public void Main()
    {
        var lst = new ListOfRolls<int>();
        for (var i = 0; i < 10; i++)
        {
            lst.Add(new Roll<int>
            {
                Data = new List<int> {i,2,i,4,i,6,i,8,i,10},
                Count = 10
            });
        }
        Console.WriteLine(lst.Print());
        Console.WriteLine(lst.Remove(new List<int>{2,2,2,4,2,6,2,8,2,10}));
        Console.WriteLine(lst.Print());
        Console.WriteLine(lst.Contains(new []{3,2,3,4,3,6,3,8,3,10}));
    }
}