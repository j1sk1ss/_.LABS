// Variant 6
namespace CS_LABS {
    public static class Program {
        private static void Main() {

            var methods = new LABS.WorkType(new() {
                new LABS.METHODS.FIRST_LAB.First(),
                new LABS.METHODS.SECOND_LAB.Second(),
                new LABS.METHODS.THIRD_LAB.Third(),
                new LABS.METHODS.FOURTH_LAB.Fourth(),
                new LABS.METHODS.FIFES_LAB.Fifes(),
                new LABS.METHODS.SIXTH_LAB.Sixth()
            });
            
            var crypto = new LABS.WorkType(new() {
                new LABS.CRYPTO.FIRST_LAB.First(),
                new LABS.CRYPTO.SECOND_LAB.Second(),
                new LABS.CRYPTO.THIRD_LAB.Third()
            });

            var probability = new LABS.WorkType(new() {
                new LABS.PROBABILITY_THEORY.FIRST_LAB.First()
            });
            
            var numMethods = new LABS.WorkType(new() {
                new LABS.NUM_METHODS.FIRST_LAB.First(),
                new LABS.NUM_METHODS.SECOND_LAB.Second(),
                new LABS.NUM_METHODS.THIRD_LAB.Third(),
            });

            crypto.Initialize();
        }
    }
}