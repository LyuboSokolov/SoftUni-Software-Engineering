using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsInParking = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                string carNumber = tokens[1];

                if (direction == "IN")
                {
                    carsInParking.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    carsInParking.Remove(carNumber);
                }

                input = Console.ReadLine();
            }
            if (carsInParking.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine,carsInParking));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

