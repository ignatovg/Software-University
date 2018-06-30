using System;
using System.Collections.Generic;
using System.Text;


    public class BankAccount
    {
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (Balance < amount)
            {
                throw new ArgumentException("Insufficient funds");
            }
            Balance -= amount;
        }
    }

