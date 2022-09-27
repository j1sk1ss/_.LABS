using System;
using System.IO;
using System.Text;
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

    private static void Work_1()
    {
        Console.WriteLine("This work where part of text from file will deleted:");
        var path = @"C:\Users\tghhs\RiderProjects\CS_LABS\CS_LABS\";
        var tmp =File.ReadAllText($"{path}Test.txt", Encoding.UTF8);
        Console.WriteLine(tmp);
        var tmp2 = tmp.Substring(0, tmp.Length / 2);
        using (var sw = new StreamWriter($"{path}Test.txt"))
        {
            sw.Write(tmp2);
        }
    }
        // Test
    private void Work_2()
    {
        
    }
}