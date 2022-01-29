using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int nPeople = int.Parse(Console.ReadLine());
            int pCapacity = int.Parse(Console.ReadLine());

            int count = 0;

            while (true)
            {
                if (nPeople <= 0)
                {
                    break;
                }
                nPeople -= pCapacity;
                count++;

            }
            Console.WriteLine(count);
        }
    }
}
