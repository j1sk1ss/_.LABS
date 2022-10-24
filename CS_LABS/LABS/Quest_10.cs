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
                Salary = 23000.0,
                Job = Employee.Jobs.Junior
            },
        };
        Console.WriteLine(lst[0].Job + " " + lst[0].Surname);
        lst[0].ChangeJob(Employee.Jobs.Senior, 75000.0);
        lst[1].ChangeJob(Employee.Jobs.Middle, 42000.0);
        lst[2].ChangeJob(Employee.Jobs.TeamLeader, 80000.0);
        lst.RemoveAt(3);
        Console.WriteLine(lst[0].Job + " " + lst[0].Surname + " " + lst[0].Salary);

    }
}