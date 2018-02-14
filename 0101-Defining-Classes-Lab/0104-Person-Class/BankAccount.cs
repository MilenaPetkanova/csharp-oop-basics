using System.Collections.Generic;

public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id { get; set; }
    public decimal Balance { get; set; }

    public void Create(int newId)
    {

    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.Id}, balance {this.Balance}";
    }
}
