
class Employee
{
    public string Name {get; init;}
    public string Department {get; init;}
    public decimal MonthlySalary {get; init;}

    public Employee(string name, string department, decimal monthlySalary)
    {
        Name = name;
        Department = department;
        MonthlySalary = monthlySalary;
    }
}