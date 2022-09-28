using System;
using System.Collections.Generic;
using System.Linq;
using CS_LABS.SUP_CLASSES;
namespace CS_LABS.LABS;

public class Quest5
{
    private readonly Labs _labs = new Labs();
    public void Main()
    {
        Console.WriteLine("Choose a work number: ");
        var q5 = new Quest5();
        var m = q5.GetType().GetMethod($"Work_{_labs.Math.ToInt(Console.ReadLine())}")?.Invoke(q5, null);
    }

    private readonly Dictionary<string, string> _dictionary = new()
    {
        {"привет", "hello"},
        {"как", "how"},
        {"я", "i"},
        {"пока", "bye"}
    };
    
    public void Work_1()
    {
        Console.WriteLine("This program will save translate to english from russian and reverse type of this: ");
            Console.WriteLine("Translate from russian to english (1)");
            Console.WriteLine("Translate from english to russian (2)");
            switch (_labs.Math.ToInt(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine(Translate(_dictionary,Console.ReadLine()));
                    break;
                case 2:
                    var newDictionary = _dictionary.ToDictionary(x => x.Value, x => x.Key);
                    Console.WriteLine(Translate(newDictionary,Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Cannot translate this text.");
                    break;
            }
    }
    
    private static string Translate(IReadOnlyDictionary<string, string> disct, string text)
    {
        var arrayText = text.Split(" ");
            const string translate = "";
        return arrayText.Aggregate(translate, (current, t) => current + (disct[t.ToLower()] + " "));
    }

    public static void Work_2()
    {
        Console.WriteLine("This work where u should type a word and program will show count of uniq letters: ");
        var tmp = Console.ReadLine()?.ToHashSet();
        if (tmp == null) return;
        foreach (var t in tmp)
            tmp.Add(t);
        Console.WriteLine($"The count of uniq letters is: {tmp.Count}");
    }
}
