using System;
using System.Collections.Generic;


namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularReservation = new HashSet<string>();
            HashSet<string> vipReservation = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {

                if (input[0] >= 48 && input[0] <= 57)
                {
                    vipReservation.Add(input);
                }
                else
                {
                    regularReservation.Add(input);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();

            while (input != "END")
            {
                regularReservation.Remove(input);
                vipReservation.Remove(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(regularReservation.Count + vipReservation.Count);
            if (vipReservation.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipReservation));
            }
            if (regularReservation.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, regularReservation));
            }

        }
    }
}
