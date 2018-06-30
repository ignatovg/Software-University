
using System.Collections.Generic;
using System.Linq;

class Family
{
    private List<Person> family;

    public Family()
    {
        family = new List<Person>();
    }

    public void AddMember(Person member)
    {
        family.Add(member);
    }

    public Person GetOldestMember()
    {
        var oldestMember = family.OrderByDescending(a => a.Age).First();
        return oldestMember;
    }
}

