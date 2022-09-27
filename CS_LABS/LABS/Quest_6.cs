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
        var voids = new Action[3];
        voids[0] = Work_1;
        voids[1] = Work_2;
        voids[2] = Work_3;
        _labs.AddVoids(voids);
        Console.WriteLine("Choose a work number: ");
        _labs.Works[_labs.Math.ToInt(Console.ReadLine())]();
    }

    private const string Path = @"C:\Users\tghhs\RiderProjects\CS_LABS\CS_LABS\";
    private static void Work_1()
    {
        Console.WriteLine("This work where part of text from file will deleted:");
        var tmp = File.ReadAllText($"{Path}Test.txt", Encoding.UTF8);
        Console.WriteLine(tmp);
        using var sw = new StreamWriter($"{Path}Test.txt");
        sw.Write(tmp[..(tmp.Length / 2)]);
    }
    private static void Work_2()
    {
        Console.WriteLine("This work where program should separate dates and month to to different files: ");
        var days = "";
        var month = "";
             var tmp = (File.ReadAllText($"{Path}Dates.txt", Encoding.UTF8)).Split(" ");
             foreach (var t in tmp)
             {
                 days += t[0].ToString();
                 days += t[1].ToString() + " ";

                 month += t[3].ToString();
                 month += t[4].ToString() + " ";
             }
             using (var sw = new StreamWriter($"{Path}Days.txt"))
             {
                 sw.WriteAsync(days);
             }
             using (var sw = new StreamWriter($"{Path}Months.txt"))
             {
                 sw.WriteAsync(month);
             }
    }

    private void Work_3()
    {
        var matrixA = File.ReadAllText($"{Path}MatrixA.txt").Split("\n");
        var matrixB = File.ReadAllText($"{Path}MatrixB.txt").Split("\n");
    }
}