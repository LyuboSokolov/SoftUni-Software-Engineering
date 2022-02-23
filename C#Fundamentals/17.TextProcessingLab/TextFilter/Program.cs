using System;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWord = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();
            string replaceWord = string.Empty;

            foreach (var word in bannedWord)
            {
                replaceWord = new string('*', word.Length);
                text = text.Replace(word, replaceWord);
            }

            Console.WriteLine(text);
        }
    }
}
