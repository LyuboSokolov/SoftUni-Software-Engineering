using System;
using System.Collections.Generic;

namespace CustomRandomList
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            RandomList list2 = new RandomList();
            Console.WriteLine(list2.RandomString());
            RandomList list = new RandomList();
            list.Add("Pesho");
            list.Add("Dimitrichko");
            list.Add("Gogi");


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list.RandomString());    
            }

        }
    }
}
