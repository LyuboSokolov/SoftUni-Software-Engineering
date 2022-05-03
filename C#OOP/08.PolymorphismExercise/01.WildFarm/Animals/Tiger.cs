using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Tiger : Feline
    {
        private const double weightIncrease = 1.00;
        public Tiger(string name, double weight,string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override void Feed(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                Console.WriteLine($"{nameof(Tiger)} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += weightIncrease * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }

        public override string Talk()
        {
            return "ROAR!!!";
        }
    }
}
