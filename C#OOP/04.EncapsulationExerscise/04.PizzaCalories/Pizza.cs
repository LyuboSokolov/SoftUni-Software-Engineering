using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int minNameLenght = 1;
        private const int maxNameLenght = 15;
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name,Dough dough)
        {
            Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }
        public string Name
        {

            get => name;
            private set
            {
                if (value.Length < minNameLenght || value.Length > maxNameLenght)
                {
                    throw new ArgumentException($"Pizza name should be between {minNameLenght} and {maxNameLenght} symbols.");
                }
                name = value;
            }
        }

       public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            return dough.GetCalories() + toppings.Sum(t => t.GetCalories());
        }
    }
}
