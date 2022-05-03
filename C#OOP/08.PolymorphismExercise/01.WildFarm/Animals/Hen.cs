using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        private const double weightIncrease = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food food)
        {
            Weight += weightIncrease * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override string Talk()
        {
           return "Cluck";
        }

        
    }
}
