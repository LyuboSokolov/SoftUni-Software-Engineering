using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        private const double weightIncrease = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                Console.WriteLine($"{nameof(Owl)} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += weightIncrease * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }

        public override string Talk()
        {
            return "Hoot Hoot";
        }
    }
}
