using System;
using System.Globalization;

namespace CS_LABS.LABS.NUM_METHODS.SECOND_LAB.OBJECTS;

public class Matrix {
    public Matrix(int rows, int columns) {
        Rows    = rows;
        Columns = columns;

        Body = new double[Rows, Columns];
    }
    
    public Matrix(double[,] body) {
        Rows    = body.GetLength(0);
        Columns = body.GetLength(1);

        Body = body;
    }
    
    private int Rows { get; }
    private int Columns { get; }
    
    public double[,] Body { get; }

    public Matrix DeleteColumn(int column) {
        var newBody = new double[Rows, Columns - 1];

        for (var i = 0; i < Rows; i++) 
            for (int j = 0, newJ = 0; j < Columns; j++) 
                if (j != column) {
                    newBody[i, newJ] = Body[i, j];
                    newJ++;
                }

        return new Matrix(newBody);
    }
    
    private void SwipeRows(int first, int second) {
        for (var col = 0; col < Columns; col++) 
            (Body[first, col], Body[second, col]) = (Body[second, col], Body[first, col]);
    }

    private void SwipeColumns(int first, int second) {
        for (var row = 0; row < Rows; row++) 
            (Body[row, first], Body[row, second]) = (Body[row, second], Body[row, first]);
    }

    private int FindInRow(int column, Type type) {
        var value = type == Type.Min ? double.MaxValue : double.MinValue;

        var index = -1;
        for (var i = 0; i < Rows; i++) {
            if ((type != Type.Min || !(value > Math.Abs(Body[i, column]))) &&
                (type != Type.Max || !(value < Math.Abs(Body[i, column])))) continue;
            
            value = Math.Abs(Body[i, column]);
            index = i;
        }

        return index;
    }
    
    private int FindInColumn(int row, Type type) {
        var value = type == Type.Min ? double.MaxValue : double.MinValue;

        var index = -1;
        for (var i = 0; i < Columns; i++) {
            if ((type != Type.Min || !(value > Math.Abs(Body[row, i]))) &&
                (type != Type.Max || !(value < Math.Abs(Body[row, i])))) continue;
            
            value = Math.Abs(Body[row, i]);
            index = i;
        }

        return index;
    }

    private (int x, int y) FindInMatrix(int firstPadding, int secondPadding, Type type) {
        var value = type == Type.Min ? double.MaxValue : double.MinValue;
        
        var index = (-1, -1);
        for (var i = firstPadding; i < Rows; i++) {
            for (var j = secondPadding; j < Columns; j++) {
                if ((type != Type.Min || !(value > Math.Abs(Body[i, j]))) &&
                    (type != Type.Max || !(value < Math.Abs(Body[i, j])))) continue;
            
                value = Math.Abs(Body[i, j]);
                index = (i, j);
            }
        }

        return index;
    }
    
    public string Print() {
        var answer = "";
        var maxColumnWidths = new int[Columns];
        for (var col = 0; col < Columns; col++) {
            for (var row = 0; row < Rows; row++) {
                var cellLength = Math.Round(Body[row, col], 2).ToString(CultureInfo.InvariantCulture)!.Length;
                if (cellLength > maxColumnWidths[col]) 
                    maxColumnWidths[col] = cellLength;
            }
        }

        for (var row = 0; row < Rows; row++) {
            for (var col = 0; col < Columns; col++) 
                answer += Math.Round(Body[row, col], 2).ToString(CultureInfo.InvariantCulture)!.PadRight(maxColumnWidths[col] + 2);

            answer += "\n";
        }

        return answer;
    }
    
    public Vector ToTriangle(Type type, CalculationType calculationType) {
        var vector = new Vector(new double[] { 1, 2, 3, 4 });
        var tempBody = new Matrix(new double[Rows, Rows]);
        for (var i = 0; i < Rows; i++) 
            for (var j = 0; j < Rows; j++) 
                tempBody.Body[i, j] = Body[i, j];
        
        for (var i = 0; i < Rows; i++) {
            var index = calculationType switch {
                CalculationType.Column  => tempBody.FindInColumn(i, type),
                CalculationType.Row     => tempBody.FindInRow(i, type),
                CalculationType.Both    => 1,
                _                       => -1
            };

            if (index > 0) {
                Console.WriteLine("Swipe: {0}:\n{1}", i, Print());
                switch (calculationType) {
                    case CalculationType.Column:
                        SwipeColumns(i, index);
                        tempBody.SwipeColumns(i, index);
                        break;

                    case CalculationType.Row:
                        SwipeRows(i, index);
                        tempBody.SwipeRows(i, index);
                        vector.Swipe(i, index);
                        break;
                    
                    case CalculationType.Both:
                        var (x, y) = tempBody.FindInMatrix(i, i, Type.Max);
                        SwipeColumns(i, y);
                        tempBody.SwipeColumns(i, y);
                        
                        SwipeRows(i, x);
                        tempBody.SwipeRows(i, x);
                        vector.Swipe(i, index);
                        break;
                }

                Console.WriteLine("Calculate swiped ({2} with {0}) <{0}>:\n{1}\n", i, Print(), index);
            }
            

            for (var k = i + 1; k < Rows; k++) {
                var factor = -Body[k, i] / Body[i, i];
                for (var j = i; j <= Rows; j++) 
                    if (i == j) Body[k, j] = 0;
                    else Body[k, j] += factor * Body[i, j];
            }
        }

        return vector;
    }

    public enum Type {
        Min,
        Max
    }

    public enum CalculationType {
        Row,
        Column,
        Both,
        None
    }
    
    public double Determinant() {
        if (Rows != Columns) 
            throw new InvalidOperationException("The matrix must be square for determinant calculation.");
        
        return CalculateDeterminant(Body);
    }

    private double CalculateDeterminant(double[,] matrix) {
        var size = matrix.GetLength(0);
        if (size == 1) 
            return matrix[0, 0];
        
        if (size == 2) 
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        var determinant = 0d;
        for (var j = 0; j < size; j++) 
            determinant += Math.Pow(-1, j) * matrix[0, j] * CalculateDeterminant(GetSubMatrix(matrix, 0, j));
        
        return determinant;
    }

    private double[,] GetSubMatrix(double[,] matrix, int excludingRow, int excludingColumn) {
        var size = matrix.GetLength(0) - 1;
        var subMatrix = new double[size, size];

        for (int i = 0, newRow = 0; i < matrix.GetLength(0); i++) {
            if (i == excludingRow) 
                continue;

            for (int j = 0, newCol = 0; j < matrix.GetLength(1); j++) {
                if (j == excludingColumn) 
                    continue;
                
                subMatrix[newRow, newCol] = matrix[i, j];
                newCol++;
            }

            newRow++;
        }

        return subMatrix;
    }
    
    public Matrix Inverse() {
        var n = Rows;
        var augmentedMatrix = new double[n, 2 * n];

        // Create an augmented matrix [A | I]
        for (var i = 0; i < n; i++) 
            for (var j = 0; j < n; j++) {
                augmentedMatrix[i, j] = Body[i, j];
                augmentedMatrix[i, j + n] = (i == j) ? 1.0 : 0.0;
            }
        
        // Perform Gauss elimination with back-substitution
        for (var k = 0; k < n; k++) {
            // Partial Pivoting
            var maxRow = k;
            for (var i = k + 1; i < n; i++) 
                if (Math.Abs(augmentedMatrix[i, k]) > Math.Abs(augmentedMatrix[maxRow, k])) 
                    maxRow = i;

            // Swap rows
            if (maxRow != k) 
                for (var j = 0; j < 2 * n; j++)
                    (augmentedMatrix[k, j], augmentedMatrix[maxRow, j]) = (augmentedMatrix[maxRow, j], augmentedMatrix[k, j]);

            // Gaussian elimination
            for (var i = k + 1; i < n; i++) {
                var factor = augmentedMatrix[i, k] / augmentedMatrix[k, k];
                for (var j = k; j < 2 * n; j++) 
                    augmentedMatrix[i, j] -= factor * augmentedMatrix[k, j];
            }
        }

        // Back-substitution
        for (var i = n - 1; i > 0; i--) 
            for (var j = i - 1; j >= 0; j--) {
                var factor = augmentedMatrix[j, i] / augmentedMatrix[i, i];
                for (var k = i; k < 2 * n; k++) 
                    augmentedMatrix[j, k] -= factor * augmentedMatrix[i, k];
            }
        
        // Normalize rows
        for (var i = 0; i < n; i++) {
            var factor = augmentedMatrix[i, i];
            for (var j = 0; j < 2 * n; j++) 
                augmentedMatrix[i, j] /= factor;
        }

        // Extract the inverse matrix [I | A^(-1)]
        var inverseMatrixData = new double[n, n];
        for (var i = 0; i < n; i++) 
            for (var j = 0; j < n; j++) 
                inverseMatrixData[i, j] = augmentedMatrix[i, j + n];

        return new Matrix(inverseMatrixData);
    }
}