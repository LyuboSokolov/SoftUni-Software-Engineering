using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> result = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string command = input.Substring(0, 1);

                if (command == "1")
                {
                    result.Push(text);
                    string insertText = input.Substring(2);
                    text += insertText;
                }
                else if (command == "2")
                {
                    result.Push(text);
                    text = text.Substring(0, text.Length - int.Parse(input.Substring(2)));
                }
                else if (command == "3")
                {
                    Console.WriteLine(text[int.Parse(input.Substring(2)) - 1]);
                }
                else if (command == "4")
                {
                    text = result.Pop();
                }
            }

        }
    }
}
