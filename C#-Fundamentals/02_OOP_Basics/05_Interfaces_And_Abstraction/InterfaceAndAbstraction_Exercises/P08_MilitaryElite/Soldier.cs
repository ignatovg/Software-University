﻿using System;
using System.Collections.Generic;
using System.Text;
using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite
{
   public abstract class Soldier:ISoldier
    {
        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}";
        }
    }
}
