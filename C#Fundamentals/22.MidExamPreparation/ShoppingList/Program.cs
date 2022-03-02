using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
               .Split('!', StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            string input = Console.ReadLine();


            while (input?.ToUpper() != "GO SHOPPING!")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string item = tokens[1];


                if (command == "Urgent")
                {
                    if (items.Contains(item))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    items.Insert(0, item);
                }
                else if (command == "Unnecessary")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }

                }
                else if (command == "Correct")
                {
                    string newItem = tokens[2];

                    if (items.Contains(item))
                    {
                        int indexOldItem = items.IndexOf(item);
                        items[indexOldItem] = newItem;
                    }
                }
                else if (command == "Rearrange")
                {
                    if (items.Contains(item))
                    {
                        string currentItem = item;
                        items.Remove(item);
                        items.Add(currentItem);
                    }

                }


                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
