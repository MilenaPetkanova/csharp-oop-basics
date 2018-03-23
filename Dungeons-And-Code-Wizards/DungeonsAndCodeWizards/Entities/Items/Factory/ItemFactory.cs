using System;

public class ItemFactory
{
    public Item CreateItem(string itemType)
    {
        Item item;
        switch (itemType)
        {
            case "ArmorRepairKit":
                item = new ArmorRepairKit();
                break;
            case "HealthPotion":
                item = new HealthPotion();
                break;
            case "PoisonPotion":
                item = new PoisonPotion();
                break;
            default:
                throw new ArgumentException($"Invalid item \"{itemType}\"!");
        }

        return item;
    }
}