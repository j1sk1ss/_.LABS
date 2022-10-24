using System;
using System.Collections.Generic;
using CS_LABS.SUP_CLASSES;
namespace CS_LABS.LABS;
public class Quest4 : Labs
{ public void Main()
    { Console.WriteLine("Choose a work number: ");
            new Quest4().GetType().GetMethod($"Work_{Math.ToInt(Console.ReadLine())}")?.
                Invoke(new Quest4(), null); }
    public static void Work_1() // Проверяет правильность скобочной последовательности из стэка.
    { 
        Console.WriteLine("Enter a bracket sequence: ");
        var str = Console.ReadLine()!.ToCharArray();
        var brackets = new Stack<char>();
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i] == ')' || str[i] == ']') break;
            brackets.Push(str[i]);

        }
    }
    public void Work_2() // Используя очередь выводит все уникальные элементы
    {
        var capacity = 50;
        var nums = new Queue<int>(capacity);
        for (var i = 0; i < capacity; i++) nums.Enqueue(Random.Next() % 5);
        Console.WriteLine($"Uniq elements from {nums.Count} : {Elements(nums)}"); }
    private static string Elements(Queue<int> queue) { 
        var uniq = 0;
        for (var j = 0; j < queue.Count; j++) { 
            var thisNumber = queue.Dequeue();
            queue.Enqueue(thisNumber);
            for (var i = 0; i < queue.Count; i++) { 
                var thisnumber = queue.Dequeue();
                if (thisnumber == thisNumber) break;
                if (i == queue.Count - 1) uniq++;
                queue.Enqueue(thisnumber); 
            }
        }
        return $"Queue have {uniq} uniq elements."; }
}