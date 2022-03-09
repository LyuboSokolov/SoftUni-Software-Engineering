using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> result = new Stack<string>(input.Reverse());

            while (result.Count > 1)
            {
                int leftNumber = int.Parse(result.Pop());
                string expressions = result.Pop();
                int rightNumber = int.Parse(result.Pop());

                if (expressions == "+")
                {
                    result.Push((leftNumber + rightNumber).ToString());
                }
                else if (expressions == "-")
                {
                    result.Push((leftNumber - rightNumber).ToString());
                }
            }
            Console.WriteLine(result.Pop());
        }

    }
}
