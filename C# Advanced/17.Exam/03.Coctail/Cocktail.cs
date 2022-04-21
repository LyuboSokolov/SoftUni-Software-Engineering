using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name,int capacity,int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }
        public List<Ingredient> Ingredients { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int CurrentAlcoholLevel => Ingredients.Sum(p => p.Alcohol);
        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.FirstOrDefault(p=> p.Name == ingredient.Name) == null)
            {
                if (Ingredients.Count < Capacity)
                {
                    Ingredients.Add(ingredient);
                }
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(p => p.Name == name);

            if (ingredient!= null)
            {
                Ingredients.Remove(ingredient);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(p => p.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(p => p.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
