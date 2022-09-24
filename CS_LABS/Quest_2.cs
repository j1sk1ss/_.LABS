using System;
using System.Collections.Generic;

namespace CS_LABS
{
    public class Quest_2
    {
        private Math _math = new Math();
        private readonly Dictionary<int, Action> _works = new Dictionary<int, Action>();
        private void AddVoids()
        {
            _works.Add(1,Work_1);
            _works.Add(2,Work_2);
            _works.Add(3,Work_3);
            _works.Add(4,Work_3);
        }
        public void Main()
        {
            AddVoids();
            Console.WriteLine("Type a number of work:  ");
            _works[_math.ToInt(Console.ReadLine())]();
        }

        private void Work_1()
        {
            Console.WriteLine("Write count of elements: ");
            var count = _math.ToInt(Console.ReadLine());
            Console.WriteLine("Write E in n >= E: ");
            double E = _math.ToInt(Console.ReadLine());
                double? answer = 0;
                for (var i = 0; i < count; i++)
                {
                    var number = System.Math.Pow(-1, i - 1) / System.Math.Pow(i, i);
                    if (System.Math.Abs(number) >= E) answer += number;
                }
            Console.WriteLine($"{answer} is answer.");
        }

        private void Work_2()
        {
            Console.WriteLine("Read a number, what should be checked: ");
            int k;
                try
                {
                    k = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            string number = k.ToString();
            bool uniq = true;
            for (int i = 0; i < number.Length; i++)
            {
                for (int j = 0; j < number.Length; j++)
                {
                    if (number[i] == number[j] && i != j) {Console.WriteLine("This number don't have uniq numbers."); i = number.Length;
                        uniq = false;
                        break;
                    }
                }
            }
            if (uniq) Console.WriteLine("This number have all uniq numbers.");
        }

        private void Work_3()
        {
            Console.WriteLine("Type a lenght of array that will be filed by random integer numbers: ");
            int lenght = _math.ToInt(Console.ReadLine());
            Random random = new Random();
                int[] array = new int[lenght];
                for (int i = 0; i < lenght; i++) array[i] = random.Next() % 100;
                int min = Int32.MaxValue, max = Int32.MinValue;
                for (int i = 0; i < lenght; i++)
                {
                    Console.Write(array[i] + " ");
                    switch (i % 2)
                    {
                        case 0:
                            if (min > array[i]) min = array[i];
                            break;
                        case 1:
                            if (max < array[i]) max = array[i];
                            break;
                    }
                }
                Console.WriteLine($"Array and answer is sum of {min} and {max} and this is {min + max}");
        }

        private void Work_4()
        {
            
        }
    }
}