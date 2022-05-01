using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                if (buyers.ContainsKey(name))
                {
                    continue;
                }
                if (inputData.Length == 4)
                {

                    string id = inputData[2];
                    string birthdate = inputData[3];
                    buyers.Add(name, new Citizen(name, age, id, birthdate));
                }
                else if (inputData.Length == 3)
                {

                    string group = inputData[2];
                    buyers.Add(name, new Rebel(name, age, group));
                }
            }

            string namePeople = Console.ReadLine();

            while (namePeople != "End")
            {
                if (buyers.ContainsKey(namePeople))
                {
                    IBuyer currBuyer = buyers[namePeople];
                    currBuyer.BuyFood();
                }

                namePeople = Console.ReadLine();
            }
            int allSum = 0;
            
            foreach (var item in buyers)
            {
                allSum += item.Value.Food;
            }
            Console.WriteLine(allSum);
        }
    }
}
