using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_LABS.LABS.METHODS.FOURTH_LAB;

public class Fourth : Quest {
    public Fourth() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask,
            ThirdTask,
            FourthTask
        };
    }
    
    /// <summary>
    /// Решите арифметический ребус (одна и та же буква означает одну и
    /// ту же цифру, горизонтальная черта указывает на то, что это число,
    /// составленное из цифр):
    /// (Ж−1)^5=ЖЖЖ(Ж−1)
    /// </summary>
    private void FirstTask() =>
        Console.WriteLine("Answer: {0}", string.Join(" ", Enumerable.Range(0, 10)
            .Where(x => Math.Abs(Math.Pow(x - 1, 5) - int.Parse(
                $"{x}{x}{x}{(x - 1 < 0) switch { true => 9, false => x - 1 }}")) < .01)));

    /// <summary>
    /// Есть 800 пятизначных чисел, не оканчивающихся нулем, и таких,
    /// что если от любого из них вычтем 9999, то всякий раз получим обращённое
    /// число, т. е. записанное теми же цифрами, но в обратном порядке. Какие это
    /// числа?
    /// </summary>
    private void SecondTask() {
        var nums = Enumerable.Range(10000, 100000)
                                    .Where(x => x % 10 != 0)
                                    .Where(x => x - 9999 == int.Parse(string.Join("", x.ToString().Reverse())));
        
        nums.ToList().ForEach(Console.WriteLine);
    }

    /// <summary>
    /// Некоторые числа, кратные числу 7, при делении на 2, на 3, на 4, на
    /// 5 и на 6 дают остаток 1 Найдите наименьшее из таких чисел.
    /// </summary>
    private void ThirdTask() =>
        Console.WriteLine($"Answer: {0}", Enumerable.Range(0, 1000)
                                                    .Where(x => x % 7 == 0)
                                                    .Where(x => Enumerable.Range(2, 4).All(y => x % y == 1))
                                                    .Min());

    /// <summary>
    /// Известно, что сумма любого 6-значного числа с другим 6-значным
    /// числом, полученным из исходного переносом первой цифры в конец числа,
    /// кратна 11 и аналогично полученная разность – кратна 9 Докажите это.
    /// </summary>
    private void FourthTask() {
        var nums = Enumerable.Range(100000, 1000000).Where(number => {
            return (number + int.Parse(number.ToString()[1..] + number.ToString().First())) % 11 == 0 && 
                   (number - int.Parse(number.ToString()[1..] + number.ToString().First())) % 9 == 0;
        });
        
        Console.WriteLine($"If we see, that count: {900000} equals answer: {nums.Count()}, we can say that it's true");
    }
}