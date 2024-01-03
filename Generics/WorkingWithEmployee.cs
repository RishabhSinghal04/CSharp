
class WorkingWithEmployee
{
    private static readonly List<Employee> employees = new()
    {
        new Employee("Jake Smith", "Space Navigation", 25000),
        new Employee("Anna Blake", "Space Navigation", 29000),
        new Employee("Barbara Oak", "Xenobiology", 21500),
        new Employee("Damien Parker", "Xenobiology", 22000),
        new Employee("Nisha Patel", "Mechanics", 21000),
        new Employee("Gustavo Sanchez", "Mechanics", 20000),
    };

    Dictionary<string, decimal> CalculateAverageSalaryPerDepartment(IEnumerable<Employee> employees)
    {
        Dictionary<string, List<Employee>> employeesPerDepartments = new();
        foreach (var employee in employees)
        {
            if (!employeesPerDepartments.ContainsKey(employee.Department))
            {
                employeesPerDepartments[employee.Department] = new List<Employee>();
            }
            employeesPerDepartments[employee.Department].Add(employee);
        }

        Dictionary<string, decimal> result = new();
        foreach (var employeesPerDepartment in employeesPerDepartments)
        {
            decimal sumOfSalaries = 0M;
            foreach (var employee in employeesPerDepartment.Value)
            {
                sumOfSalaries += employee.MonthlySalary;
            }

            var average = sumOfSalaries / employeesPerDepartment.Value.Count;
            result[employeesPerDepartment.Key] = average;
        }
        return result;
    }

    public void DisplayAverageSalariesPerDepartment()
    {
        Dictionary<string, decimal> averageSalaryPerDepartments =
            CalculateAverageSalaryPerDepartment(employees);

        Console.WriteLine("Department \t Average Salary");
        foreach (var averageSalaryPerDepartment in averageSalaryPerDepartments)
        {
            Console.WriteLine(averageSalaryPerDepartment.Key + " \t\t " +
                averageSalaryPerDepartment.Value);
        }
    }
}