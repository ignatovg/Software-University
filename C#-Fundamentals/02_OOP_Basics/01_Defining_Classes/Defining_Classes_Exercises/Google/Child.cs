public class Child
{
    public string ChildName { get; set; }
    public string ChildBirthday { get; set; }

    public override string ToString()
    {
        return $"{ChildName} {ChildBirthday}\r\n";
    }
}