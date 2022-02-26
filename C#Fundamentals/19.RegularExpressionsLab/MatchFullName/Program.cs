using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            string patern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
            Regex regex = new Regex(patern);

            var matches = regex.Matches(names);

            Console.WriteLine($"{string.Join(' ', matches)}");
        }
    }
}
