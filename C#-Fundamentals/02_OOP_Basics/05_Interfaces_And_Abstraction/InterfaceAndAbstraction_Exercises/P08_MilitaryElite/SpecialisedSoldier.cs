using System;
using System.Collections.Generic;
using System.Text;
using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite
{
    public abstract class SpecialisedSoldier:Private,ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        private void ParseCorps(string corps)
        {
            bool validCorps = Enum.TryParse(typeof(Corpus), corps, out object outCorps);

            if (!validCorps)
            {
                throw new ArgumentException("Invalid cops!");
            }
            this.Corps = (Corpus)outCorps;
        }

        public Corpus Corps { get; private set; }
    }
}
