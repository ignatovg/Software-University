using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public  class Sorter:CustomList<string>
{

    public Sorter(List<string> dataList) : base(dataList)
    {
    }

    public  void Sort()
    {
        base.data = data.OrderBy(s => s).ToList();
    }
}

