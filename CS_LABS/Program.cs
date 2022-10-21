using System;
using System.Collections.Generic;
using CS_LABS.LABS;
using Math = CS_LABS.SUP_CLASSES.Math;
namespace CS_LABS
{
    internal static class Program
    {
        private static void Main()
        {
            var labs = new Dictionary<int, Action>
            {
                { 1, new Quest1().Main },
                { 2, new Quest2().Main },
                { 3, new Quest3().Main },
                { 4, new Quest4().Main },
                { 5, new Quest5().Main },
                { 6, new Quest6().Main },
                { 7, new Quest7().Main },
                { 8, new Quest8().Main }
            };
            Console.WriteLine("Choose a Lab: ");
            labs[new Math().ToInt(Console.ReadLine())]();
        }
    }
}