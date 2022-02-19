using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> output = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
                string userName = input[1];

                if (command == "register")
                {
                    string licensePlateNumber = input[2];

                    if (output.ContainsKey(userName) == false)
                    {
                        output.Add(userName, licensePlateNumber);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {output[userName]}");
                    }
                }
                else if (command == "unregister")
                {
                    if (output.ContainsKey(userName) == false)
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        output.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                }
            }
            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
