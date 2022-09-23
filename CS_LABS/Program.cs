using System;

namespace CS_LABS
{
    class Program : Math
    {
        private static Math _math = new Math();
        static void Main()
        {
            Console.WriteLine("Choose a Lab: ");
            int? k = _math.ToInt(Console.ReadLine());
            switch (k)
            {
                case 1:
                    Quest_1 quest1 = new Quest_1();
                    quest1.Main();
                    break;
                default:
                    Console.WriteLine("Wrong number of Lab.");
                    break;
            }
        }
    }
}