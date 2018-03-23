using System;

internal class Cleric : Character, IHealable
{
    public Cleric(string name, Faction faction)
        : base(name, health: 50, armor: 25, abilityPoints: 40, bag: new Backpack(), faction: faction)
    {
    }

    public override double RestHealMultiplier => 0.5;

    public void Heal(Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        else if (base.Faction != character.Faction)
        {
            throw new InvalidOperationException("Cannot heal enemy character!");
        }
        else if (base.AbilityPoints <= 0)
        {
            throw new ArgumentException($"{this.Name} cannot heal!");
        }

        character.GetHealthIncreasement(this.AbilityPoints);
    }
}