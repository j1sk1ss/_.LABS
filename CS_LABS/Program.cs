using System;

namespace CS_LABS
{ 
    class Program : Math
    {
        private static void Main()
        {
            Console.WriteLine("Choose a Lab: ");
            int? k = ToInt(Console.ReadLine());
            switch (k)
            {
                case 1:
                    var quest1 = new Quest_1();
                    quest1.Main();
                    break;
                case 2:
                    var quest2 = new Quest_2();
                    quest2.Main();
                    break;
                default:
                    Console.WriteLine("Wrong number of Lab.");
                    break;
            }
        }
    }
}