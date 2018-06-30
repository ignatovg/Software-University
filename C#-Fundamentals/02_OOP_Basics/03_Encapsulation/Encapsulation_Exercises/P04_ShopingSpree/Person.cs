using System;
using System.Collections.Generic;
using System.Text;

namespace P04_ShopingSpree
{
    class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        private decimal money;

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }


        public List<Product> Products { get; set; }

        public Person()
        {
            Products = new List<Product>();
        }

        public Person(string name, decimal money, List<Product> products):this()
        {
            this.Name = name;
            this.Money = money;
            this.Products = products;
        }

        public Person ParsePerson(string token)
        {
            string[] tokens = token.Split('=',StringSplitOptions.RemoveEmptyEntries);
            this.Name = tokens[0];
            this.Money = decimal.Parse(tokens[1]);

            return this;
        }

        public override string ToString()
        {
            if (Products.Count != 0)
            {
                return $"{this.Name} - {string.Join(", ", this.Products)}";
            }

            return $"{this.Name} - Nothing bought";
        }
    }
}
