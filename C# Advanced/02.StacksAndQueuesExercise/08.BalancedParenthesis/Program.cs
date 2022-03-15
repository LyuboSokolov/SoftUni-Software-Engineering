using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<string> expressions = new Stack<string>();
            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    expressions.Push(input[i].ToString());
                }
                if (expressions.Count == 0)
                {
                    if (input[i] == '}' || input[i] == ']' || input[i] == ')')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else
                {
                    if (input[i] == '}' && expressions.Peek() == "{")
                    {
                        expressions.Pop();
                    }
                    else if (input[i] == ']' && expressions.Peek() == "[")
                    {
                        expressions.Pop();
                    }
                    else if (input[i] == ')' && expressions.Peek() == "(")
                    {
                        expressions.Pop();
                    }
                }
            }

            if (expressions.Count == 0 && isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
