using System;
using System.Collections.Generic;

using CS_LABS.LABS;
using CS_LABS.LABS.METHODS.FIFES_LAB;
using CS_LABS.LABS.METHODS.FIRST_LAB;
using CS_LABS.LABS.METHODS.FOURTH_LAB;
using CS_LABS.LABS.METHODS.SECOND_LAB;
using CS_LABS.LABS.METHODS.SIXTH_LAB;
using CS_LABS.LABS.METHODS.THIRD_LAB;

// Variant 6
namespace CS_LABS {
    internal static class Program {
        private static readonly List<Quest> MethodsLabs = new() {
            new First(),
            new Second(),
            new Third(),
            new Fourth(),
            new Fifes(),
            new Sixth()
        };
        
        private static readonly List<Quest> CryptoLabs = new() {
            new LABS.CRYPTO.FIRST_LAB.First()
        };

        private static void Main() {
            Console.Write("Choose a Lab: ");
            MethodsLabs[int.Parse(Console.ReadLine()!)].Initialization();
        }
    }
}