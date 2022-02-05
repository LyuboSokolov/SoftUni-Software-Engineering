using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] peopleInWagon = new int[n];
            int allPeople = 0;

            for (int i = 0; i < n; i++)
            {
                peopleInWagon[i] = int.Parse(Console.ReadLine());
                allPeople += peopleInWagon[i];
            }

            Console.WriteLine(string.Join(" ", peopleInWagon));
            Console.WriteLine(allPeople);
        }
    }
}
