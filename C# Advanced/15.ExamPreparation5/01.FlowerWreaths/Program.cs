using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int wreaths = 0;
            int storedFlowers = 0;
            while (lilies.Count != 0 && roses.Count != 0)
            {
                int currLilies = lilies.Peek();
                int currRoses = roses.Peek();
                if (currLilies + currRoses == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (currLilies + currRoses > 15 && currLilies > 0)
                {
                    while (currLilies > 0)
                    {
                        currLilies -= 2;
                        if (currLilies + currRoses == 15)
                        {
                            wreaths++;
                            lilies.Pop();
                            roses.Dequeue();
                            break;

                        }
                        else if (currLilies + currRoses < 15)
                        {
                            storedFlowers += currLilies + currRoses;
                            lilies.Pop();
                            roses.Dequeue();
                            break;
                        }
                    }
                }
                else
                {
                    storedFlowers += lilies.Pop() + roses.Dequeue();
                }
            }

            if (storedFlowers > 0)
            {
                wreaths += storedFlowers / 15;
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
