using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] words = text.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> upperCaseWord = n=> n[0] == n.ToUpper()[0];

            words = words.Where(upperCaseWord).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,words));
        }
    }
}
