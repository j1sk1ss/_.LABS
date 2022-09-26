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
        Console.WriteLine("This work where u should write a line that all consist of ()[] symbols," +
                          " after program will check correctness of this sequence: ");
        var line = Console.ReadLine().ToCharArray(); // Work incorrectly
            // ()((][(][])))
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == ']' || line[i] == ')')
                {
                    Console.WriteLine("The sequence is wrong. ");
                    return;
                }

                char symbol = '0';
                    switch (line[i])
                    {
                        case '(':
                            symbol = ')';
                            break;
                        case '[':
                            symbol = ']';
                            break;
                    }
                for (var j = i; j < line.Length; j++)
                {
                    if (line[j] == symbol) line[j] = '0';
                }
            }
            Console.WriteLine("The sequence is correct. ");
    }
}