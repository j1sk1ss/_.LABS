using System;
using CS_LABS.SUP_CLASSES;
using Math = CS_LABS.SUP_CLASSES.Math;

namespace CS_LABS.LABS;

public class Quest4
{
    private readonly Math _math = new Math();
    private readonly Labs _labs = new Labs();
    private readonly Arrays _array = new Arrays();
    public void Main()
    {
        var voids = new Action[3];
        voids[0] = Work_1;
        _labs.AddVoids(voids);
        Console.WriteLine("Choose a work number: ");
        _labs.Works[_math.ToInt(Console.ReadLine())]();
    }

    private static void Work_1()
    {
        
    }
}