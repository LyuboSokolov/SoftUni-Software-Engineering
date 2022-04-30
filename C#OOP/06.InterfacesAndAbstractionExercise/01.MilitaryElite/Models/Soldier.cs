using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        public Soldier(string firsName,string lastName, string id)
        {
            FirstName = firsName;
            LastName = lastName;
            Id = id;
        }
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Id { get; private set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} ";
        }
    }
}
