using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string removeWord = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            while (text.Contains(removeWord) != false)
            {
                int index = text.IndexOf(removeWord);
                text = text.Remove(index, removeWord.Length);
            }

            Console.WriteLine(text);
        }
    }
}
