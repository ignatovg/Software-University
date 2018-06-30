public class Student
{
    public double Grade { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }

    public Student(string name, int age, double grade)
    {
        this.Name = name;
        this.Age = age;
        this.Grade = grade;
    }

    public override string ToString()
    {
        string comment = string.Empty;
        if (Grade >= 5.00)
        {
            comment =  "Excellent student.";
        }
        else if (Grade < 5.00 && Grade >= 3.50)
        {
            comment ="Average student.";
        }
        else
        {
            comment ="Very nice person.";
        }
        return $"{Name} is {Age} years old. {comment}";
    }
}