using System;
using System.Collections.Generic;

namespace _01.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<string> reverseString = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                reverseString.Push(input[i].ToString());
            }

            while (reverseString.Count>0)
            {
                Console.Write(reverseString.Pop());
            }
            Console.WriteLine();
        }
    }
}
