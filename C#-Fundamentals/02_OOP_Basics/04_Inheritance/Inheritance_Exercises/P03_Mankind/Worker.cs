using System;
using System.Text;

class Worker : Human
{
    private const int WorkDaysPerWeek = 5;

    private decimal weekSalary;
    private double workHoursPerDay;

    private decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
            }
            weekSalary = value;
        }
    }
    private double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHoursPerDay)}");
            }
            workHoursPerDay = value;
        }
    }

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal SalaryPerHour => WeekSalary / (decimal)(WorkHoursPerDay * WorkDaysPerWeek);

    public override string ToString()
    {
        StringBuilder resultBuilder = new StringBuilder();
        resultBuilder
            .AppendLine(base.ToString())
            .AppendLine($"Week Salary: {WeekSalary:f2}")
            .AppendLine($"Hours per day: {WorkHoursPerDay:f2}")
            .AppendLine($"Salary per hour: {SalaryPerHour:f2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}
