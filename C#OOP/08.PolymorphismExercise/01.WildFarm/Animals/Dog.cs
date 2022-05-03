using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        private const double weightIncrease = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight,livingRegion)
        {
        }

        public override void Feed(Food food)
        {

            if (food.GetType().Name != "Meat")
            {
                Console.WriteLine($"{nameof(Dog)} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += weightIncrease * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }

        public override string Talk()
        {
           return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
