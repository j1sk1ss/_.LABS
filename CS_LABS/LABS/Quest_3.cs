using System;
using System.Linq;
using CS_LABS.SUP_CLASSES;
using Math = CS_LABS.SUP_CLASSES.Math;

namespace CS_LABS.LABS;
public class Quest3
{
    private readonly Math _math = new Math();
    private readonly Labs _labs = new Labs();
    private readonly Arrays _array = new Arrays();
    public void Main()
    {
        var voids = new Action[3];
            voids[0] = Work_1;
            voids[1] = Work_2;
            voids[2] = Work_3;
            _labs.AddVoids(voids);
        Console.WriteLine("Choose a work number: ");
        _labs.Works[_math.ToInt(Console.ReadLine())]();
    }

    private void Work_1()
    {
        Console.WriteLine("This work where double dimension matrix will processed like -n -> 0; n -> 1; " +
                          "and will printed lower triangle. Set sizes: ");
            var x = _math.ToInt(Console.ReadLine());
            var y = _math.ToInt(Console.ReadLine());
        var matrix = _array.FillDoubleArrayOfInts(x,y,100);
            Console.WriteLine($"\nStart array is: {Arrays.PrintDoubleArray(matrix)}");
            Console.WriteLine("\nProcessed array is:");
            for (var i = 0; i < matrix.GetLength(0); i++) for (var j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = (matrix[i, j] >= 0) switch
                {
                    true => 1,
                    false => 0
                };
        Console.WriteLine(Arrays.PrintDoubleArray(matrix));
        Console.WriteLine($"\nLower triangle is: \n {Arrays.PrintLowerTriangle(matrix)}");
    }

    private static void Work_2()
    {
        Console.WriteLine("This work where u should write a string6 what includes ; char, and program will calculate " +
                          "how much symbols before this char and how much after this char: ");
        var line = Console.ReadLine();
        if (line != null)
            Console.WriteLine(
                $"Symbols before: {line.IndexOf(';')} , symbols after: {line.Length - line.IndexOf(';')}");
    }

    private static void Work_3()
    {
        Console.WriteLine("This work where u should type a line of text and program will calculate percentage of " +
                          "letters and other symbols: ");
            var line = Console.ReadLine();
            if (line == null) return;
            var letters = line.Where(char.IsLetter).Count();
        Console.WriteLine($"The percentage of letters is {System.Math.Round(letters / (line.Length / 100.0))}%.");
    }
}