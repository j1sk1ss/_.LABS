using System;
using System.Collections.Generic;
using CS_LABS.LABS;

namespace CS_LABS
{
    internal static class Program {
        private static readonly Dictionary<int, Action> Labs = new() {
            { 1, new Quest1().Main },
            { 2, new Quest2().Main },
            { 3, new Quest3().Main },
            { 4, new Quest4().Main },
            { 5, new Quest5().Main },
            { 6, new Quest6().Main },
            { 7, new Quest7().Main },
            { 8, new Quest8().Main },
            { 9, new Quest9().Main },
            { 10, new Quest10().Main }
        };
        private static void Main() {
            Console.WriteLine("Choose a Lab: ");
            Labs[int.Parse(Console.ReadLine()!)]();
        }
    }
}