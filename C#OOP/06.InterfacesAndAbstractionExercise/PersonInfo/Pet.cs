﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Pet : IPet
    {
         public Pet(string name,string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
