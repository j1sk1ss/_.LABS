using System;
using System.Collections.Generic;
using System.Linq;
using CS_LABS.SUP_CLASSES;
using Microsoft.VisualBasic;
using Math = CS_LABS.SUP_CLASSES.Math;

namespace CS_LABS.LABS;

public class Quest5
{
    private readonly Math _math = new Math();
    private readonly Labs _labs = new Labs();
    private readonly Arrays _arrays = new Arrays();
    private readonly Enum _language;

    public void Main()
    {
        var voids = new Action[2];
        voids[0] = Work_1;
        _labs.AddVoids(voids);
        Console.WriteLine("Choose a work number: ");
        _labs.Works[_math.ToInt(Console.ReadLine())]();
    }

    private readonly Dictionary<string,string> _dictionary = new Dictionary<string, string>();
    private void Work_1()
    {
        Console.WriteLine("This program will save translate to english from russian and reverse type of this: ");
        Console.WriteLine("Translate from russian to english (1)");
        Console.WriteLine("Translate from english to russian (2)");
            _dictionary.Add("привет", "hello");
            _dictionary.Add("как", "how");
            _dictionary.Add("я", "i");
            _dictionary.Add("пока", "bye");
            switch (_math.ToInt(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine(Translate(Language.English, Console.ReadLine()));
                    break;
                case 2:
                    Translate(Language.Russian, Console.ReadLine());
                    break;
                default:
                    break;
            }
    }
    
    private string Translate(Language lng, string text)
    {
        var arrayText = text.Split(" ");
        var translate = "";
        switch (lng)
        {
            case Language.English:
                translate = arrayText.Aggregate(translate, (current, t) => current + (_dictionary[t.ToLower()] + " "));
                break;
            case Language.Russian:
                
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(lng), lng, null);
        }
        return translate;
    }

    private enum Language
    {
        Russian,
        English
    }    
}
