using System;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] tokens = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    string insertString = tokens[2];

                    if (index >= 0 && index < destination.Length)
                    {
                        destination = destination.Insert(index, insertString);
                        Console.WriteLine(destination);
                    }
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if ((startIndex >= 0 && startIndex < destination.Length) && (startIndex <= endIndex) && (endIndex >= 0 && endIndex < destination.Length))
                    {
                        if (endIndex == destination.Length - 1)
                        {
                            destination = destination.Remove(startIndex);
                            Console.WriteLine(destination);
                        }
                        else
                        {
                            destination = destination.Remove(startIndex, endIndex - startIndex + 1);
                            Console.WriteLine(destination);
                        }

                    }
                }
                else if (command == "Switch")
                {
                    string oldString = tokens[1];
                    string newString = tokens[2];

                    if (destination.Contains(oldString))
                    {
                        destination = destination.Replace(oldString, newString);
                        Console.WriteLine(destination);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {destination}");
        }
    }
}
