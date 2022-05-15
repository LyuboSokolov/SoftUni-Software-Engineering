using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Drinks
{
    public class Tea : Drink,IDrink
    {
        private const decimal teaPrice = 2.50M;
        public Tea(string name, int portion, string brand) 
            : base(name, portion, teaPrice, brand)
        {
        }
    }
}
