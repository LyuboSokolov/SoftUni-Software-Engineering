﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
   public class RandomList : List<string>
    {
        private Random random;
     

        public RandomList()
        {
            random = new Random();
        }
     
        public void Add(string element)
        {
            base.Add(element);
        }
        public string RandomString()
        {
            if (Count == 0)
            {
                return null;
            }

            return this[random.Next(0, this.Count)];
        }
    }
}
