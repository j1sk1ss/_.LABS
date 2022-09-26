using System;
using System.Linq;

namespace CS_LABS
{
    public class Quest2
    {
        private readonly Math _math = new Math();
        private readonly Labs _labs = new Labs();
        public void Main()
        {
            var voids = new Action[4];
                    voids[0] = Work_1;
                    voids[1] = Work_2;
                    voids[2] = Work_3;
                    voids[3] = Work_4;
                _labs.AddVoids(voids);
            Console.WriteLine("Choose a work number: ");
            _labs.Works[_math.ToInt(Console.ReadLine())]();
        }

        private void Work_1()
        {
            Console.WriteLine("Write count of elements: ");
            var count = _math.ToInt(Console.ReadLine());
            Console.WriteLine("Write E in n >= E: ");
            double e = _math.ToInt(Console.ReadLine());
                double? answer = 0;
                for (var i = 0; i < count; i++)
                {
                    var number = System.Math.Pow(-1, i - 1) / System.Math.Pow(i, i);
                    if (System.Math.Abs(number) >= e) answer += number;
                }
            Console.WriteLine($"{answer} is answer.");
        }

        private void Work_2()
        {
            Console.WriteLine("Read a number, what should be checked: ");
            var number = _math.ToInt(Console.ReadLine()).ToString(); // Checks what char user write
            var uniq = true;
                for (var i = 0; i < number.Length; i++)
                {
                    if (!number.Where((t, j) => number[i] == t && i != j).Any()) continue;
                    Console.WriteLine("This number don't have uniq numbers."); i = number.Length;
                    uniq = false;
                }
            if (uniq) Console.WriteLine("This number have all uniq numbers.");
        }

        private void Work_3()
        {
            Console.WriteLine("Type a lenght of array that will be filed by random integer numbers: ");
            var lenght = _math.ToInt(Console.ReadLine());
            var array = _arrays.FillArrayOfInts(100, lenght);
                int min = Int32.MaxValue, max = Int32.MinValue;
                Console.WriteLine($"Array is: {Arrays.PrintArray(array)}");
                    for (var i = 0; i < lenght; i++)
                    {
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

        private readonly Arrays _arrays = new Arrays();
        private void Work_4()
        {
            Console.WriteLine("This work where u should write sizes of arrays: ");
                Console.WriteLine("First array: ");
                var size1 = _math.ToInt(Console.ReadLine());
                    var array1 = _arrays.FillArrayOfInts(100, size1);
                    Console.WriteLine($"Array is {Arrays.PrintArray(array1)}");
                    Console.WriteLine($"Sorted array is {Arrays.PrintArray(Arrays.Sort(array1))}");
                Console.WriteLine("Second array: ");
                var size2 = _math.ToInt(Console.ReadLine());
                    var array2 = _arrays.FillArrayOfInts(100, size2);
                    Console.WriteLine($"Array is {Arrays.PrintArray(array2)}");
                    Console.WriteLine($"Sorted array is {Arrays.PrintArray(Arrays.Sort(array2))}"); 
            Console.WriteLine($"United array is: {Arrays.PrintArray(Arrays.Sort(Arrays.UniteArrays(array1,array2)))}");
        }
    }
}