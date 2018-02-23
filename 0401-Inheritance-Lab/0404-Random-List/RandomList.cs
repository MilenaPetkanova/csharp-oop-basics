using System.Collections.Generic;

public class RandomList : List<string>
{
    public List<string> StringList { get; set; }

    public RandomList(List<string> list)
    {
        this.StringList = list;
    }

    public string RandomString()
    {
        var rnd = new System.Random();
        int index = rnd.Next(this.StringList.Count);
        string randomString = this.StringList[index];
        this.StringList.RemoveAt(index);

        return randomString;
    }
}