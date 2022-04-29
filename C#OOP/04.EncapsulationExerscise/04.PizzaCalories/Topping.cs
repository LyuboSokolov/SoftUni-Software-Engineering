using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int minWeight = 1;
        private const int maxWeight = 50;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name
        {
            get => name;
            private set
            {
               string valueLower = value.ToLower();
                if (valueLower != "meat" && valueLower != "veggies" && valueLower != "cheese" && valueLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                name = value;
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                if (value < minWeight || value > maxWeight)
                {
                    throw new ArgumentException($"{Name} weight should be in the range [{minWeight}..{maxWeight}].");
                }
                weight = value;
            }
        }

        public double GetCalories()
        {
            var modifier = GetModifier();

            return Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            var nameLower = Name.ToLower();

            if (nameLower == "meat")
            {
                return 1.2;
            }
            else if (nameLower == "veggies")
            {
                return 0.8;
            }
            else if (nameLower == "cheese")
            {
                return 1.1;
            }

            return 0.9;
        }
    }
}
