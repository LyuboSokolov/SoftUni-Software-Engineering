using System;

namespace _05.FilterByAge
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] peoples = new Person[n];
            for (int i = 0; i < n; i++)
            {
                peoples[i] = new Person();
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                peoples[i].Name = name;
                peoples[i].Age = age;
            }
           

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            Func<Person, bool> condition = GetAgeCondition(filter, filterAge);
            Func<Person, string> formatter = GetFormatter(Console.ReadLine());
            PrintPeople(peoples, condition, formatter);
        

        }

        static Func<Person, string> GetFormatter(string format) 
        {
            switch (format)
            {
                case "name":
                    return p => $"{p.Name}";
                case "age":
                    return p => $"{p.Age}";
                case "name age":
                    return p => $"{p.Name} - {p.Age}";
                default:
                    return null;
                   
            }
        }
        static Func<Person, bool> GetAgeCondition(string filter, int filterAge)
        {
            switch (filter)
            {
                case "younger": return p => p.Age < filterAge;
                case "older": return p => p.Age >= filterAge;
                default:
                    return null;
            }
        }

        static void PrintPeople(Person[] people, Func<Person, bool> condition,Func<Person,string> formatter)
        {
            foreach (var person in people)
            {
                if (condition(person))
                {
                    Console.WriteLine(formatter(person));
                }
            }
        }
    }
}
