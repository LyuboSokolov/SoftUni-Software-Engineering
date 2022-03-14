using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSong = Console.ReadLine().Split(", ");

            Queue<string> songs = new Queue<string>(inputSong);

            while (songs.Count > 0)
            {
                string input = Console.ReadLine();

                if (input.Contains("Play"))
                {
                    songs.Dequeue();
                }
                else if (input.Contains("Add"))
                {
                    if (songs.Contains(input.Substring(4)))
                    {
                        Console.WriteLine($"{input.Substring(4)} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(input.Substring(4));
                    }
                }
                else if (input.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
