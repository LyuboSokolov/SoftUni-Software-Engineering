using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            
            int sumMinutes = 0;
            

            sumMinutes = minutes + 15;
            

            if (sumMinutes>=60)
            {
                hour = hour + 1;
                sumMinutes = sumMinutes % 60;
            }
          
            if (hour>=24)
            {
                hour = 0;
            }
            

            if (sumMinutes<10)
            {
                Console.WriteLine($"{hour}:0{sumMinutes}");
            }
            else
            {
                Console.WriteLine($"{hour}:{sumMinutes}");
            }

        }
    }
}
