using System;
using System.Globalization;

namespace CS_LABS.LABS.NUM_METHODS.SECOND_LAB.OBJECTS;

public class Matrix {
    public Matrix(int rows, int columns) {
        Rows    = rows;
        Columns = columns;

        Body = new double[Rows, Columns];
    }
    
    private int Rows { get; }
    private int Columns { get; }
    
    public double[,] Body { get; }
    
    public void SwipeRows(int first, int second) {
        if (first < 0 || first >= Rows || second < 0 || second >= Rows)
            return;
        
        for (var col = 0; col < Columns; col++) 
            (Body[first, col], Body[second, col]) = (Body[second, col], Body[first, col]);
    }

    public void SwipeColumns(int first, int second) {
        if (first < 0 || first >= Columns || second < 0 || second >= Columns) 
            return;

        for (var row = 0; row < Rows; row++) 
            (Body[row, first], Body[row, second]) = (Body[row, second], Body[row, first]);
    }

    public int FindInRow(int column, Type type) {
        var value = double.MaxValue;
        if (type == Type.Min) value = double.MinValue;

        var index = -1;
        for (var i = 0; i < Rows; i++) {
            switch (type) {
                case Type.Min:
                    if (value > Body[i, column]) {
                        value = Body[i, column];
                        index = i;
                    }
                    break;
                
                case Type.Max:
                    if (value < Body[i, column]) {
                        value = Body[i, column];
                        index = i;
                    }
                    break;
                
                default:
                    break;
            }
        }

        return index;
    }
    
    public int FindInColumn(int row, Type type) {
        var value = double.MaxValue;
        if (type == Type.Min) value = double.MinValue;

        var index = -1;
        for (var i = 0; i < Columns; i++) {
            switch (type) {
                case Type.Min:
                    if (value > Body[row, i]) {
                        value = Body[row, i];
                        index = i;
                    }
                    break;
                
                case Type.Max:
                    if (value < Body[row, i]) {
                        value = Body[row, i];
                        index = i;
                    }
                    break;
                
                default:
                    break;
            }
        }

        return index;
    }
    
    public string Print() {
        var answer = "";
        var maxColumnWidths = new int[Columns];
        for (var col = 0; col < Columns; col++) {
            for (var row = 0; row < Rows; row++) {
                var cellLength = Math.Round(Body[row, col]).ToString(CultureInfo.InvariantCulture)!.Length;
                if (cellLength > maxColumnWidths[col]) 
                    maxColumnWidths[col] = cellLength;
            }
        }

        for (var row = 0; row < Rows; row++) {
            for (var col = 0; col < Columns; col++) 
                answer += Math.Round(Body[row, col]).ToString(CultureInfo.InvariantCulture)!.PadRight(maxColumnWidths[col] + 2);

            answer += "\n";
        }

        return answer;
    }
    
    public void ToTriangle(Action<int, int> action, Func<int, Type, int> second, Type type) {
        for (var i = 0; i < Rows; i++) {
            action?.Invoke(i, second(i, type));
            for (var k = i + 1; k < Rows; k++) {
                var factor = -Body[k, i] / Body[i, i];
                for (var j = i; j <= Rows; j++) 
                    if (i == j) Body[k, j] = 0;
                    else Body[k, j] += factor * Body[i, j];
                
                Console.WriteLine("Step {0}:\n{1}", k, Print());
            }
        }
    }
    
    public enum Type {
        Min,
        Max
    }
}