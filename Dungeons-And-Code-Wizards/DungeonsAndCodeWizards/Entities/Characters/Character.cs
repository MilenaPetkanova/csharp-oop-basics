using System;

public abstract class Character
{
    private string name;
    private double health;
    private double armor;
    private double baseArmor;
    private double baseHealth;
    private double abilityPoints;

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

    public double BaseHealth
    {
        get
        {
            return this.baseHealth;
        }
        private set
        {
            this.baseHealth = value;
        }
    }

    public double Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = Math.Min(value, this.BaseHealth);
        }
    }

    public double BaseArmor
    {
        get
        {
            return this.baseArmor;
        }
        private set
        {
            this.baseArmor = value;
        }
    }

    public double Armor
    {
        get
        {
            return this.armor;
        }
        set
        {
            this.armor = Math.Min(value, this.BaseArmor);
        }
    }

    public double AbilityPoints
    {
        get
        {
            return abilityPoints;
        }
        private set
        {
            this.abilityPoints = value;
        }
    }

    public Bag Bag { get; }

    public Faction Faction { get; }

    public bool IsAlive { get; private set; }

    public virtual double RestHealMultiplier => 0.2;

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
        this.EnsureAlive();

        var hitpointsLeftAfterArmorDamage = Math.Max(0, hitPoints - this.Armor);
        this.Armor = Math.Max(0, this.Armor - hitPoints);
        this.Health = Math.Max(0, this.Health - hitpointsLeftAfterArmorDamage);

        if (this.Health == 0)
        {
            this.IsAlive = false;
        }
    }

    public void Rest()
    {
        EnsureAlive();

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

    protected void EnsureAlive()
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }

    public override string ToString()
    {
        string status = this.IsAlive ? "Alive" : "Dead";

        return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, " +
            $"AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
    }
}