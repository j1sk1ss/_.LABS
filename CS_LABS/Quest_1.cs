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
            double[] dc = new double[2];
            double[] cc = new double[2];
            Console.WriteLine("This work where u should type a values of coordinates dot X, Y and circle X, Y and his radius:");
            Console.WriteLine("Dot X: ");
                dc[0] = ToInt(Console.ReadLine());
                Console.WriteLine("Dot Y: ");
                dc[1] = ToInt(Console.ReadLine());
                Console.WriteLine("Circle X: ");
                cc[0] = ToInt(Console.ReadLine());
                Console.WriteLine("Circle Y: ");
                cc[1] = ToInt(Console.ReadLine());
                Console.WriteLine("Circle radius: ");
                double r = ToInt(Console.ReadLine());
            Console.WriteLine(Coordinate(dc, r, cc));
        }
    }
}