using System;
using System.Collections.Generic;

using CS_LABS.LABS.NUM_METHODS.SECOND_LAB.OBJECTS;

namespace CS_LABS.LABS.NUM_METHODS.SECOND_LAB;

public class Second: Quest {
    public Second() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask,
            ThirdTask,
            FourthTask,
            FifesTask
        };
    }

    private readonly Matrix _equationSystem = new (new[,] {
        {-0.86, 0.23, 0.18, 0.17, 1.42},
        {0.12, -1.14, 0.08, 0.09, 0.83},
        {0.16, 0.24, -1.0, -0.35, -1.21},
        {0.23, -0.08, 0.05, -0.75, -0.65},
    });
    
    private void BackForward(Matrix matrix, Vector result) {
        for (var i = matrix.Body.GetLength(0) - 1; i >= 0; i--) {
            result[i] = matrix.Body[i, matrix.Body.GetLength(0)] / matrix.Body[i, i];
            for (var k = i - 1; k >= 0; k--) 
                matrix.Body[k, matrix.Body.GetLength(0)] -= matrix.Body[k, i] * result[i];
        }
    }
    
    private void FirstTask() {
        var matrix = new Matrix((double[,])_equationSystem.Body.Clone());
        var result = new double[matrix.Body.GetLength(0)];
        
        matrix.ToTriangle(Matrix.Type.Max, Matrix.CalculationType.None);
        BackForward(matrix, new Vector(result));
        Console.WriteLine("Output matrix: \n{0}\nAnswer: \n{1}", matrix.Print(), new Vector(result).Print());
    }
    
    private void SecondTask() {
        var matrix = new Matrix((double[,])_equationSystem.Body.Clone());
        var result = new double[matrix.Body.GetLength(0)];
        
        matrix.ToTriangle(Matrix.Type.Max, Matrix.CalculationType.Row);
        BackForward(matrix, new Vector(result));
        Console.WriteLine("Output matrix: \n{0}\nAnswer: \n{1}", matrix.Print(), new Vector(result).Print());
    }
    
    private void ThirdTask() {
        var matrix = new Matrix((double[,])_equationSystem.Body.Clone());
        var result = new double[matrix.Body.GetLength(0)];
        
        matrix.ToTriangle(Matrix.Type.Max, Matrix.CalculationType.Column);
        BackForward(matrix, new Vector(result));
        Console.WriteLine("Output matrix: \n{0}\nAnswer: \n{1}", matrix.Print(), new Vector(result).Print());
    }

    private void FourthTask() {
        var matrix = new Matrix((double[,])_equationSystem.Body.Clone());
        var result = new double[matrix.Body.GetLength(0)];
        
        var vector = matrix.ToTriangle(Matrix.Type.Max, Matrix.CalculationType.Both);
        BackForward(matrix, new Vector(result));
        Console.WriteLine("Output matrix: \n{0}\nAnswer: \n{1}\n{2}", matrix.Print(), new Vector(result).Print(), vector.Print());
    }
    
    private readonly Matrix _coefficientsSystem = new (new[,] {
        {-0.86, 0.23, 0.18, 0.17},
        {0.12, -1.14, 0.08, 0.09},
        {0.16, 0.24, -1.0, -0.35},
        {0.23, -0.08, 0.05, -0.75},
    });
    
    private readonly Vector _answersSystem = new (new[] {
        1.42,
        0.83,
        -1.21,
        -0.65,
    });

    private void FifesTask() {
        var n = _coefficientsSystem.Body.GetLength(0);
        var l = new double[n, n];
        var u = new double[n, n];

        for (var i = 0; i < n; i++) {
            for (var j = 0; j < n; j++) {
                if (j < i) {
                    l[i, j] = _coefficientsSystem.Body[i, j];
                    for (var k = 0; k < j; k++) 
                        l[i, j] -= l[i, k] * u[k, j];
                    
                    l[i, j] /= u[j, j];
                }
                else {
                    u[i, j] = _coefficientsSystem.Body[i, j];
                    for (var k = 0; k < i; k++) 
                        u[i, j] -= l[i, k] * u[k, j];
                }
            }
            
            Console.WriteLine("Step {1}:\nL matrix:\n{0}\nU matrix: \n{2}\n", new Matrix(l).Print(), i + 1, new Matrix(u).Print());
        }

        var y = new double[n];
        for (var i = 0; i < n; i++) {
            y[i] = _answersSystem[i];
            for (var j = 0; j < i; j++) 
                y[i] -= l[i, j] * y[j];
        }

        Console.WriteLine("Intermediate result after solving Ly = B: \n{0}\n", new Vector(y).Print());

        var x = new double[n];
        for (var i = n - 1; i >= 0; i--) {
            x[i] = y[i];
            for (var j = i + 1; j < n; j++) 
                x[i] -= u[i, j] * x[j];
            
            x[i] /= u[i, i];
        }

        Console.WriteLine("Solution to the system of linear equations: \n{0}", new Vector(x).Print());
    }
}