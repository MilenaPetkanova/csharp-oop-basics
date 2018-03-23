using System;

public abstract class Character
{
    private string name;
    private double health;
    private double armor;

    public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;

        this.BaseHealth = health;
        this.Health = health;

        this.BaseArmor = armor;
        this.Armor = armor;

        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.Faction = faction;

        this.IsAlive = true;
        this.RestHealMultiplier = 0.2;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }
            this.name = value;
        }
    }

    public double BaseHealth { get; }

    public double Health
    {
        get => this.health;
        private set
        {
            if (value <= 0)
            {
                this.health = 0;
                this.IsAlive = false;
            }
            else if (value >= this.BaseHealth)
            {
                this.health = this.BaseHealth;
            }
            else
            {
                this.health = value;
            }
        }
    }

    public double BaseArmor { get; private set; }

    public double Armor
    {
        get => this.armor;
        private set
        {
            if (value >= this.BaseArmor)
            {
                this.armor = this.BaseArmor;
            }
            else
            {
                this.armor = value;
            }
        }
    }

    public double AbilityPoints { get; protected set; }

    public Bag Bag { get; }

    public Faction Faction { get; }

    public bool IsAlive { get; private set; }

    public virtual double RestHealMultiplier { get; protected set; }

    public void GetHealthIncreasement(double points)
    {
        this.Health += points;
    }

    public void DecreaseHelth(double points)
    {
        this.Health -= points;
    }

    public void GetArmorReapired()
    {
        this.Armor = this.BaseArmor;
    }

    public void TakeDamage(double hitPoints)
    {
        this.Armor -= hitPoints;
        if (this.Armor < 0)
        {
            hitPoints = Math.Abs(this.Armor);
            this.Armor = 0;
            this.Health -= hitPoints;
        }
    }

    public void Rest()
    {
        var increasement = this.BaseHealth * this.RestHealMultiplier;
        this.Health += increasement;
    }

    public void UseItem(Item item)
    {
        item.AffectCharacter(this);
    }

    public void UseItemOn(Item item, Character character)
    {
        item.AffectCharacter(character);
    }

    public void GiveCharacterItem(Item item, Character character)
    {
        character.ReceiveItem(item);
    }

    public void ReceiveItem(Item item)
    {
        this.Bag.AddItem(item);
    }

    public override string ToString()
    {
        string status = this.IsAlive ? "Alive" : "Dead";

        return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, " +
            $"AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
    }
}