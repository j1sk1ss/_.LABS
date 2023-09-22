using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CS_LABS.LABS.METHODS.FIRST_LAB;

public class First : Quest {
    public First() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask,
            ThirdTask,
            FourthTask,
            FifesTask
        };
    }
    
    /// <summary>
    /// Дана строка. Напишите программу, которая найдет слова 23, 2+3, 2++3,
    /// 2+++3, не захватив остальные.
    /// </summary>
    private void FirstTask() => ShowMatches(@"\b2\+{0,}3\b");
    
    /// <summary>
    /// Дана строка. Напишите программу, которая найдет слова, в которых по
    /// краям стоят буквы 'a', а между ними любое количество цифр.
    /// </summary>
    private void SecondTask() => ShowMatches(@"\ba\d{0,}a\b");

    /// <summary>
    /// Напишите программу, которая найдет слова следующего вида: по
    /// краям стоят буквы 'a', а между ними - цифра от 3-х до 7-ми.
    /// </summary>
    private void ThirdTask() => ShowMatches(@"\ba[3-7]a\b");
    
    /// <summary>
    /// Дана строка. Напишите программу, которая найдет слова следующего
    /// вида: по краям стоят буквы 'a', а между ними - не 'e' и не 'x'.
    /// </summary>
    private void FourthTask() => ShowMatches(@"\ba[^xe]a\b");
    
    /// <summary>
    /// Дана строка. Напишите программу, которая найдет слова следующего
    /// вида: по краям стоят буквы 'a', а между ними две маленькие
    /// латинские буквы, не затронув остальных.
    /// </summary>
    private void FifesTask() => ShowMatches(@"\ba[a-z]{2}a\b");
    
    private static void ShowMatches(string pattern) {
        Console.Write("Write line: ");
        new Regex(pattern).Matches(Console.ReadLine()!).ToList().ForEach(match => Console.WriteLine(match.Value));
    }
}