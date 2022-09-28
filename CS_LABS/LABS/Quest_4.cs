using System;
using System.Collections.Generic;
using CS_LABS.SUP_CLASSES;
namespace CS_LABS.LABS;

public class Quest4 : Labs
{
    public void Main()
    {
        Console.WriteLine("Choose a work number: ");
            new Quest4().GetType().GetMethod($"Work_{Math.ToInt(Console.ReadLine())}")?.Invoke(new Quest4(), null);
    }
    public static void Work_1() // Проверяет правильность скобочной последовательности из стэка.
    {
        Console.WriteLine("This work where u should write a line that all consist of ()[] symbols," +
                          " after program will check correctness of this sequence: ");
        var bracketLine = new Stack<char>(Console.ReadLine()?.ToCharArray() ?? Array.Empty<char>());
        var opened = new int[2]; // 0 - () ; 1 - [] ;
            var lenght = bracketLine.Count;
                    for (var i = 0; i < lenght; i++)
                    {
                        var now = bracketLine.Pop();
                        if (i < lenght - 1) if (Check(now, bracketLine.Peek())) { opened[0] = -100; break; }
                            SequanceAdd(opened, now);
                    }
        if (opened[0] == opened[1] && opened[0] == 0) Console.WriteLine("The sequence is correct. ");
        else if (opened[0] == -100) Console.WriteLine("The sequence is incorrect. Closed brackets for opening new is not exist. ");
        else Console.WriteLine("The sequence is incorrect. Brackets don't closing. ");
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
    public void Work_2() // Используя очередь выводит все уникальные элементы
    {
        var capacity = Random.Next() % 100;
        var nums = new Queue<int>(capacity);
        for (var i = 0; i < capacity; i++) nums.Enqueue(Random.Next() % 100);
            Console.WriteLine($"Uniq elements from {nums.Count} : {Elements(nums)}");
    }
    private static string Elements(Queue<int> queue) 
    {
        var uniqNums = new int[1];
        for (var j = 0; j < queue.Count; j++)
        {
            var thisNumber = queue.Dequeue();
            for (var i = 0; i < uniqNums.Length; i++)
            {
                if (uniqNums[i] == thisNumber) break;
                if (i != uniqNums.Length - 1) continue;
                    uniqNums = Arrays.ResizeArray(uniqNums, uniqNums.Length + 1);
                    uniqNums[^1] = thisNumber;
            }
        }
        return Arrays.PrintArray(uniqNums);
    }
}