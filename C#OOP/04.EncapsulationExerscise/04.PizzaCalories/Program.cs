using System;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughDate = Console.ReadLine().Split();
            string flourType = doughDate[1];
            string bakingTechnique = doughDate[2];
            int weightDough = int.Parse(doughDate[3]);
            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weightDough);
                Pizza pizza = new Pizza(pizzaName, dough);

                string inputTopping = Console.ReadLine();
                while (inputTopping != "END")
                {
                    string[] tokens = inputTopping.Split();
                    string nameTopping = tokens[1];
                    int weightTopping = int.Parse(tokens[2]);

                    var topping = new Topping(nameTopping, weightTopping);
                    pizza.AddTopping(topping);

                    inputTopping = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
