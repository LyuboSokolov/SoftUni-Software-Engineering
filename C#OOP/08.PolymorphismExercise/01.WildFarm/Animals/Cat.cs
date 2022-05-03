using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Cat : Feline
    {
        private const double weightIncrease = 0.30;
        public Cat(string name, double weight,string livingRegion, string breed) 
            : base(name, weight,livingRegion, breed)
        {
        }

        public override void Feed(Food food)
        {
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
            {
                Console.WriteLine($"{nameof(Cat)} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += weightIncrease * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }

        public override string Talk()
        {
            return "Meow";
        }
    }
}
