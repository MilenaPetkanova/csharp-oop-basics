using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int lapsNumber;
    private int currentLap;
    private int trackLength;
    private List<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;
    private Weather weather;

    public RaceTower()
    {
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
        this.weather = Weather.Sunny;
    }

    private enum Weather
    {
        Rainy, Foggy, Sunny
    }

    public bool IsRaceOver => this.currentLap == this.lapsNumber;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            racingDrivers.Add(DriverFactory.CreateDriver(commandArgs));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driverName = commandArgs[1];

        var driver = racingDrivers.First(d => d.Name == driverName);

        var methodArgs = commandArgs.Skip(2).ToList();

        if (reasonToBox.Equals("Refuel"))
        {
            driver.Refuel(methodArgs);
        }
        else if (reasonToBox.Equals("ChangeTyres"))
        {
            driver.ChangeTyres(methodArgs);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var sb = new StringBuilder();
        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > this.lapsNumber - this.currentLap)
        {
            try
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidLaps, this.currentLap));
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }

        for (int lap = 0; lap < numberOfLaps; lap++)
        {
            for (int i = 0; i < this.racingDrivers.Count; i++)
            {
                var driver = this.racingDrivers[i];

                try
                {
                    driver.CompleteLap(this.trackLength);
                }
                catch (ArgumentException ex)
                {
                    driver.Fail(ex.Message);
                    this.failedDrivers.Push(driver);
                    this.racingDrivers.RemoveAt(i);
                    i--;
                }
            }

            this.currentLap++;

            var orderedDrivers = this.racingDrivers
                .OrderByDescending(d => d.TotalTime)
                .ToList();

            for (int j = 0; j < orderedDrivers.Count - 1; j++)
            {
                var overtakingDriver = orderedDrivers[j];
                var targetDriver = orderedDrivers[j + 1];

                bool overtakeHappend = this.TryOvertake(overtakingDriver, targetDriver);

                if (overtakeHappend)
                {
                    j++;
                    sb.AppendLine(string.Format
                        (OutputMessages.OvertakeMessage, overtakingDriver.Name, targetDriver.Name, this.currentLap));
                }
                else
                {
                    if (!overtakingDriver.IsRacing)
                    {
                        this.failedDrivers.Push(overtakingDriver);
                        this.racingDrivers.Remove(overtakingDriver);
                    }
                }
            }
        }

        if (this.IsRaceOver)
        {
            var winner = this.racingDrivers.OrderBy(d => d.TotalTime).First();

            sb.AppendLine(
                string.Format(OutputMessages.WinnerMessage, winner.Name, winner.TotalTime));
        }

        return sb.ToString().TrimEnd();
    }

    private bool TryOvertake(Driver overtakingDriver, Driver targetDriver)
    {
        double timeDiff = overtakingDriver.TotalTime - targetDriver.TotalTime;

        if (timeDiff <= 3)
        {
            if (overtakingDriver is AggressiveDriver && overtakingDriver.Car.Tyre is UltrasoftTyre)
            {
                if (this.weather == Weather.Foggy)
                {
                    overtakingDriver.Fail(OutputMessages.Crashed);
                    return false;
                }
                overtakingDriver.TotalTime -= 3;
                targetDriver.TotalTime += 3;
                return true;
            }
            else if (overtakingDriver is EnduranceDriver && overtakingDriver.Car.Tyre is HardTyre)
            {
                if (this.weather == Weather.Rainy)
                {
                    overtakingDriver.Fail(OutputMessages.Crashed);
                    return false;
                }
                overtakingDriver.TotalTime -= 3;
                targetDriver.TotalTime += 3;
                return true;
            }
        }

        else if (timeDiff <= 2)
        {
            overtakingDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;
            return true;
        }

        return false;
    }

    public string GetLeaderboard()
    {
        var output = new StringBuilder();
        output.AppendLine($"Lap {this.currentLap}/{this.lapsNumber}");

        var leadedDrivers = this.racingDrivers
            .OrderBy(d => d.TotalTime)
            .Concat(this.failedDrivers);

        int positionNumber = 1;
        foreach (var driver in leadedDrivers)
        {
            output.AppendLine($"{positionNumber} {driver.ToString()}");
            positionNumber++;
        }

        return output.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var weatherType = commandArgs[0];

        Enum.TryParse(typeof(Weather), weatherType, out object weatherObj);
        Weather weather = (Weather)weatherObj;
        this.weather = weather;
    }

}
