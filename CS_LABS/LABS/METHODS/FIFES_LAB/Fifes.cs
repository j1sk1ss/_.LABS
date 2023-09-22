using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_LABS.LABS.METHODS.FIFES_LAB;

public class Fifes : Quest {
    public Fifes() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask,
            ThirdTask,
            FourthTask
        };
    }
    
    /// <summary>
    /// Найдите сумму ряда: 1.1 − 1.2 + 1.3 − …
    /// </summary>
    private void FirstTask() =>
        Console.WriteLine($"Answer: {0}", Enumerable.Range(11, 15).Sum(x => x % 2 == 0 ? -x : x) / 10d);

    /// <summary>
    /// Дано целое число K (> 0) и целочисленная последовательность A.
    /// Начиная с элемента A с порядковым номером K, извлечь из A все нечетные
    /// двузначные числа, отсортировав их по убыванию.
    /// </summary>
    private void SecondTask() {
        const int neededIndex = 25;
        var enumerable = Enumerable.Range(0, 150).Where((number, index) => 
            index >= neededIndex && number is >= 10 and < 100 && number % 2 != 0
        ).OrderByDescending(x => x).Select(x => {
            Console.WriteLine(x);
            return x;
        });
        
        Console.WriteLine("Count: " + enumerable.Count());
    }

    /// <summary>
    /// Дана строковая последовательность A. Получить последовательность
    /// цифровых символов, входящих в строки последовательности A (символы
    /// могут повторяться). Порядок символов должен соответствовать порядку
    /// строк A и порядку следования символов в каждой строке.
    /// </summary>
    private void ThirdTask() {
        var lines = new List<string> {
            "fshsf61jjdi77 892 *( 0())(( ---- 0000     ",
            "jsjjs89dkk2j j oaooo ooo oooo8998****/`§  ",
            "292929ldldldl      617235%%%%%%7e8        ",
            "kokdo--2kkdd djj j n77 87 78 7878 78      ",
            "..c,x,992 a    d joas          j jsod o   ",
            "овыаов020ббсф aksdp a oadko akk ok 889 89 ",
            "!@#$%^&*1@5#7@u@ue92\\   s''ds [[ [[[ [[[ "
        };

        foreach (var line in lines.Select(line => line.Where(char.IsDigit))) {
            foreach (var num in line) 
                Console.Write(num + ", ");
            
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Даны целочисленные последовательности A и B. Получить
    /// последовательность всех различных сумм, в которых первое слагаемое
    /// берется из A, а второе из B. Упорядочить полученную последовательность по
    /// возрастанию.
    /// </summary>
    private void FourthTask() {
        var a = Enumerable.Range(-100, 100);
        var b = Enumerable.Range(20, 190);

        var sum =
            a.Select(firstNum => b.Select(secondNum => firstNum + secondNum))
                .SelectMany(x => x)
                .OrderBy(x => x)
                .ToList();

        foreach (var num in sum) 
            Console.WriteLine($"Sum equals: {num}");
    }
}