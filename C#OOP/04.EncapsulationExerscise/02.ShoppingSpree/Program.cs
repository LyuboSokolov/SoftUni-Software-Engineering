using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] inputPersonData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            string[] inputProductData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                foreach (var currPerson in inputPersonData)
                {
                    int index = currPerson.IndexOf('=');
                    string name = currPerson.Substring(0, index);
                    double money = double.Parse(currPerson.Substring(index + 1));
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                foreach (var currProduct in inputProductData)
                {
                    int index = currProduct.IndexOf('=');
                    string name = currProduct.Substring(0, index);
                    double cost = double.Parse(currProduct.Substring(index + 1));
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            string inputCommand = Console.ReadLine();

            while (inputCommand != "END")
            {
                string[] tokens = inputCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string namePerson = tokens[0];
                string nameProduct = tokens[1];

                if (persons.FirstOrDefault(p => p.Name == namePerson).IsCanBuy(products.FirstOrDefault(p => p.Name == nameProduct)) == false)
                {
                    Console.WriteLine($"{namePerson} can't afford {nameProduct}");
                }
                else
                {
                    Console.WriteLine($"{namePerson} bought {nameProduct}");
                }

                inputCommand = Console.ReadLine();
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }

        }
    }
}
