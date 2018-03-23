using System;

public class Warrior : Character, IAttackable
{
    public Warrior(string name, Faction faction)
        : base(name, health: 100, armor: 50, abilityPoints: 40, bag: new Satchel(), faction: faction)
    {
    }

    public void Attack(Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        else if (this.Name == character.Name)
        {
            throw new InvalidOperationException("Cannot attack self!");
        }
        else if (base.Faction == character.Faction)
        {
            throw new ArgumentException($"Friendly fire! Both characters are from {character.Faction} faction!");
        }
        else if (this.AbilityPoints <= 0)
        {
            throw new ArgumentException($"{this.Name} cannot attack!");
        }

        character.TakeDamage(this.AbilityPoints);
    }
}