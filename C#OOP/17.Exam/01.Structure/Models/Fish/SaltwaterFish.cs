using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private int initializeSize = 5;
        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
        }

        public override int Size { get => initializeSize; }

        public override void Eat()
        {
            initializeSize += 2;
        }

        //Can only live in SaltwaterAquarium!
    }
}
