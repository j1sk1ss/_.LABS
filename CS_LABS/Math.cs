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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public static double[] BiSquare(int a, int b, int c)
        {
            double[] ans = new double[10];
            return ans;
        }
    }
}