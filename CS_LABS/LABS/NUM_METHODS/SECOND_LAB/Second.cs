using System;
using System.Collections.Generic;
using System.Linq;
using CS_LABS.LABS.NUM_METHODS.SECOND_LAB.OBJECTS;

namespace CS_LABS.LABS.NUM_METHODS.SECOND_LAB;

public class Second: Quest {
    public Second() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask,
            ThirdTask,
            FourthTask,
            // FifesTask
        };
    }

    private Matrix GetMatrix() {
        int rows = 0, columns = 0;
        Console.WriteLine("Count of variables: ");

        rows = int.Parse(Console.ReadLine()!);
        columns = rows + 1;
        
        var matrix = new Matrix(rows, columns);

        Console.WriteLine("Input data:");
        for (var i = 0; i < rows; i++) {
            Console.WriteLine("{0} equation: ", i + 1);
            var rowData = Console.ReadLine()!.Split(" ").Select(int.Parse).ToList();
            for (var j = 0; j < rowData.Count; j++) 
                matrix.Body[i, j] = rowData[j];
        }

        return matrix;
    }

    private void BackForward(Matrix matrix, Vector result) {
        for (var i = matrix.Body.GetLength(0) - 1; i >= 0; i--) {
            result[i] = matrix.Body[i, matrix.Body.GetLength(0)] / matrix.Body[i, i];
            for (var k = i - 1; k >= 0; k--) 
                matrix.Body[k, matrix.Body.GetLength(0)] -= matrix.Body[k, i] * result[i];
        }
    }
    
    private void FirstTask() {
        var matrix = GetMatrix();
        int rows = matrix.Body.GetLength(0), columns = matrix.Body.GetLength(1);
        var result = new double[rows];
        
        matrix.ToTriangle(null, null, Matrix.Type.Max);
        BackForward(matrix, new Vector(result));
        Console.WriteLine("Output matrix: \n{0}\nAnswer: \n{1}", matrix.Print(), new Vector(result).Print());
    }
    
    private void SecondTask() {
        var matrix = GetMatrix();
        int rows = matrix.Body.GetLength(0), columns = matrix.Body.GetLength(1);
        var result = new double[rows];
        
        matrix.ToTriangle(matrix.SwipeRows, matrix.FindInColumn, Matrix.Type.Max);
        BackForward(matrix, new Vector(result));
        Console.WriteLine("Output matrix: \n{0}\nAnswer: \n{1}", matrix.Print(), new Vector(result).Print());
    }
    
    private void ThirdTask() {
        var matrix = GetMatrix();
        int rows = matrix.Body.GetLength(0), columns = matrix.Body.GetLength(1);
        var result = new double[rows];
        
        matrix.ToTriangle(matrix.SwipeRows, matrix.FindInRow, Matrix.Type.Max);
        BackForward(matrix, new Vector(result));
        Console.WriteLine("Output matrix: \n{0}\nAnswer: \n{1}", matrix.Print(), new Vector(result).Print());
    }

    private void FourthTask() {
        var matrix = GetMatrix();
        int rows = matrix.Body.GetLength(0), columns = matrix.Body.GetLength(1);
        var result = new double[rows];

        for (var i = 0; i < rows; i++) {
            var maxRow = i;
            var maxElement = Math.Abs(matrix.Body[i, i]);

            for (var k = i + 1; k < rows; k++) {
                if (!(Math.Abs(matrix.Body[k, i]) > maxElement)) continue;
                maxRow = k;
                maxElement = Math.Abs(matrix.Body[k, i]);
            }

            for (var k = i; k <= rows; k++) 
                (matrix.Body[i, k], matrix.Body[maxRow, k]) = (matrix.Body[maxRow, k], matrix.Body[i, k]);
            
            for (var k = i + 1; k < rows; k++) {
                var factor = -matrix.Body[k, i] / matrix.Body[i, i];
                for (var j = i; j <= rows; j++) {
                    if (i == j) matrix.Body[k, j] = 0;
                    else matrix.Body[k, j] += factor * matrix.Body[i, j];
                }
            }
        }
        
        BackForward(matrix, new Vector(result));
        Console.WriteLine("Output matrix: \n{0}\nAnswer: \n{1}", matrix.Print(), new Vector(result).Print());
    }
}