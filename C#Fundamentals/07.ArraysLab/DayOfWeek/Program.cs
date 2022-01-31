using System;

namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dayOfWeek = new string[]
           {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
           };
            int input = int.Parse(Console.ReadLine());

            if (input > 0 && input <= dayOfWeek.Length)
            {
                Console.WriteLine($"{dayOfWeek[input - 1]}");
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
