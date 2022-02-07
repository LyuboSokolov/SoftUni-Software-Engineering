using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string result = string.Empty;

            result = RepeatString(input, n);
            Console.WriteLine(result);
        }
        static string RepeatString(string input, int n)
        {
            string result = string.Empty;
            for (int i = 0; i < n; i++)
            {
                result += input;
            }
            return result;
        }
    }
}
