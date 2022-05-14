using Bakery.Models.BakedFoods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Foods
{
    public class Cake : BakedFood, IBakedFood
    {
        private const int initialCakePortion = 245;
        public Cake(string name, decimal price) 
            : base(name, initialCakePortion, price)
        {
        }
    }
}
