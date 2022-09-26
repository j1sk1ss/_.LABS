using System;
using System.Collections.Generic;
using System.Linq;
using CS_LABS.SUP_CLASSES;
using Math = CS_LABS.SUP_CLASSES.Math;

namespace CS_LABS.LABS;

public class Quest4
{
    private readonly Math _math = new Math();
    private readonly Labs _labs = new Labs();
    private readonly Arrays _arrays = new Arrays();
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
        var capacity = _random.Next() % 100;
        var nums = new Queue<int>(capacity);
        for (var i = 0; i < capacity; i++) nums.Enqueue(_random.Next() % 100);
            Console.WriteLine($"Uniq elements from {nums.Count} : {Elements(nums)}");
    }

    private string Elements(Queue<int> queue) // works incorrectly
    {
        var uniqNums = new int[1];
        for (var j = 0; j < queue.Count; j++)
        {
            var thisNumber = queue.Dequeue();
            for (var i = 0; i < uniqNums.Length; i++)
            {
                if (uniqNums[i] == thisNumber) break;
                if (i != uniqNums.Length - 1) continue;
                    uniqNums = _arrays.ResizeArray(uniqNums, uniqNums.Length + 1);
                    uniqNums[^1] = thisNumber;
            }
        }
        return Arrays.PrintArray(uniqNums);
    }
}