namespace CS_LABS.OBJECTS;

public class Employee
{
    public delegate void ChangeJob(Jobs title, double salary);
    
    public Employee()
    {
        ChangeJob changeJob = null;
        changeJob += SalaryChange;
        changeJob += TitleChange;
    }
    public string Surname { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public Jobs Job { get; set; }
    public enum Jobs
    {
        TeamLeader,
        Senior,
        Middle,
        Junior
    }

    public void SurnameChange(string surname)
    {
        Surname = surname;
    }
    private void SalaryChange(Jobs title, double salary)
    {
        Salary = salary;
    }
    public void TitleChange(Jobs title, double salary)
    {
        Job = title;
    }
    
}