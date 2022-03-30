using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestAndPasswords = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> namesContentsPoints = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] splitData = input.Split(":");
                string contest = splitData[0];
                string password = splitData[1];

                if (!contestAndPasswords.ContainsKey(contest))
                {
                    contestAndPasswords.Add(contest, password);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] splitData = input.Split("=>");
                string contest = splitData[0];
                string password = splitData[1];
                string name = splitData[2];
                int point = int.Parse(splitData[3]);

                if (contestAndPasswords.ContainsKey(contest) && contestAndPasswords[contest] == password)
                {
                    if (!namesContentsPoints.ContainsKey(name))
                    {
                        namesContentsPoints.Add(name, new Dictionary<string, int>());
                    }
                    if (!namesContentsPoints[name].ContainsKey(contest))
                    {
                        namesContentsPoints[name].Add(contest, 0);
                    }
                    if (namesContentsPoints[name][contest] < point)
                    {
                        namesContentsPoints[name][contest] = point;
                    }
                }

                input = Console.ReadLine();
            }
            namesContentsPoints = namesContentsPoints.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Best candidate is {namesContentsPoints.FirstOrDefault().Key}" +
                $" with total {namesContentsPoints.FirstOrDefault().Value.Values.Sum()} points.");

            Console.WriteLine("Ranking:");

            foreach (var student in namesContentsPoints.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var item in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
