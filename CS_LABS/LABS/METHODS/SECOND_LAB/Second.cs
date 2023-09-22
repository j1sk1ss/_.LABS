using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CS_LABS.LABS.METHODS.SECOND_LAB;

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
    private void SecondTask() => Console.WriteLine(IsMatch(@"^(?=.*[0-9].*)(?=.*[a-z].*)(?=.*[A-Z].*)(?=.*[!@#$%^&*,.?].*)[0-9a-zA-Z!@#$%^&*,.?]{8,}$").ToString());

    /// <summary>
    /// Преобразуйте все даты в тексте из формата ДД.ММ.ГГГГ в ДД-ММ-
    /// ГГГГ
    /// </summary>
    private void ThirdTask() =>
        Console.WriteLine(new Regex("\\.").Replace( 
            File.ReadAllText(@"/Users/nikolaj/RiderProjects/CS.LABS/CS_LABS/LABS/METHODS/SECOND_LAB/FILES/DatesSecondLab.txt"),
            "-"));

    /// <summary>
    /// Дан текст, содержащий через запятую имена людей и их телефон,
    /// вывести их в формате: «Имя: Иван | Телефон: +89123456789»
    /// </summary>
    private void FourthTask() {
        var text = File.ReadAllText(
            @"/Users/nikolaj/RiderProjects/CS.LABS/CS_LABS/LABS/METHODS/SECOND_LAB/FILES/NamesSecondLab.txt");

        new Regex(@"([^\,\W]+[a-zA-Z])([^\,]+[0-9])").Matches(text).ToList().ForEach(match =>
            Console.WriteLine("Имя: {0} | Телефон: {1}", match.Groups[1].Value, match.Groups[2].Value));
    }
    
    private bool IsMatch(string pattern) {
        Console.Write("Write line: ");
        return new Regex(pattern).Matches(Console.ReadLine()!).Count > 0;
    }
}