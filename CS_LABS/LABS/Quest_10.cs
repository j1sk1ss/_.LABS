using System;
using System.Collections.Generic;
using CS_LABS.OBJECTS;

namespace CS_LABS.LABS;

public class Quest10
{
    public void Main()
    {
        var lst = new List<Employee>
        {
            new ()
            {
                Surname = "Fot",
                Name = "Nikolay",
                Salary = 65000.0,
                Job = Employee.Jobs.Middle
            },
            new ()
            {
                Surname = "Krasilnikov",
                Name = "Denis",
                Salary = 36200.0,
                Job = Employee.Jobs.Junior
            },
            new ()
            {
                Surname = "Balakin",
                Name = "Kirill",
                Salary = 34000.0,
                Job = Employee.Jobs.Junior
            },
            new ()
            {
                Surname = "Yunicin",
                Name = "Stepan",
                Salary = 31000.0,
                Job = Employee.Jobs.Junior
            },
        };
        Console.WriteLine(lst[0].Job + " " + lst[0].Surname);
        
    }
}