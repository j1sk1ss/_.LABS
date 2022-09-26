using System;

namespace CS_LABS
{
    internal static class Program
    {
        private static void Main()
        {
            var math = new Math();
            Console.WriteLine("Choose a Lab: ");
            switch (math.ToInt(Console.ReadLine()))
            {
                case 1:
                    var quest1 = new Quest1();
                    quest1.Main();
                    break;
                case 2:
                    var quest2 = new Quest2();
                    quest2.Main();
                    break;
                case 3:
                    var quest3 = new Quest3();
                    quest3.Main();
                    break;
                default:
                    Console.WriteLine("Wrong number of Lab.");
                    break;
            }
        }
    }
}