using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));


            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int valueTask = int.Parse(Console.ReadLine());

            int task = 0;
            int thread = 0;
            while (true)
            {
                 task = tasks.Pop();
                 thread = threads.Dequeue();

                if (task == valueTask)
                {
                    break;
                }
                if (thread < task)
                {
                    tasks.Push(task);
                }
            }

            Console.WriteLine($"Thread with value {thread} killed task {valueTask}");

            if (threads.Count>0)
            {
                Console.WriteLine($"{thread}" +" " +string.Join(" ",threads));
            }
            else
            {
                Console.WriteLine(thread);
            } 
            
        }
    }
}
