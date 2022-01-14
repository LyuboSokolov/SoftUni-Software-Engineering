using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double dohod = double.Parse(Console.ReadLine());
            double uspeh = double.Parse(Console.ReadLine());
            double minZap = double.Parse(Console.ReadLine());
            double social = 0;
            
            
            social = 0.35 * minZap;

            if (uspeh<4.50)
            {
                 Console.WriteLine ("You cannot get a scholarship!");
            }
            else if (uspeh<5.50)
            {
                if (dohod>minZap)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {social} BGN");  
                }
            }
            else
            {
                if (dohod>minZap)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(uspeh*25)} BGN");
                }
                else if (social>uspeh*25)
                {
                    Console.WriteLine($"You get a Social scholarship {social} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(uspeh * 25)}");
                }
            }
            


        }
    }
}
