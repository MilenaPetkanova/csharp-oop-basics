﻿public class Citizen : IPerson
{
    private string name;
    private int age;

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public int Age { get; private set; }

    public string Name { get; private set; }
}