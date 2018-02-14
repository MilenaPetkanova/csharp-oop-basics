using System;
using System.Collections.Generic;
using System.Linq;

class TestClient
{
    static void Main()
    {
        var bankAccount = new BankAccount();
        var allIAccounts = new Dictionary<int, BankAccount>();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var commandArgs = command.Split(' ');
            int idCommand = int.Parse(commandArgs[1]);
            
            switch (commandArgs[0])
            {
                case "Create":
                    Create(allIAccounts, idCommand);
                    break;
                case "Deposit":
                    Deposit(allIAccounts, commandArgs, idCommand);
                    break;
                case "Withdraw":
                    Withdraw(allIAccounts, commandArgs, idCommand);
                    break;
                case "Print":
                    Print(allIAccounts, idCommand);
                    break;
                default:
                    break;
            }
        }
    }

    private static void Print(Dictionary<int, BankAccount> allIAccounts, int idCommand)
    {
        if (allIAccounts.ContainsKey(idCommand))
        {
            //var query = allIAccounts
            //    .Where(x => x.Key == idCommand)
            //    .First().Value;
            Console.WriteLine($"Account ID{allIAccounts[idCommand].Id}, balance {allIAccounts[idCommand].Balance:f2}");
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(Dictionary<int, BankAccount> allIAccounts, string[] commandArgs, int idCommand)
    {
        int amountCommand = int.Parse(commandArgs[2]);
        if (allIAccounts.ContainsKey(idCommand))
        {
            if (amountCommand > allIAccounts[idCommand].Balance)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                allIAccounts[idCommand].Withdraw(amountCommand);
            }
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Deposit(Dictionary<int, BankAccount> allIAccounts, string[] commandArgs, int idCommand)
    {
        int amountCommand = int.Parse(commandArgs[2]);
        if (allIAccounts.ContainsKey(idCommand))
        {
            allIAccounts[idCommand].Deposit(amountCommand);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Create(Dictionary<int, BankAccount> allIAccounts, int idCommand)
    {
        if (!allIAccounts.ContainsKey(idCommand))
        {
            var newAccont = new BankAccount();
            newAccont.Id = idCommand;
            allIAccounts.Add(idCommand, newAccont);
        }
        else
        {
            Console.WriteLine("Account already exists");
        }
    }
}
