using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
               .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> companys = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                string companyName = input[0];
                string employeeId = input[1];

                if (companys.ContainsKey(companyName) == false)
                {
                    companys.Add(companyName, new List<string>());
                }
                if (companys[companyName].Contains(employeeId))
                {
                    input = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                companys[companyName].Add(employeeId);

                input = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }

            companys = companys.OrderBy(n => n.Key).ToDictionary(a => a.Key, a => a.Value);

            foreach (var company in companys)
            {
                Console.WriteLine(company.Key);
                foreach (var item in company.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
