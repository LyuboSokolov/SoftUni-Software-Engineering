using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int minWeight = 1;
        private const int maxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                var valueLower = value.ToLower();
                if (valueLower != "crispy" && valueLower != "chewy" && valueLower != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                if (value < minWeight || value > maxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{minWeight}..{maxWeight}].");
                }
                weight = value;
            }
        }
        public double GetCalories()
        {
            var flourTypeModifier = GetFlourTypeModifier();
            var bakingTechiqueModifier = GetBakingTechniqueModifier();

            return Weight * 2 * flourTypeModifier * bakingTechiqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            var backingTechniqueLower = BakingTechnique.ToLower();

           
            if (backingTechniqueLower == "crispy")
            {
                return 0.9;
            }
            else if (backingTechniqueLower == "chewy")
            {
                return 1.1;
            }
            return 1;
        }

        private double GetFlourTypeModifier()
        {
            var flourTypeLower = this.FlourType.ToLower();

            if (flourTypeLower == "white")
            {
                return 1.5;
            }
            return 1;
        }
    }
}
