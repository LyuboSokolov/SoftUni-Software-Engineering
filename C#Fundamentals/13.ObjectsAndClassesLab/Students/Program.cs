using System;
using System.Collections.Generic;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Studends> studends = new List<Studends>();

            string[] informationForStudend = Console.ReadLine().Split();

            while (informationForStudend[0] != "end")
            {
                string firstName = informationForStudend[0];
                string lastName = informationForStudend[1];
                string age = informationForStudend[2];
                string homeTown = informationForStudend[3];

                Studends studend = new Studends();
                studend.FirstName = firstName;
                studend.LastName = lastName;
                studend.Age = age;
                studend.HomeTown = homeTown;

                studends.Add(studend);

                informationForStudend = Console.ReadLine().Split();
            }

            string nameOfCity = Console.ReadLine();

            foreach (Studends studend in studends)
            {
                if (studend.HomeTown == nameOfCity)
                {
                    Console.WriteLine($"{ studend.FirstName} {studend.LastName} is {studend.Age} years old.");
                }
            }
        }
    }

    class Studends
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HomeTown { get; set; }
    }
}

