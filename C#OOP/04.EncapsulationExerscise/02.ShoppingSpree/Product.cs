using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;

        private double cost;

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
        public string Name { get; set; }


        public double Cost
        {
            get => cost;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }

    }

}

