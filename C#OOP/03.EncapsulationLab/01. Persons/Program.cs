using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();
            try
            {
                for (int i = 0; i < n; i++)
                {
                    string[] inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Person person = new Person(inputData[0], inputData[1], int.Parse(inputData[2]), decimal.Parse(inputData[3]));
                    persons.Add(person);
                  
                }

                

                Team team = new Team("dreamteam");

                persons.ForEach(p => team.AddPlayer(p));
                Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
                Console.WriteLine($"Reserved team has {team.ReserveTeam.Count} players.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}
