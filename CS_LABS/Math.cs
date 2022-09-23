using System;
using System.Collections.Generic;

namespace CS_LABS
{
    public class Math
    {
        public int ToInt(string str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch (FormatException e)
            {
                Console.WriteLine("This char is not a number!");
                throw;
            }
        }
        public static string Coordinate(double[] circle, double radius, double[] dot)
        {
            if (System.Math.Pow(dot[0] - circle[0], 2) + System.Math.Pow(dot[1] - circle[1], 2) <=
                System.Math.Pow(radius, 2)) return "Dot in this circle."; 
            if (System.Math.Pow(dot[0] - circle[0], 2) + System.Math.Pow(dot[1] - circle[1], 2) ==
                System.Math.Pow(radius, 2)) return "Dot on the circle";
            return "Dot not in this circle.";
        }
    }
}