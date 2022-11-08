using System;
namespace CS_LABS.OBJECTS;

public class Employee {
    public delegate void ChangeJobDelegate(Jobs title, double salary);
    public readonly ChangeJobDelegate ChangeJob;
    public Employee() { 
        ChangeJob += SalaryChange;
        ChangeJob += TitleChange;
    }
    public string Surname { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public Jobs Job { get; set; }
    public void SurnameChange(string surname) {
        Surname = surname;
    }
    public void SalaryChange(Jobs title, double salary) {
        Salary = salary;
    }
    public void TitleChange(Jobs title, double salary) {
        Job = title;
    }
    public static void ChangeStrings(Action<string> vd, string str) {
        vd(str);
    }
    public enum Jobs {
        TeamLeader,
        Senior,
        Middle,
        Junior
    }
}