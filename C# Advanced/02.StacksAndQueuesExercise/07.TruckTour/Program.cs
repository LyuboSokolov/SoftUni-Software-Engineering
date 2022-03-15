using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> fuelAndDistance = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                fuelAndDistance.Enqueue(input);
            }

            for (int i = 0; i < n; i++)
            {
                bool isSuccesfull = true;
                int fuel = 0;

                for (int j = 0; j < n; j++)
                {
                    string currentFuelAndDistance = fuelAndDistance.Dequeue();
                    int[] currFuelAndDistance = currentFuelAndDistance.Split().Select(int.Parse).ToArray();
                    fuelAndDistance.Enqueue(currentFuelAndDistance);
                    fuel += currFuelAndDistance[0];
                    fuel -= currFuelAndDistance[1];

                    if (fuel < 0)
                    {
                        isSuccesfull = false;
                    }
                }
                if (isSuccesfull)
                {
                    Console.WriteLine(i);
                    break;
                }

                string temp = fuelAndDistance.Dequeue();
                fuelAndDistance.Enqueue(temp);
            }

        }
    }
}
