using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandLine = input.Split(' ').ToArray();
                string command = commandLine[0];
                int id = int.Parse(commandLine[1]);

                switch (command)
                {
                    case "Create":
                        if (!accounts.ContainsKey(id))
                        {
                            accounts.Add(id, new BankAccount{Id = id});
                        }
                        else
                        {
                            Console.WriteLine("Account already exists");
                        }
                        break;
                    case "Deposit":
                        int amount = int.Parse(commandLine[2]);
                        if (IsAccountExists(id, accounts))
                        {
                            accounts[id].Deposit(amount);
                        }
                        break;
                    case "Withdraw":
                         amount = int.Parse(commandLine[2]);
                        if (IsAccountExists(id, accounts))
                        {
                           accounts[id].Withdraw(amount); 
                        }
                        break;
                    case "Print":
                        if (IsAccountExists(id, accounts))
                        {
                            Console.WriteLine(accounts[id]);
                        }
                        break;
                }
            }

        }

        private static bool IsAccountExists(int id, Dictionary<int, BankAccount> accounts)
        {
            if (accounts.ContainsKey(id))
            {
                return true;
            }
            Console.WriteLine("Account does not exist");
            return false;
        }
    }
}
