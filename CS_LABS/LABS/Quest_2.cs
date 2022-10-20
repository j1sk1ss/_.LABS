using System;
using System.Linq;
using CS_LABS.SUP_CLASSES;
namespace CS_LABS.LABS
{ public class Quest2 : Labs
    { public void Main()
        { Console.WriteLine("Choose a work number: ");
                new Quest2().GetType().GetMethod($"Work_{Math.ToInt(Console.ReadLine())}")?.
                    Invoke(new Quest2(), null); }
        public void Work_1() // Есть последовательность, надо задать Е и кол-во элементов посл. а после выводится ответ мол сумма эл., модуль который выше Е.
        { Console.WriteLine("Write E in n >= E: ");
                    var e = Math.ToDouble(Console.ReadLine());
            var answer = 0.0;
            var i = 1.0;
            var thisNum = i % 2 == 0 ? 1 : -1 / System.Math.Pow(i, i);
            while (System.Math.Abs(thisNum) > e)
            { answer += thisNum; i += 1.0;
                thisNum = i % 2 == 0 ? 1 : -1 / System.Math.Pow(i, i); }
            Console.WriteLine($"{answer} is sum of elements higher then E and the count of this elements is {i}."); }
        public void Work_2() // Задание заключается в том, что бы проверить все ли цифры в числе разные.
        { Console.WriteLine("Read a number, what should be checked for uniq: ");
                var number = Math.ToInt(Console.ReadLine()).ToString();
            Console.WriteLine(number.Where((t1, i) => number.Where((t, j) => t1 == t && i != j).Any()).Any()
                ? "This number don't have all uniq numbers."
                : "This number have all uniq numbers."); }
        public void Work_3() // Задание в том, что бы из заданного массива получить минимальное число и максимальное, а после вывести их сумму. 
        { Console.WriteLine("Type a lenght of array that will be filed by random integer numbers: "); 
            var array = Arrays.FillArrayOfDoubles(100, Math.ToInt(Console.ReadLine()));
                double min = double.MaxValue, max = double.MinValue;
                Console.WriteLine($"Array is: {Arrays.PrintDoubleArray(array)}");
            for (var i = 0; i < array.Length; i++)
                if (i % 2 == 0) {if (min > array[i]) min = array[i];}
                    else if (max < array[i]) max = array[i];
            Console.WriteLine($"Array and answer is sum of {min} and {max} and this is {min + max}"); }
        public void Work_4() // Задание в том что бы после обьеденения последовательности числа так же были отсартированны.
        { Console.WriteLine("This work where u should write sizes of arrays: \nFirst array: "); 
                var array1 = Arrays.FillArrayOfInts(100, Math.ToInt(Console.ReadLine()));
            Console.WriteLine(
                $"Array is {Arrays.PrintArray(array1)} \nSorted array is {Arrays.PrintArray(Arrays.Sort(array1))} \nSecond array:");
                    var array2 = Arrays.FillArrayOfInts(100, Math.ToInt(Console.ReadLine()));
            Console.WriteLine($"Array is {Arrays.PrintArray(array2)} \nSorted array is {Arrays.PrintArray(Arrays.Sort(array2))}\nUnited array is:" +
                              $" {Arrays.PrintArray(Arrays.UniteArrays(array1, array2))}"); }
    }
}