using System;
using System.Collections.Generic;

namespace CS_LABS.LABS.DISCRET_MATH.FIRST_LAB;

public class First: Quest {
    public First() {
        Quests = new List<Action> {
            FirstTask
        };
    }

    private void FirstTask() {
        var n = 4; // Количество вершин в графе
        int[,] w = {
            {1, 9, 0, 11},
            {1, int.MaxValue, 2, 10},
            {int.MaxValue, 6, 0, 9},
            {5, int.MaxValue, int.MaxValue, 11}
        };
        
        Console.WriteLine("Start matrix: ");
        for (var i = 0; i < 4; i++) {
            for (var j = 0; j < 4; j++) {
                if (w[i,j] == int.MaxValue) Console.Write("v ");
                else Console.Write(w[i, j] + " ");
            }
            
            Console.WriteLine();
        }
        
        FindShortestPaths(w, out var d, out var p, out var s);

        if (s == 1) {
            Console.WriteLine("Matrix min ways (D):");
            for (var i = 0; i < n; i++) {
                for (var j = 0; j < n; j++) 
                    Console.Write(d[i, j] + "\t");
                
                Console.WriteLine();
            }

            Console.WriteLine("Matrix previous vertex (P):");
            for (var i = 0; i < n; i++) {
                for (var j = 0; j < n; j++) 
                    Console.Write(p[i, j] + "\t");
                
                Console.WriteLine();
            }
        }
        else Console.WriteLine("Can't be solved.");
    }
    
    private static void FindShortestPaths(int[,] w, out int[,] d, out int[,] p, out int s) {
        var n = w.GetLength(0);
        d = new int[n, n];
        p = new int[n, n];
        s = 1;

        // Инициализация матрицы D и P
        for (var i = 0; i < n; i++) {
            for (var j = 0; j < n; j++) {
                d[i, j] = w[i, j];
                if (i != j && d[i, j] != int.MaxValue) p[i, j] = i;
                else p[i, j] = -1; // -1 означает отсутствие пути
            }
        }

        // Алгоритм Флойда-Уоршалла
        for (var m = 0; m < n; m++) {
            for (var i = 0; i < n; i++) {
                for (var j = 0; j < n; j++) {
                    if (d[i, m] != int.MaxValue && d[m, j] != int.MaxValue && d[i, m] + d[m, j] < d[i, j]) {
                        d[i, j] = d[i, m] + d[m, j];
                        p[i, j] = p[m, j];
                    }
                }
            }
        }

        // Проверка наличия контура отрицательного веса
        for (var i = 0; i < n; i++) {
            if (d[i, i] < 0) {
                s = 0; // Найден контур отрицательного веса
                return;
            }
        }
    }
}