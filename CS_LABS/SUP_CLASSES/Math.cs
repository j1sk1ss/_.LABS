using System;
namespace CS_LABS.SUP_CLASSES
{ public class Math
    { public int ToInt(string str)
        { try
            { return Convert.ToInt32(str); }
            catch (FormatException e) {
                Console.WriteLine($"This char is not a integer number! {e}");
                throw; }
        }
        public double ToDouble(string str)
        { try {
                return Convert.ToDouble(str); }
            catch (FormatException e) {
                Console.WriteLine($"This char is not a number! {e}");
                throw; }
        }
        public string CircleCheck(double[,] coordinates, double radius) // 00 01 Dot; 10 11 Circle;
        { double? tmpC = System.Math.Pow(coordinates[0, 0] - coordinates[1, 0], 2) +
                         System.Math.Pow(coordinates[0, 1] - coordinates[1, 1], 2);
            if (tmpC < System.Math.Pow(radius, 2.0)) return "Dot in this circle."; 
            return tmpC == System.Math.Pow(radius, 2.0) ? "Dot on the circle." : "Dot not in this circle."; }
    }
}