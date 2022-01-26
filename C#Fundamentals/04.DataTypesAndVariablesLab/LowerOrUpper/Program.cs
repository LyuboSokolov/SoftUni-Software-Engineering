using System;

namespace LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());

            if ((int)firstLetter >= 65 && (int)firstLetter <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
