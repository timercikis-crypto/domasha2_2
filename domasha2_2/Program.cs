public class Employee(string name, decimal baseSalary)
{
    public string Name { get; set; } = name;
    public decimal BaseSalary { get; set; } = baseSalary;

    public virtual string Role => "работник";
    public virtual decimal CalculateMonthlySalary() => BaseSalary;
}

public class Manager(string name, decimal baseSalary, decimal bonus) : Employee(name, baseSalary)
{
    public decimal Bonus { get; set; } = bonus;

    public override string Role => "менеджер";
    public override decimal CalculateMonthlySalary() => BaseSalary + Bonus;
}

public class Developer(string name, decimal baseSalary, int linesOfCode) : Employee(name, baseSalary)
{
    public int LinesOfCodeWritten { get; set; } = linesOfCode;
    private const decimal RatePerLine = 5m;

    public override string Role => "разработчик";
    public override decimal CalculateMonthlySalary() => BaseSalary + (LinesOfCodeWritten * RatePerLine);
}

class Program
{
    static void Main()
    {
        List<Employee> employees =
        [new Manager("Иван петров", 85000m, 20000m), new Developer("Анна сидорова", 80000m, 3050), new Manager("олег васильев", 100000m, 30000m)];

        Console.WriteLine("    -  расчет Зарплаты  -   ");

        foreach (Employee emp in employees)
            Console.WriteLine($"Зп для ; {emp.Role} {emp.Name}: {emp.CalculateMonthlySalary()}");
        Console.ReadLine();
    }
}
