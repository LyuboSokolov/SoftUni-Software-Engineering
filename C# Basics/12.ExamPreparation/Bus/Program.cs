using System;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int pasagers = int.Parse(Console.ReadLine());
            int busStop = int.Parse(Console.ReadLine());

            for (int i = 1; i <= busStop; i++)
            {
                int pasagersOut = int.Parse(Console.ReadLine());
                int pasagersIn = int.Parse(Console.ReadLine());
                if (i%2==1)
                {
                    pasagers = pasagers - pasagersOut + pasagersIn + 2;
                }
                else if (i%2==0)
                {
                    pasagers = pasagers - pasagersOut + pasagersIn - 2;
                }
            }
            Console.WriteLine($"The final number of passengers is : {pasagers}");
        }
    }
}
