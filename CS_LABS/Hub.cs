using System;
using System.Collections.Generic;

// Variant 6
namespace CS_LABS {
    public static class Program {
        private static void Main() {

            var methods = new  CS_LABS.LABS.WorkType(new() {
                new CS_LABS.LABS.METHODS.FIRST_LAB.First(),
                new CS_LABS.LABS.METHODS.SECOND_LAB.Second(),
                new CS_LABS.LABS.METHODS.THIRD_LAB.Third(),
                new CS_LABS.LABS.METHODS.FOURTH_LAB.Fourth(),
                new CS_LABS.LABS.METHODS.FIFES_LAB.Fifes(),
                new CS_LABS.LABS.METHODS.SIXTH_LAB.Sixth()
            });
            
            var crypto = new  CS_LABS.LABS.WorkType(new() {
                new LABS.CRYPTO.FIRST_LAB.First()
            });

            var probability = new  CS_LABS.LABS.WorkType(new() {
                new LABS.PROBABILITY_THEORY.FIRST_LAB.First()
            });

            crypto.Initialize();
        }
    }
}