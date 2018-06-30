public class Company
{
    public string CompanyName { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public override string ToString()
    {
        return $"{CompanyName} {Department} {Salary:f2}\r\n";
    }
}