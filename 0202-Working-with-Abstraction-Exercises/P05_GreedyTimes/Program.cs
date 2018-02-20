using System;
using System.Collections.Generic;
using System.Linq;

public class GreedyTimes
{
    static void Main(string[] args)
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var bag = new Dictionary<string, Dictionary<string, long>>();
        long gold = 0;
        long gem = 0;
        long cash = 0;

        for (int i = 0; i < safe.Length; i += 2)
        {
            string item = safe[i];
            long amount = long.Parse(safe[i + 1]);

            string itemType = GetItemType(item);

            if (BagExceedRule(itemType, amount, bag, bagCapacity))
            {
                continue;
            }

            string itemToCompareWith;
            switch (itemType)
            {
                case "Gem":
                    itemToCompareWith = "Gold";
                    if (!SafisfyRules(itemType, amount, bag, itemToCompareWith))
                    {
                        continue;
                    }
                    break;
                case "Cash":
                    itemToCompareWith = "Gem";
                    if (!SafisfyRules(itemType, amount, bag, itemToCompareWith))
                    {
                        continue;
                    }
                    break;
            }

            AddItemInBag(bag, item, amount, itemType);

            IncreaseItemAmount(ref gold, ref gem, ref cash, amount, itemType);
        }

        PrintBagContainings(bag);
    }

    private static bool BagExceedRule(string itemType, long amount, Dictionary<string, Dictionary<string, long>> bag, long bagCapacity)
    {
        if (itemType == "")
        {
            return true;
        }
        else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
        {
            return true;
        }
        return false;
    }

    private static string GetItemType(string item)
    {
        string itemType = string.Empty;

        if (item.Length == 3)
        {
            itemType = "Cash";
        }
        else if (item.ToLower().EndsWith("gem"))
        {
            itemType = "Gem";
        }
        else if (item.ToLower() == "gold")
        {
            itemType = "Gold";
        }

        return itemType;
    }

    private static bool SafisfyRules(string itemType, long amount, Dictionary<string, Dictionary<string, long>> bag, string itemToCompareWith)
    {
        if (!bag.ContainsKey(itemType))
        {
            if (bag.ContainsKey(itemToCompareWith))
            {
                if (amount > bag[itemToCompareWith].Values.Sum())
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (bag[itemType].Values.Sum() + amount > bag["Gold"].Values.Sum())
        {
            return false;
        }
        return true;
    }

    private static void IncreaseItemAmount(ref long gold, ref long gem, ref long cash, long amount, string itemType)
    {
        if (itemType == "Gold")
        {
            gold += amount;
        }
        else if (itemType == "Gem")
        {
            gem += amount;
        }
        else if (itemType == "Cash")
        {
            cash += amount;
        }
    }

    private static void AddItemInBag(Dictionary<string, Dictionary<string, long>> bag, string item, long amount, string itemType)
    {
        if (!bag.ContainsKey(itemType))
        {
            bag[itemType] = new Dictionary<string, long>();
        }

        if (!bag[itemType].ContainsKey(item))
        {
            bag[itemType][item] = 0;
        }

        bag[itemType][item] += amount;
    }

    private static void PrintBagContainings(Dictionary<string, Dictionary<string, long>> bag)
    {
        foreach (var itemType in bag)
        {
            Console.WriteLine($"<{itemType.Key}> ${itemType.Value.Values.Sum()}");
            foreach (var item in itemType.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{item.Key} - {item.Value}");
            }
        }
    }
}
