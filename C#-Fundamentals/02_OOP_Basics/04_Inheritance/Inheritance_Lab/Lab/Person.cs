class Person
{
    private string privatePersonName;
    protected string protectedPersonProperty;
    public string publicPersonField;
    protected int age;


    public Person(int age)
    {
        
    }
}

class Teacher:Person
{
    private string privateTecherName;
    protected string protectedTecherProperty;
    public string publicTecherField;
    public new int age;

    public Teacher(int age):base(age)
    {
        
    }
    public void TestInheritanceee()
    {
    }
}

class UniversityTeacher:Teacher
{
    public UniversityTeacher(int age):base(age) 
    {
        
    }
    public void TestInheritance()
    {
        
    }
}
