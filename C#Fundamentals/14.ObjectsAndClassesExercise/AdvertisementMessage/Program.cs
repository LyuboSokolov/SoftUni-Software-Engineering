using System;

namespace AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] phase = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] author = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] city = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                int indexPhase = rnd.Next(0, phase.Length);
                int indexEvents = rnd.Next(0, events.Length);
                int indexAutor = rnd.Next(0, author.Length);
                int indexCity = rnd.Next(0, city.Length);

                Console.WriteLine($"{phase[indexPhase]} {events[indexEvents]} {author[indexAutor]} – {city[indexCity]}.");
            }
        }
    }
}
