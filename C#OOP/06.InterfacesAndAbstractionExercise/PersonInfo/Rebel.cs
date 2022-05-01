using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
   public class Rebel : IBuyer
    {
        private const int priceFood = 5;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Group { get; set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += priceFood; ;
        }
    }
}
