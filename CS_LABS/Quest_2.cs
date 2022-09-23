using System;

namespace CS_LABS
{
    public class Quest_2 : Math
    {
        public void Main()
        {
            Console.WriteLine("Type a number of work: ");
            int? work = ToInt(Console.ReadLine());
            switch (work)
            {
                case 1:
                    Work_1();
                    break;
                case 2:
  
                    break;
                case 3:
         
                    break;
                case 4:
        
                    break;
                default:
                    Console.WriteLine("Wrong number of work.");
                    break;
            }
        }

        private static void Work_1()
        {
            
        }
    }
}