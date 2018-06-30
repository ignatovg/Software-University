public class Parent
{
    public string ParentName { get; set; }
    public string ParentBirthday { get; set; }

    public override string ToString()
    {
        return $"{ParentName} {ParentBirthday}\r\n";
    }
}