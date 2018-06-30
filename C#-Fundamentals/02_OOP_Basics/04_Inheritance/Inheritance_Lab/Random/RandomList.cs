using System.Collections.Generic;

public class RandomList : List<string>
{
    private System.Random rnd;

    public RandomList()
    {

    }

    public object RandomString(List<string> data)
    {
        int index = rnd.Next(0,data.Count-1);
        string str = data[index];
        data.RemoveAt(index);
        return str;
    }
}
