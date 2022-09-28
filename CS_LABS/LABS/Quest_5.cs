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

    private readonly Dictionary<string,string> _dictionary = new Dictionary<string, string>();
    
    public void Work_1()
    {
        _dictionary.Add("привет", "hello");
        _dictionary.Add("как", "how");
        _dictionary.Add("я", "i");
        _dictionary.Add("пока", "bye");
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
        var word = new HashSet<char>();
        Console.WriteLine("This work where u should type a word and program will show count of uniq letters: ");
        var tmp = Console.ReadLine()?.ToHashSet();
        if (tmp != null)
            foreach (var t in tmp)
                word.Add(t);

        Console.WriteLine($"The count of uniq letters is: {word.Count}");
    }
}
