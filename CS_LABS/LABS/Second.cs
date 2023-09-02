using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using CS_LABS.INTERFACES;

namespace CS_LABS.LABS;

public class Second : Quest {
    public Second() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask,
            ThirdTask,
            FourthTask
        };
    }

    /// <summary>
    /// Проверить, является ли данная строка буквенно-цифровой, т.е.
    /// содержит только буквы и цифры.
    /// </summary>
    private void FirstTask() => Console.WriteLine(IsMatch("\b[a-zA-Z0-9]+\b").ToString());

    /// <summary>
    /// Определите, что переданная строка является сложным паролем,
    /// содержащим буквы в разных регистрах, цифры и дополнительные
    /// символы из списка «!@#$%^&*,.?»
    /// </summary>
    private void SecondTask() => Console.WriteLine(IsMatch("^(?=.*[0-9].*)(?=.*[a-z].*)(?=.*[A-Z].*)[0-9a-zA-Z]{8,}$").ToString());

    /// <summary>
    /// Преобразуйте все даты в тексте из формата ДД.ММ.ГГГГ в ДД-ММ-
    /// ГГГГ
    /// </summary>
    private void ThirdTask() =>
        Console.WriteLine(new Regex("\\.").Replace( 
            File.ReadAllText(@"C:\Users\j1sk1ss\RiderProjects\CS.LABS\CS_LABS\FILES\SECOND_LAB\DatesSecondLab.txt"), "-"));

    /// <summary>
    /// Дан текст, содержащий через запятую имена людей и их телефон,
    /// вывести их в формате: «Имя: Иван | Телефон: +89123456789»
    /// </summary>
    private void FourthTask() {
        var text = File.ReadAllText(
            @"C:\Users\j1sk1ss\RiderProjects\CS.LABS\CS_LABS\FILES\SECOND_LAB\NamesSecondLab.txt");

        var value = new List<string>();
        foreach (Match match in new Regex(@"\b[0-9]+|[a-zA-Z]+\b").Matches(text)) 
            value.Add(match.Value);

        for (var i = 0; i < value.Count - 1; i += 2) 
            Console.WriteLine($"Имя: {value[i]} | Телефон: {value[i + 1]}");
    }
    
    private bool IsMatch(string pattern) {
        Console.Write("Write line: ");
        return new Regex(pattern).Matches(Console.ReadLine()!).Count > 0;
    }
}