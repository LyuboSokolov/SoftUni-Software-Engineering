using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Drinks
{
    public class Water : Drink,IDrink
    {
        private const decimal waterPrice = 1.50M;

        public Water(string name, int portion, string brand)
            : base(name, portion, waterPrice, brand)
        {
        }
    }
}
