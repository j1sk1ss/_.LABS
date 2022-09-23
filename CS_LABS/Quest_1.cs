using System;
namespace CS_LABS
{
    public class Quest_1 : Math
    {
        public void Main()
        {
            Console.WriteLine("Type a number of work: ");
            int? work = ToInt(Console.ReadLine());
            switch (work)
            {
                case 1:
                    Work_1();
                    break;
                case 2:
                    Work_2();
                    break;
                default:
                    Console.WriteLine("Wrong number of work.");
                    break;
            }
        }

        void Work_1()
        {
            Console.WriteLine("This work where u should type a values of variables Y and X:");
                Console.WriteLine("X: ");
                int x = ToInt(Console.ReadLine());
                Console.WriteLine("Y: ");
                int y = ToInt(Console.ReadLine());
                double? answer = 2 * System.Math.Atan(3 * x) * (-System.Math.Sqrt(x)) -
                              ((1) / 12 * System.Math.Pow(x, 2) + 7 * x - 5);
                Console.WriteLine("Answer: ");
            Console.Write(answer);
        }

        void Work_2()
        {
            Console.WriteLine("This work where u should type a values of variables A, B and C:");
                    Console.WriteLine("a*x^4 + b*x^2 + c = 0");
                    Console.WriteLine("A: ");
                int a = ToInt(Console.ReadLine());
                System.Console.Clear();
                    Console.WriteLine($"{a}*x^4 + b*x^2 + c = 0");
                    Console.WriteLine("B: ");
                int b = ToInt(Console.ReadLine());
                System.Console.Clear();
                    Console.WriteLine($"{a}*x^4 + {b}*x^2 + c = 0");
                    Console.WriteLine("C: ");
                int c = ToInt(Console.ReadLine());
                System.Console.Clear();
                    Console.WriteLine($"{a}*x^4 + {b}*x^2 + {c} = 0");
                    double[] answers = BiSquare(a, b, c);
                    Console.WriteLine("Answer: ");
            for (int i = 0; i < answers.Length; i++) Console.WriteLine(answers + "");
        }
    }
}