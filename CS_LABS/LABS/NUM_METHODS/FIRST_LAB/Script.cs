using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CS_LABS.LABS.NUM_METHODS.FIRST_LAB;

public static class Script {
    public static void BisectionMethod() {
        const int numberOfIterations = 40;
        
        var arrayToOutput = new double[numberOfIterations, 8];
        var a = -2.6;
        var b = -2.4;
    
        var fa = Function(a);
        var fb = Function(b);
        var c  = (a + b) / 2;
        var fc = Function(c);

        for (var n = 0; n < numberOfIterations; n++) {
            arrayToOutput[n, 0] = n;
            arrayToOutput[n, 1] = a;
            arrayToOutput[n, 2] = c;
            arrayToOutput[n, 3] = b;
            arrayToOutput[n, 4] = fa;
            arrayToOutput[n, 5] = fc;
            arrayToOutput[n, 6] = fb;
            arrayToOutput[n, 7] = Math.Abs(a - b);

            if (Function(a) * Function(c) < 0) b = (int)c;
            else a = c;
        
            fa = Function(a);
            fb = Function(b);
        
            c = (a + b) / 2;
        
            fc = Function(c);
        }

        PrintRow("n", "a", "c", "b", "f(a)", "f(c)", "f(b)", "|a - b|");
        for (var i = 1; i < numberOfIterations + 1; i++) {
            var array = new string[8];
            for (var j = 0; j < 8; j++) 
                array[j] = arrayToOutput[i - 1, j].ToString(CultureInfo.InvariantCulture);

            PrintRow(array);
        }
    }   
    
    public static void NewtonMethod() {
        const int numberOfIterations = 5;
        const double x = -2.6;
        
        var result = new List<double>();
        var arrayToOutput = new double[numberOfIterations, 5];
        
        result.Add(x);
        
        for (var n = 0; n < numberOfIterations; n++) {
            result.Add(result[n] - (Function(result[n]) / Derivative(result[n])));
            
            arrayToOutput[n, 0] = n;
            arrayToOutput[n, 1] = result[n];
            arrayToOutput[n, 2] = Function(result[n]);
            arrayToOutput[n, 3] = Derivative(result[n]);
            arrayToOutput[n, 4] = Math.Abs(result[n + 1] - result[n]);
        }
        
        PrintRow("n", "x", "f(x)", "f'(x)", "|x - xn|");
        for (var i = 1; i < numberOfIterations + 1; i++) {
            var array = new string[5];
            for (var j = 0; j < 5; j++)
                array[j] = arrayToOutput[i - 1, j].ToString(CultureInfo.InvariantCulture);

            PrintRow(array);
        }
    }

    public static void HoardMethod() {
        List<double> result = new List<double>();
        result.Add(-2.4);
        result.Add(-2.6);
        for (var n = 0; n < 15; n++) {
            result.Add(result[n] - Function(result[n]) * (result[n+1] - result[n]) / (Function(result[n+1]) - Function(result[n])));
            Console.WriteLine("n = " + n);
            Console.WriteLine("xn+1 = " + result[n + 2]);
            Console.WriteLine("xn = " + result[n]);
            Console.WriteLine("xn-1 = " + result[n + 1]);
                
            Console.WriteLine("fxn-1 = " + Function(result[n]));
            Console.WriteLine("fxn = " + Function(result[n+1]));
            Console.WriteLine("|xn - xn-1| = " + Math.Abs(result[n + 1] - result[n]));
            Console.WriteLine("----------------------------------");
        }
    }
    
    private static double Function(double x) => Math.Pow(3, x) - 2 * x - 5;

    private static double Derivative(double x) => Math.Pow(3, x) * Math.Log(3) - 2;

    private static void PrintRow(params string[] columns) {
        var width = (150 - columns.Length) / columns.Length;
        var row = columns.Aggregate("|", (current, column) => current + AlignCentre(column, width) + "|");

        Console.WriteLine(row);
    }

    static string AlignCentre(string text, int width) {
        text = text.Length > width ? string.Concat(text.AsSpan(0, width - 3), "...") : text;
        return string.IsNullOrEmpty(text) ? new string(' ', width) : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
    }
}