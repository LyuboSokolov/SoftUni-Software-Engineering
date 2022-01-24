using System;

namespace PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int finalNumber = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = startNumber; i <= finalNumber; i++)
            {
                sum += i;
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
