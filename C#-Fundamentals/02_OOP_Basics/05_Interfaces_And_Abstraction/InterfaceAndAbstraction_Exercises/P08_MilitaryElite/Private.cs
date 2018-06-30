using System;
using System.Collections.Generic;
using System.Text;
using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite
{
    public class Private:Soldier,IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:f2}";
        }
    }
}
