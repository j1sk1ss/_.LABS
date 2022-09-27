using System;
using CS_LABS.SUP_CLASSES;

namespace CS_LABS.LABS;

public class Quest6
{
    private readonly Labs _labs = new Labs();
    public void Main()
    {
        var voids = new Action[2];
        voids[0] = Work_1;
        _labs.AddVoids(voids);
        Console.WriteLine("Choose a work number: ");
        _labs.Works[_labs.Math.ToInt(Console.ReadLine())]();
    }

    private void Work_1()
    {
        
    }
}