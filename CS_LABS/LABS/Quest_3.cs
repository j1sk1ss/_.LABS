using System;
using System.Linq;
using CS_LABS.SUP_CLASSES;
namespace CS_LABS.LABS;
public class Quest3 : Labs
{
    public void Main()
    {
        Console.WriteLine("Choose a work number: ");
        new Quest3().GetType().GetMethod($"Work_{Math.ToInt(Console.ReadLine())}")?.Invoke(new Quest3(), null);
    }
    public void Work_1() // Программа получает рандомно заполненую матрицу в диа от -50 до 50, после меняет отр. на 0, пол. на 1, и выводит нижний треугольник.
    {
        Console.WriteLine("This work where double dimension matrix will processed like -n -> 0; n -> 1; " +
                          "and will printed lower triangle. Set sizes: ");
        var matrix = Arrays.FillDoubleArrayOfInts(Math.ToInt(Console.ReadLine()),Math.ToInt(Console.ReadLine()),100);
            Console.WriteLine($"\nStart matrix is: {Arrays.PrintDoubleArray(matrix)}\nProcessed matrix is:");
            for (var i = 0; i < matrix.GetLength(0); i++)
            for (var j = 0; j < matrix.GetLength(1); j++) 
                matrix[i,j] = matrix[i, j] >= 0 ? 1 : 0;
        Console.WriteLine($"{Arrays.PrintDoubleArray(matrix)}\nLower triangle is: \n {Arrays.PrintLowerTriangle(matrix)}");
    }
    public static void Work_2() // Программа считает кол-во символов до ; и после.
    {
        Console.WriteLine("This work where u should write a string what includes ; char, and program will calculate " +
                          "how much symbols before this char and how much after this char: ");
        var line = Console.ReadLine();
        if (line != null)
            Console.WriteLine(
                $"Symbols before: {line.IndexOf(';')} , symbols after: {line.Length - line.IndexOf(';')}");
    }
    public static void Work_3() // Выводит процентное соотношение букв и других символов.
    {
        Console.WriteLine("This work where u should type a line of text and program will calculate percentage of " +
                          "letters and other symbols: ");
            var line = Console.ReadLine();
            if (line == null) return;
                var letters = line.Where(char.IsLetter).Count();
                    Console.WriteLine($"The percentage of letters is {System.Math.Round(letters / (line.Length / 100.0))}%.");
    }
}