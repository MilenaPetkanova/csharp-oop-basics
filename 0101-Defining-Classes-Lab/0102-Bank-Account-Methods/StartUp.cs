using System;

class StartUp
{
    static void Main()
    {
        BankAccount ba = new BankAccount();

        ba.Deposit(100);
        ba.Withdraw(63);

        Console.WriteLine(ba);
    }
}
