using System;
using System.Collections.Generic;

namespace CS_LABS.LABS.CRYPTO.SECOND_LAB;

public class Second : Quest {
    public Second() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask,
            ThirdTask,
            FourthTask,
            FifesTask,
            SixTask,
            SeventhTask
        };
    }

    private void FirstTask() {
        Console.WriteLine("Eviler function.\nType number for function:"); 
        Eviler(Convert.ToInt32(Console.ReadLine()));
    }
    
    private void SecondTask() {
        Console.WriteLine("Type number, that will be divided: ");
        var numerator = Convert.ToInt32(Console.ReadLine()); // Числитель
        Console.WriteLine("Type number, that divide: ");
        var divider = Convert.ToInt32(Console.ReadLine()); // Делитель
        FindAnswer(numerator, divider);
    }

    private void Eviler(int number) {
        var eulerPhi = EulerPhi(number);
        Console.WriteLine("Value for {0} is: {1}", number, eulerPhi);
        PrintCoPrimes(number);
    }
    
    private void SimpleEviler(int number) {
        Console.WriteLine("Number: {0} | Answer: {1}", number, PrintCoPrimes(number, true));
    }
    
    private void FindAnswer(int numerator, int divider) {
        var lol = 0;
        var quotientList = new List<int>();
        
        Console.WriteLine(); // Евклид
        while (divider != 0) {
            var quotient = numerator / divider;
            var remainder = numerator % divider;
            
            quotientList.Add(quotient);
            Console.WriteLine($"{numerator} = {divider} * {quotient} + {remainder}  Q{++lol} = {quotient}");
            
            numerator = divider;
            divider = remainder;
        }
        
        Console.WriteLine("\nP(0) = 1 | Q(0) = 0 | P(1) = q(1) | Q(1) = 1\n");
        var sachet = 2;
        var q = new List<int> {0, 1};
        var p = new List<int> {
            1,
            quotientList[0]
        };

        while (sachet <= quotientList.Count) {
            p.Add(quotientList[sachet - 1] * p[sachet - 1] + p[sachet - 2]);
            q.Add(quotientList[sachet - 1] * q[sachet - 1] + q[sachet++ - 2]);
        }
        
        for (var i = 0; i < q.Count; i++) 
            Console.WriteLine("Q(" + i + ") = " + q[i] + " | P(" + i + ") = " + p[i]);
        
        Console.WriteLine("\nAccepted: ");
        var sachet2 = 1;
        while (sachet2 <= quotientList.Count)
            Console.WriteLine($"{sachet2} = {p[sachet2]} / {q[sachet2++]}");
    }
    
    private int PrintCoPrimes(int n, bool count = false) {
        Console.Write("Prime with " + n + ": ");

        var size = 0;
        for (var i = 1; i < n; i++)
            if (GCD(n, i) == 1) 
                if (count == false) Console.Write(i + " ");
                else size++;

        if (count == false) Console.WriteLine();
        return size;
    }
    
    private int GCD(int a, int b) {
        return b == 0 ? a : GCD(b, a % b);
    }
    
    private int EulerPhi(int n) {
        var result = n;
        for (var i = 2; i * i <= n; i++) {
            if (n % i != 0) continue;
            
            while (n % i == 0)
                n /= i;
            
            result -= result / i;
        }

        if (n > 1) result -= result / n;
        return result;
    }

    private void ThirdTask() {
        SimpleEviler(3672);
        SimpleEviler(3519);
        
        SimpleEviler(5040);
        SimpleEviler(1683);
        
        SimpleEviler(1409);
        SimpleEviler(243);
        
        SimpleEviler(367);
        SimpleEviler(573);
    }

    private void FourthTask() {
        FindAnswer(114, 59);
        FindAnswer(247, 569);
        
        FindAnswer(5391, 3976);
        FindAnswer(125, 92);
        
        FindAnswer(648, 35);
        FindAnswer(125, 78);
        
        FindAnswer(45, 263);
        FindAnswer(38, 145);
    }

    private void FifesTask() {
        SimpleEviler(3432);
        SimpleEviler(2277);
        SimpleEviler(3672);
        SimpleEviler(3519);
    }

    private void SixTask() {
        FindAnswer(112, 53);
        FindAnswer(217, 367);
        
        FindAnswer(51, 76);
        FindAnswer(225, 97);
        
        FindAnswer(448, 57);
        FindAnswer(125, 86);
        
        FindAnswer(45, 253);
        FindAnswer(318, 145);
    }

    private void SeventhTask() {
        SimpleEviler(372);
        SimpleEviler(3619);
        
        SimpleEviler(543);
        SimpleEviler(1781);
        
        SimpleEviler(142);
        SimpleEviler(2143);
        
        SimpleEviler(357);
        SimpleEviler(5173);
    }
}