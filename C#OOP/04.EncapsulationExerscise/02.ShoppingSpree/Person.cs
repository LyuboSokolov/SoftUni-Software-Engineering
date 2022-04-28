using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProduct = new List<Product>();
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public double Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public List<Product> BagOfProduct { get; set; }

        public bool IsCanBuy(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Money -= product.Cost;
                BagOfProduct.Add(product);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            List<string> namesOfProducts = new List<string>();

            foreach (var item in BagOfProduct)
            {
                namesOfProducts.Add(item.Name);
            }
            if (BagOfProduct.Count > 0)
            {
                return $"{Name} - {string.Join(", ", namesOfProducts)}";
            }
            return $"{Name} - Nothing bought";
        }
    }

}
