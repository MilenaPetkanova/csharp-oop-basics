using System;
using System.Linq;

public class Engine
{
    private PawIncMenager pawIncMenager;

    public Engine()
    {
        this.pawIncMenager = new PawIncMenager();
    }

    public void Run()
    {
        string inputLine = string.Empty;
        while ((inputLine = Console.ReadLine()) != "Paw Paw Pawah")
        {
            var args = inputLine.Split('|').Select(x => x.Trim()).ToArray();
            var command = args[0];
            switch (command)
            {
                case "RegisterCleansingCenter":
                    pawIncMenager.RegisterCleansingCenter(args[1]);
                    break;
                case "RegisterAdoptionCenter":
                    pawIncMenager.RegisterAdoptionCenter(args[1]);
                    break;
                case "RegisterDog":
                    pawIncMenager.RegisterDog(args[1], int.Parse(args[2]), int.Parse(args[3]), args[4]);
                    break;
                case "RegisterCat":
                    pawIncMenager.RegisterCat(args[1], int.Parse(args[2]), int.Parse(args[3]), args[4]);
                    break;
                case "SendForCleansing":
                    pawIncMenager.SendForCleansing(args[1], args[2]);
                    break;
                case "Cleanse":
                    pawIncMenager.Cleanse(args[1]);
                    break;
                case "Adopt":
                    pawIncMenager.Adopt(args[1]);
                    break;
            }
        }

        pawIncMenager.PrintOutput();
    }
}
