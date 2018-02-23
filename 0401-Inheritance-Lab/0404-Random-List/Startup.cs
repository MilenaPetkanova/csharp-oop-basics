using System;
using System.Collections.Generic;

class Startup
{
    // test class RandomList

    static void Main()
    {
        var list = new List<string> { "a", "s", "d" };
        var randomList = new RandomList(list);
        Console.WriteLine(randomList.RandomString());
    }
}
