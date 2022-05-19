using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private int initializeSize = 3;
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
        }

        public override int Size { get => initializeSize; }

        public override void Eat()
        {
            initializeSize += 3;
        }

        //Can only live in FreshwaterAquarium!


    }
}
