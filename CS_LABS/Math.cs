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
                Console.WriteLine("This char is not a integer number!");
                throw;
            }
        }

        public double ToDouble(string str)
        {
            try
            {
                return Convert.ToDouble(str);
            }
            catch (FormatException e)
            {
                Console.WriteLine("This char is not a number!");
                throw;
            }
        }
        public string CircleCheck(double[,] coordinates, double radius) // 00 01 Dot; 10 11 Circle;
        {
            double? tmpC = System.Math.Pow(coordinates[0, 0] - coordinates[1, 0], 2) +
                           System.Math.Pow(coordinates[0, 1] - coordinates[1, 1], 2);
            if (tmpC < System.Math.Pow(radius, 2)) return "Dot in this circle."; 
            if (tmpC == System.Math.Pow(radius, 2)) return "Dot on the circle.";
            return "Dot not in this circle.";
        }
        Random random = new Random();
        public int[] FillArrayOfInts(int maxRand, int size)
        {
       
            int[] ar = new int[size];
                for (int i = 0; i < ar.Length; i++) ar[i] = random.Next() % 100;
            return ar;
        }

        public int[] UniteArrays(int[] array1, int[] array2)
        {

            int[] unar = new int[array1.Length + array2.Length];
            for (int i = 0; i < array1.Length; i++) unar[i] = array1[i];
            for (int i = array1.Length; i < array2.Length; i++) unar[i] = array2[i];

            return unar;
        }
        public int[] Sort(int[] array)
        {
            int[] ar = array;
            Array.Sort(ar);
            return ar;
        }
    }
}