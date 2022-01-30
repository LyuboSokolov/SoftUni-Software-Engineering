using System;

namespace DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string messeges = string.Empty;

            for (int i = 0; i < n; i++)
            {
                char input = char.Parse(Console.ReadLine());
                int inputToNumber = input + key;
                char numberToLetter = (char)inputToNumber;
                messeges += numberToLetter;
            }
            Console.WriteLine(messeges);
        }
    }
}
