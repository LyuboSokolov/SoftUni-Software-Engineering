using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

           
            while (true)
            {
                string input = Console.ReadLine();
                
                if (input == "End")
                {
                    break;
                }
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);


                Animal animal = CreatAnimal(tokens);
                animals.Add(animal);

                input = Console.ReadLine();
                tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Food food = CreatFood(tokens);

                Console.WriteLine(animal.Talk());
                animal.Feed(food);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreatFood(string[] tokens)
        {
            string typeFood = tokens[0];
            int quantity = int.Parse(tokens[1]);

            Food food = null;
            if (typeFood == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (typeFood == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (typeFood == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (typeFood == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private static Animal CreatAnimal(string[] animalData)
        {
            Animal animal = null;
            string typeAnimal = animalData[0];
            string nameAnimal = animalData[1];
            double weightAnimal = double.Parse(animalData[2]);

            if (typeAnimal == nameof(Cat))
            {
                // •	Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Cat(nameAnimal, weightAnimal, livingRegion, breed);
            }
            else if (typeAnimal == nameof(Tiger))
            {
                string livingRegion = animalData[3];
                string breed = animalData[4];
                animal = new Tiger(nameAnimal, weightAnimal, livingRegion, breed);
            }
            else if (typeAnimal == nameof(Owl))
            {
                //•	Birds - "{Type} {Name} {Weight} {WingSize}";
                double wingSize = double.Parse(animalData[3]);
                animal = new Owl(nameAnimal, weightAnimal, wingSize);
            }
            else if (typeAnimal == nameof(Hen))
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Hen(nameAnimal, weightAnimal, wingSize);
            }
            else if (typeAnimal == nameof(Mouse))
            {
                //•	Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}";
                string livingRegion = animalData[3];
                animal = new Mouse(nameAnimal, weightAnimal, livingRegion);
            }
            else if (typeAnimal == nameof(Dog))
            {
                string livingRegion = animalData[3];
                animal = new Dog(nameAnimal, weightAnimal, livingRegion);
            }

            return animal;
        }
    }
}
