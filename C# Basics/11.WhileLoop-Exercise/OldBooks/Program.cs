using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOFBook = Console.ReadLine();
            int allBooks = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int counter = 0;

            while (nameOFBook != input)
            {

                input = Console.ReadLine();
                if (nameOFBook == input)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }
                counter++;

                if (counter >= allBooks)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
            }
        }
    }
}
