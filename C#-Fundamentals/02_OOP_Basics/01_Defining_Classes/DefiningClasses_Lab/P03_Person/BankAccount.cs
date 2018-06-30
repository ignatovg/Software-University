using System;

public class BankAccount
{
    public int Id { get; set; }
    public decimal Balance { get; set; }

    public void Deposit(int amount)
    {
        Balance += amount;
    }

    public void Withdraw(int amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }

    public override string ToString()
    {
        return $"Account ID{Id}, balance {Balance:f2}";
    }
}