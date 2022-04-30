using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string firsName, string lastName, string id,int codeNumber) 
            : base(firsName, lastName, id)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set;  }

        public override string ToString()
        {
            return base.ToString() +
                Environment.NewLine + $"Code Number: {CodeNumber}".TrimEnd(); 
        }
    }
}
