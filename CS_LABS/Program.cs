using System;
using System.Collections.Generic;
using CS_LABS.LABS;
using Math = CS_LABS.SUP_CLASSES.Math;

namespace CS_LABS
{
    internal class Program
    {
        private static void Main()
        {
            var labs = new Dictionary<int, Action>();
                labs.Add(1, new Quest1().Main);
                labs.Add(2, new Quest2().Main);
                labs.Add(3, new Quest3().Main);
                labs.Add(4, new Quest4().Main);
                labs.Add(5, new Quest5().Main);
                labs.Add(6, new Quest6().Main);
                labs.Add(7, new Quest7().Main);
            var math = new Math();
            Console.WriteLine("Choose a Lab: ");
            labs[math.ToInt(Console.ReadLine())]();
        }
    }
}