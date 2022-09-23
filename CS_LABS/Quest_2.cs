using System;
using System.Collections.Generic;

namespace CS_LABS
{
    public class Quest_2 : Math
    {
        private readonly Dictionary<int, Action> _works = new Dictionary<int, Action>();
        private void AddVoids()
        {
            _works.Add(1,Work_1);
        }
        public void Main()
        {
            AddVoids();
            Console.WriteLine("Type a number of work:  ");
            _works[ToInt(Console.ReadLine())]();
        }

        private static void Work_1()
        {
            
        }
    }
}