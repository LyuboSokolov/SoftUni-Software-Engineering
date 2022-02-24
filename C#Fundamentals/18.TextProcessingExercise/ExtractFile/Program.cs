using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split("\\", StringSplitOptions.RemoveEmptyEntries);

            string[] fileAndExtension = input[input.Length - 1].Split('.');

            string file = fileAndExtension[0];
            string extension = fileAndExtension[1];

            Console.WriteLine($"File name: {file}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
