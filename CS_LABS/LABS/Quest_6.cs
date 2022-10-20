using System;
using System.IO;
using System.Text;
using CS_LABS.SUP_CLASSES;
namespace CS_LABS.LABS;
public class Quest6 : Labs
{ public void Main()
    { Console.WriteLine("Choose a work number: ");
        new Quest6().GetType().GetMethod($"Work_{Math.ToInt(Console.ReadLine())}")?.Invoke(new Quest6(), 
            null); }
    private const string Path = @"C:\Users\j1sk1ss\RiderProjects\CS_LABS\CS_LABS\FILES\";
    public static void Work_1()
    { Console.WriteLine("This work where part of text from file will deleted:");
        var tmp = File.ReadAllText($"{Path}Test.txt", Encoding.UTF8).
                                Split(" ",StringSplitOptions.RemoveEmptyEntries);
        using var sw = new StreamWriter($"{Path}Test.txt");
        var end = "";
        for (var i = 0; i < tmp.Length / 2; i++) end += tmp[i] + " ";
        sw.Write(end); }
    public static void Work_2()
    { Console.WriteLine("This work where program should separate dates and month to to different files: ");
        var days = "";
        var month = "";
        var tmp = (File.ReadAllText($"{Path}Dates.txt", Encoding.UTF8)).Split(" ");
         foreach (var t in tmp) {
             days += t[..2] + " ";
             month += t[3..5] + " "; }
         using (var sw = new StreamWriter($"{Path}Days.txt")) {
             sw.WriteAsync(days); }
         using (var sw = new StreamWriter($"{Path}Months.txt")) {
             sw.WriteAsync(month); }
    }
    public static void Work_3()
    { var mt1 = new int[0,0];
        var mt2 = new int[0,0];
        var matrixA = File.ReadAllText($"{Path}MatrixA.txt").Split("\n").ToString()?.Split(" ");
        var matrixB = File.ReadAllText($"{Path}MatrixB.txt").Split("\n").
            ToString()?.Split(" "); }
}