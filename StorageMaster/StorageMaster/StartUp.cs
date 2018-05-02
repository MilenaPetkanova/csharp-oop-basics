namespace StorageMaster
{
    using System;
    using StorageMaster.Core;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var storageMaster = new StorageMaster();

            var inputLine = Console.ReadLine();
            while (!inputLine.Equals("END"))
            {
                var command = inputLine.Split().First();
                var args = inputLine.Split().Skip(1).ToArray();

                try
                {
                    var output = string.Empty;
                    switch (command)
                    {
                        case "AddProduct":
                            output = storageMaster.AddProduct(args[0], double.Parse(args[1]));
                            break;
                        case "RegisterStorage":
                            output = storageMaster.RegisterStorage(args[0], args[1]);
                            break;
                        case "SelectVehicle":
                            output = storageMaster.SelectVehicle(args[0], int.Parse(args[1]));
                            break;
                        case "LoadVehicle":
                            output = storageMaster.LoadVehicle(args);
                            break;
                        case "SendVehicleTo":
                            output = storageMaster.SendVehicleTo(args[0], int.Parse(args[1]), args[2]);
                            break;
                        case "UnloadVehicle":
                            output = storageMaster.UnloadVehicle(args[0], int.Parse(args[1]));
                            break;
                        case "GetStorageStatus":
                            output = storageMaster.GetStorageStatus(args[0]);
                            break;
                    }

                    Console.WriteLine(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}
