using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string step = string.Empty;
            int allStep = 0;
            int totalStep = 0;

            while (step != "Going home")
            {
                step = Console.ReadLine();
                if (step != "Going home")
                {
                    allStep = int.Parse(step);
                    totalStep += allStep;
                    if (totalStep >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                }
                else
                {
                    step = Console.ReadLine();
                    allStep = int.Parse(step);
                    totalStep += allStep;
                    if (totalStep >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{10000 - totalStep} more steps to reach goal.");
                        break;
                    }

                }
            }
        }
    }
}
