using System;
using System.Collections.Generic;
using CS_LABS.INTERFACES;
using CS_LABS.LABS;

// Variant 6
namespace CS_LABS {
    internal static class Program {
        private static readonly List<Quest> Labs = new() {
            new First(),
            new Second()
        };
        
        private static void Main() {
            Console.Write("Choose a Lab: ");
            Labs[int.Parse(Console.ReadLine()!)].Initialization();
        }
    }
}