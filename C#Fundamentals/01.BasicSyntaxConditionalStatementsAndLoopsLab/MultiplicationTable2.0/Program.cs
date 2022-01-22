using System;

namespace MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            int i = number2;
            do
            {
                Console.WriteLine($"{number} X {i} = {number * i}");
                i++;

            } while (i <= 10);
        }
    }
}
