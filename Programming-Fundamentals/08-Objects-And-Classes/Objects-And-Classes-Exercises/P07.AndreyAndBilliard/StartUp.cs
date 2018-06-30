using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.AndreyAndBilliard
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int amointOfEntities=int.Parse(Console.ReadLine());

            Dictionary<string,decimal> shop=new Dictionary<string, decimal>();

            for (int i = 0; i <amointOfEntities ; i++)
            {
                string[] tokens = Console.ReadLine().Split('-');
                string name = tokens[0];
                decimal price = decimal.Parse(tokens[1]);

                if (!shop.ContainsKey(name))
                {
                    shop.Add(name,price);
                }
                else
                {
                    shop[name] = price;
                }
            }

            List<Custromer> custromers=new List<Custromer>();
            string input = Console.ReadLine();

            while (input!="end of clients")
            {
                string[] tokens = input.Split(new char[] {'-', ','},
                    StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string product = tokens[1];
                int quantity = int.Parse(tokens[2]);

                if (shop.ContainsKey(product))
                {
                    decimal[] priceArray = shop.Where(a => a.Key == product).Select(a => a.Value).ToArray();
                    
                   Custromer client=new Custromer();
                //var isAdded=custromers.Any(a=>a.Name==name);
                   
                        client.ShopList = new Dictionary<string, int>();
                        client.Name = name;
                        client.ShopList.Add(product, quantity);
                        client.Bill = priceArray[0] * quantity;
                  
                    custromers.Add(client);
                }
                input = Console.ReadLine();
            }

            foreach (var custromer in custromers.OrderBy(a=>a.Name))
            {
                Console.WriteLine($"{custromer.Name}");
                foreach (var item in custromer.ShopList)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine($"Bill: {custromer.Bill:f2}");
            }
            var  totalSum=custromers.Select(a=>a.Bill).Sum();
            Console.WriteLine($"Total bill: {totalSum:f2}");

        }
    }

    class Custromer
    {
        public string Name { get; set; }
        public Dictionary<string,int> ShopList { get; set; }
        public decimal Bill { get; set; }
    }
}
