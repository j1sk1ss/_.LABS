using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_LABS.LABS.CRYPTO.FIRST_LAB;

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

    private const int GroupPosition = 21;
    
    /// <summary>
    /// Используя алгоритм Евклида найти наибольший общий делитель двух чисел (k – порядковый номер в списке группы):
    /// НОД(48+k, 2059)
    /// НОД(46188-k, 4709)
    /// </summary>
    private void FirstTask() {
        Console.WriteLine($"First answer is: {MinimumDiv(48 + GroupPosition, 2059)} " +
                          $"\nSecond answer is: {MinimumDiv(46188 - GroupPosition, 4709)}");
    }

    /// <summary>
    /// Найдите НОД(396,1452), НОД(525, 231), НОД(248, 956), НОД(48, 457)
    /// </summary>
    private void SecondTask() => Console.WriteLine($"First answer is: {MinimumDiv(396, 1452)} " +
                                                   $"\nSecond answer is: {MinimumDiv(525, 231)} " +
                                                   $"\nThird answer is: {MinimumDiv(248, 956)} " +
                                                   $"\nFourth answer is: {MinimumDiv(48, 457)}");
    
    /// <summary>
    /// Определить, являются ли числа попарно простыми:
    /// (335+k, 231-k)
    /// </summary>
    private void ThirdTask() => Console.WriteLine(MinimumDiv(335 + GroupPosition, 231 - GroupPosition) switch {
            1 => "Pairwise simple",
            _ => "Not pairwise simple"
        });
    
    /// <summary>
    /// Используя следствие алгоритма Эратосфена доказать, что число простое
    /// </summary>
    private void FourthTask() {
        foreach (var num in LatticeEratosthenes(2, 1887)) 
            Console.WriteLine(num);
        
        foreach (var num in LatticeEratosthenes(2, 573)) 
            Console.WriteLine(num);
    }

    /// <summary>
    /// Найти НОД нескольких чисел
    /// НОД(81 719, 52003, 33 649, 30107)
    /// НОД(6791400,178500,27720)
    /// НОД(120, 1260, 4950)
    /// НОД(36, 536, 1036)
    /// </summary>
    private void FifesTask() => Console.WriteLine($"First answer is: {MinimumDiv(new List<int>{81719, 52003, 33649, 30107})} " +
                                                  $"\nSecond answer is: {MinimumDiv(new List<int>{6791400, 178500, 27720})} " +
                                                  $"\nThird answer is: {MinimumDiv(new List<int>{120, 1260, 4950})} " +
                                                  $"\nFourth answer is: {MinimumDiv(new List<int>{36, 536, 1036})}");
    
    private static int MinimumDiv(int first, int second) => second == 0 ? first : MinimumDiv(second, first % second);

    private static int MinimumDiv(List<int> numbers) =>
        numbers.Aggregate(0, (current, num) => MinimumDiv(num, current));
    
    private static List<int> LatticeEratosthenes(int start, int end) =>
        Enumerable.Range(start, end).Where(x => Enumerable.Range(2, (int)Math.Sqrt(end)).All(y => x % y != 0)).ToList();
}