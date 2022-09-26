using System;
using System.Collections.Generic;
using CS_LABS.SUP_CLASSES;
using Math = CS_LABS.SUP_CLASSES.Math;

namespace CS_LABS.LABS;

public class Quest4
{
    private readonly Math _math = new Math();
    private readonly Labs _labs = new Labs();
    public void Main()
    {
        var voids = new Action[2];
        voids[0] = Work_1;
        voids[1] = Work_2;
        _labs.AddVoids(voids);
        Console.WriteLine("Choose a work number: ");
        _labs.Works[_math.ToInt(Console.ReadLine())]();
    }

    private static void Work_1()
    {
        Console.WriteLine("This work where u should write a line that all consist of ()[] symbols," +
                          " after program will check correctness of this sequence: ");
        var line = Console.ReadLine()?.ToCharArray();
        var opened = new int[2]; // 0 - () ; 1 - [] ;
            if (line != null)
                for (var i = 0; i < line.Length; i++)
                {
                    if (i < line.Length - 1) if (Check(line[i], line[i+1]))
                    {
                        opened[0] = -100;
                        break;
                    }
                    SequanceAdd(opened,line[i]);
                }
            if (opened[0] == 0 && opened[1] == 0) Console.WriteLine("The sequence is correct. ");
            else
                switch (opened[0])
                {
                    case -100:
                        Console.WriteLine("The sequence is incorrect. Closed brackets for opening new is not exist. ");
                        break;
                    default:
                        Console.WriteLine("The sequence is incorrect. Brackets don't closing. ");
                        break;
                }
    }

    private static bool Check(char line, char next)
    {
        return line == '(' && next == ']' || line == '[' && next == ')';
    }
    private static void SequanceAdd(IList<int> array, char symb)
    {
        switch (symb)
        {
            case '(':
                array[0]++;
                break;
            case '[':
                array[1]++;
                break;
            case ')':
                array[0]--;
                break;
            case ']':
                array[1]--;
                break;
        }
    }

    private readonly Random _random = new Random();
    private void Work_2()
    {
        var nums = new Queue<int>(_random.Next() % 100);
        for (var i = 0; i < nums.Count; i++) nums.Enqueue(_random.Next() % 100);
            Console.WriteLine($"Uniq elements: {Elements(nums)}");
    }

    private string Elements(Queue<int> queue) // works incorrectly
    {
        string elem = "";
        for (int j = 0; j < queue.Count; j++)
        {
            int? el = queue.Peek();
            for (int i = 0; i < queue.Count; i++) if (el == queue.Dequeue())
            {
                el = null;
            };
            elem += " " + el;
        }
        return elem;
    }
}