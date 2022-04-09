using System;

namespace DefiningClasses
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            Person Pesho = new Person() { Name = "Pesho", Age = 20 };

            Person Gosho = new Person();
            Gosho.Name = "Gosho";
            Gosho.Age = 18;

            Person Stamat = new Person() { Name = "Stamat", Age = 43 };
        }
    }
    public class Person
    {
               
        public string Name { get; set; }

        public int Age { get; set; }
    }
}


