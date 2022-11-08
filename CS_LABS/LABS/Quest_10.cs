using System;
using System.Collections.Generic;
using CS_LABS.OBJECTS;

namespace CS_LABS.LABS;
public class Quest10 {
    public void Main() {
        var lst = new List<Employee> {
            new () {
                Surname = "Fot",
                Name = "Nikolay",
                Salary = 65000.0,
                Job = Employee.Jobs.Middle
            }
        };
        Console.WriteLine(lst[0].Job + " " + lst[0].Surname);
        lst[0].ChangeJob(Employee.Jobs.Senior, 75000.0);
        Console.WriteLine(lst[0].Job + " " + lst[0].Surname + " " + lst[0].Salary);
        Employee.ChangeStrings(lst[0].SurnameChange, "Aboba");
    }
}