using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_LABS.LABS.CRYPTO.THIRD_LAB;

public class Third: Quest {
    public Third() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask,
            ThirdTask
        };
    }

    private void FirstTask() {
        Console.WriteLine(FindMultiplicativeInverse(33, 11));
        Console.WriteLine(FindMultiplicativeInverse(12, 17));
        Console.WriteLine(FindMultiplicativeInverse(132, 13));
        Console.WriteLine(FindMultiplicativeInverse(52, 13));
        Console.WriteLine(FindMultiplicativeInverse(532, 11));
        Console.WriteLine(FindMultiplicativeInverse(37, 13));
        Console.WriteLine(FindMultiplicativeInverse(62, 17));
        Console.WriteLine(FindMultiplicativeInverse(67, 19));
    }

    private void SecondTask() {
        Console.WriteLine(SolveLinearCongruence(5, 1, 132));
        Console.WriteLine(SolveLinearCongruence(25, 58, 7));
        Console.WriteLine(SolveLinearCongruence(7, 25, 19));
        Console.WriteLine(SolveLinearCongruence(7, 8, 15));
        Console.WriteLine(SolveLinearCongruence(23, 42, 17));
        Console.WriteLine(SolveLinearCongruence(259, 179, 337));
        Console.WriteLine(SolveLinearCongruence(111, 75, 321));
    }

    private void ThirdTask() {
        Console.WriteLine(SolveLinearCongruence(13, 7, 19));
        Console.WriteLine(SolveLinearCongruence(7, 8, 15));
        Console.WriteLine(SolveLinearCongruence(5, 7, 11));
        Console.WriteLine(SolveLinearCongruence(6, 5, 13));
        Console.WriteLine(SolveLinearCongruence(6, 8, 17));
        Console.WriteLine(SolveLinearCongruence(23, 42, 17));
    }
    
    private static double FindMultiplicativeInverse(double a, double m) {
        if (m <= 0){
            Console.Write("Modulus must be a positive integer.   \t");
            return -1;
        }

        var extendedGcd = ExtendedGcd(a, m);

        var gcd = extendedGcd[0];
        var x = extendedGcd[1];

        if (Math.Abs(gcd - 1) > .01) {
            Console.Write("Multiplicative inverse does not exist.   \t");
            return -1;
        }

        // Ensure x is positive
        x = (x % m + m) % m;

        return x;
    }

    private static double[] ExtendedGcd(double a, double b) {
        if (b == 0)
            return new[] { a, 1, 0 };

        var values = ExtendedGcd(b, a % b);
        var gcd = values[0];
        var x1 = values[1];
        var y1 = values[2];

        var y = x1 - Math.Floor(a / b) * y1;

        return new[] { gcd, y1, y };
    }

    private static int SolveLinearCongruence(int a, int b, int m) {
        var extendedGcd = ExtendedGcd(a, m).ToList().Select(x => (int)x).ToList();

        var gcd = extendedGcd[0];
        var x1 = extendedGcd[1];

        if (gcd != 1) {
            Console.Write("No solution   \t");
            return -1;
        }

        // Ensure x1 is positive
        var x = (x1 % m + m) % m;

        // Вычисляем решение x = (b * x1) % m
        var result = (b * x) % m;

        return result;
    }
}