using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CS_LABS.LABS.NUM_METHODS.FIRST_LAB;

public class First : Quest {
    public First() {
        Quests = new List<Action> {
            // FirstTask,
            // SecondTask,
            // ThirdTask,
            // FourthTask,
            // FifesTask
        };
    }

    public void FirstTask() {
        var x0              = 3.0d;   // Начальное приближение
        var tolerance       = 1e-6;   // Допустимая погрешность
        var maxIterations   = 100;    // Максимальное количество итераций

        var x = NewtonMethod(x0, tolerance, maxIterations);

        if (double.IsNaN(x)) 
            Console.WriteLine("Метод Ньютона не сходится.");
        else 
            Console.WriteLine("Найден корень: " + x);
    }

    static double f(double x) => x * x - 4;
    
    static double fPrime(double x) => 2 * x;

    static double NewtonMethod(double x0, double tolerance, int maxIterations) {
        double x        = x0;
        int iteration   = 0;

        while (iteration < maxIterations) {
            double fx       = f(x);
            double fxPrime  = fPrime(x);

            if (Math.Abs(fxPrime) < 1e-10) 
                return double.NaN;

            double deltaX = fx / fxPrime;
            x -= deltaX;

            if (Math.Abs(deltaX) < tolerance) 
                return x;

            iteration++;
        }

        return double.NaN;
    }
}