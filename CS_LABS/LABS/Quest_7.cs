using System;
using CS_LABS.SUP_CLASSES;

namespace CS_LABS.LABS;

public class Quest7
{
    private readonly Labs _labs = new Labs();
    public void Main()
    {
        Console.WriteLine("Choose a work number: ");
        var q7 = new Quest7();
        var m = q7.GetType().GetMethod($"Work_{_labs.Math.ToInt(Console.ReadLine())}")?.Invoke(q7, null);
    }

    public void Work_1()
    {
        
    }
}