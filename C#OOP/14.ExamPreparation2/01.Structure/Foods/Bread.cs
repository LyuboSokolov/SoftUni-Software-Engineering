using Bakery.Models.BakedFoods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Foods
{
    public class Bread : BakedFood,IBakedFood
    {
        private const int initialBreadPortion = 200;
        public Bread(string name, decimal price)
            : base(name, initialBreadPortion, price)
        {
        }
    }
}
