using System;
using System.Linq;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                string reversingInput = new string(input.Reverse().ToArray());

                Console.WriteLine($"{input} = {reversingInput}");

                input = Console.ReadLine();
            }
        }
    }
}
