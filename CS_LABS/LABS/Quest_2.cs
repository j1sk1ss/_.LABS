using System;
using System.Linq;
using CS_LABS.SUP_CLASSES;
namespace CS_LABS.LABS
{
    public class Quest2
    {
        private readonly Labs _labs = new();
        public void Main()
        {
            Console.WriteLine("Choose a work number: ");
            new Quest2().GetType().GetMethod($"Work_{_labs.Math.ToInt(Console.ReadLine())}")?.Invoke(new Quest2(), null);
        }
        public void Work_1() // Есть последовательность, надо задать Е и кол-во элементов посл. а после выводится ответ мол сумма эл., модуль который выше Е.
        {
            Console.WriteLine("Write count of elements: ");
            var count = _labs.Math.ToInt(Console.ReadLine());
            Console.WriteLine("Write E in n >= E: ");
            var e = _labs.Math.ToDouble(Console.ReadLine());
                double? answer = 0;
                for (var i = 0; i < count; i++)
                {
                    var number = System.Math.Pow(-1, i - 1) / System.Math.Pow(i, i);
                    if (System.Math.Abs(number) >= e) answer += number;
                }
            Console.WriteLine($"{answer} is answer.");
        }
        public void Work_2() // Задание заключается в том, что бы проверить все ли цифры в числе разные.
        {
            Console.WriteLine("Read a number, what should be checked for uniq: ");
            var number = _labs.Math.ToInt(Console.ReadLine()).ToString(); 
            var uniq = true;
                for (var i = 0; i < number.Length; i++)
                {
                    if (!number.Where((t, j) => number[i] == t && i != j).Any()) continue;
                    Console.WriteLine("This number don't have uniq numbers."); i = number.Length;
                    uniq = false;
                }
            if (uniq) Console.WriteLine("This number have all uniq numbers.");
        }
        public void Work_3() // Задание в том, что бы из заданного массива получить минимальное число и максимальное, а после вывести их сумму. 
        {
            Console.WriteLine("Type a lenght of array that will be filed by random integer numbers: ");
            var array =  _labs.Arrays.FillArrayOfInts(100, _labs.Math.ToInt(Console.ReadLine()));
                int min = int.MaxValue, max = int.MinValue;
                Console.WriteLine($"Array is: {Arrays.PrintArray(array)}");
                for (var i = 0; i < array.Length; i++)
                        if (i % 2 == 0)
                        {
                            if (min > array[i]) min = array[i];
                        }
                        else if (max < array[i]) max = array[i];
                Console.WriteLine($"Array and answer is sum of {min} and {max} and this is {min + max}");
        }
        public void Work_4() // Задание в том что бы после обьеденения последовательности числа так же были отсартированны.
        {
            Console.WriteLine("This work where u should write sizes of arrays: \n First array: ");
            var array1 = _labs.Arrays.FillArrayOfInts(100, _labs.Math.ToInt(Console.ReadLine()));
                    Console.WriteLine($"Array is {Arrays.PrintArray(array1)} \n Sorted array is {Arrays.PrintArray(Arrays.Sort(array1))} \n Second array:");
                    var array2 =  _labs.Arrays.FillArrayOfInts(100, _labs.Math.ToInt(Console.ReadLine()));
                    Console.WriteLine($"Array is {Arrays.PrintArray(array2)} \n Sorted array is {Arrays.PrintArray(Arrays.Sort(array2))}\nUnited array is:" +
                                      $" {Arrays.PrintArray(Arrays.Sort(Arrays.UniteArrays(array1,array2)))}");

        }
    }
}