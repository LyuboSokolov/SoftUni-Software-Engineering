using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bear bear = new Bear("Gogi");
            Reptile reptile = new Reptile("anti konti");

            bear.Name = "choci";
            Console.WriteLine(bear.Name);
        }
    }
}