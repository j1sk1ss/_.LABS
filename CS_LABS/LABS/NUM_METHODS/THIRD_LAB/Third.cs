using System;
using System.Collections.Generic;
using CS_LABS.LABS.NUM_METHODS.SECOND_LAB.OBJECTS;

namespace CS_LABS.LABS.NUM_METHODS.THIRD_LAB;

public class Third: Quest
{
    public Third() {
        // Console.BackgroundColor = ConsoleColor.White;
        // Console.ForegroundColor = ConsoleColor.Black;
        
        Quests = new List<Action> {
            FirstTask,
            //SecondTask,
            //ThirdTask,
            //FourthTask,
            //FifesTask,
            //SixTask
        };
    }

    private void FirstTask() {
        var matrix = new Matrix(new[,] {
            { -0.871, -0.440, 0.0000, 0.0000, 0.0000 },
            { -0.823, 0.7180, -0.016, 0.0000, 0.0000 },
            { 0.0000, 0.6840, 1.8850, 0.0100, 0.0000 },
            { 0.0000, 0.0000, 1.7780, -0.172, 0.6000 },
            { 0.0000, 0.0000, 0.0000, -0.099, 0.4160 }
        });
        
        var d = new Vector(new[] { 0.628, 1.257, 1.885, 2.513, 3.142 });
        var a = new Vector(new double[5]) {
            [0] = 0
        };

        var b = new Vector(new double[5]);
        var c = new Vector(new double[5]) {
            [4] = 0
        };

        for (var i = 0; i < 5; i++) {
            b[i] = matrix.Body[i, i];
            
            if (i < 4) c[i] = matrix.Body[i, i + 1];
            if (i > 0) a[i] = matrix.Body[i, i - 1];
        }

        var alpha = new Vector(new double[5]) {
            [0] = -(c[0] / b[0])
        };
        
        var beta = new Vector(new double[5]) {
            [0] = d[0] / b[0]
        };
        
        for(var i = 1; i < 5; i++) {
            alpha[i] = -(c[i] / (a[i] * alpha[i - 1] + b[i]));
            beta[i]  = (d[i] - a[i] * beta[i - 1]) / (a[i] * alpha[i - 1] + b[i]);
        }

        var x = new Vector(new double[5]) {
            [4] = (d[4] - a[4] * beta[3]) / (a[4] * alpha[3] + b[4])
        };
        
        for(var i = 3; i >= 0; i--) 
            x[i] = alpha[i] * x[i + 1] + beta[i];

        for (var i = 0; i < a.Size; i++) a[i] = Math.Round(a[i], 3);
        for (var i = 0; i < b.Size; i++) b[i] = Math.Round(b[i], 3);
        for (var i = 0; i < c.Size; i++) c[i] = Math.Round(c[i], 3);
        for (var i = 0; i < x.Size; i++) x[i] = Math.Round(x[i], 3);
        
        Console.Write("a = \n{0}\n", a.VerticalPrint());
        Console.Write("b = \n{0}\n", b.VerticalPrint());
        Console.Write("c = \n{0}\n", c.VerticalPrint());
        Console.Write("alpha = \n{0}\n", alpha.VerticalPrint());
        Console.Write("beta = \n{0}\n", beta.VerticalPrint());
        Console.Write("x = \n{0}\n", x.VerticalPrint());
    }
}