using System;
using System.Collections.Generic;
using CS_LABS.LABS;
using CS_LABS.LABS.FIFES_LAB;
using CS_LABS.LABS.FOURTH_LAB;
using CS_LABS.LABS.SECOND_LAB;
using CS_LABS.LABS.SIXTH_LAB;
using CS_LABS.LABS.THIRD_LAB;

// Variant 6
namespace CS_LABS {
    internal static class Program {
        private static readonly List<Quest> Labs = new() {
            new First(),
            new Second(),
            new Third(),
            new Fourth(),
            new Fifes(),
            new Sixth()
        };
        
        private static void Main() {
            Console.Write("Choose a Lab: ");
            Labs[int.Parse(Console.ReadLine()!)].Initialization();
        }
    }
}