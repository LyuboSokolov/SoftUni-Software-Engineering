using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();



            while (command != "Beast")
            {
                string inputData = Console.ReadLine();
                string[] tokens = inputData.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];

                if (string.IsNullOrEmpty(name) || age < 0 || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                if (command == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);

                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (command == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);

                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (command == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);

                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if (command == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);

                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                }
                else if (command == "Kittens")
                {
                    Kitten kittens = new Kitten(name, age);

                    Console.WriteLine(kittens);
                    Console.WriteLine(kittens.ProduceSound());
                }



                command = Console.ReadLine();
            }
        }
    }
}
