using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] tokens = input
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if (command == "Reverse")
                {
                    string substring = tokens[1];

                    if (message.Contains(substring))
                    {
                        int index = message.IndexOf(substring);
                        message = message.Remove(index, substring.Length);
                        substring = new string(substring.Reverse().ToArray());
                        message = message + substring;
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = tokens[1];
                    string replacement = tokens[2];
                    message = message.Replace(substring, replacement);
                    Console.WriteLine(message);
                }


                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
