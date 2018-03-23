using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private List<Character> party;
    private List<Item> pool;
    private CharacterFactory characterFactory;
    private ItemFactory itemFactory;
    int lastSurviviorRounds;

    public DungeonMaster()
    {
        this.party = new List<Character>();
        this.pool = new List<Item>();
        this.characterFactory = new CharacterFactory();
        this.itemFactory = new ItemFactory();
        this.lastSurviviorRounds = 0;
    }

    public string JoinParty(string[] args)
    {
        var faction = args[0];
        var characterType = args[1];
        var name = args[2];

        var character = characterFactory.CreateCharacter(faction, characterType, name);
        this.party.Add(character);

        return $"{character.Name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        var item = itemFactory.CreateItem(args[0]);
        pool.Add(item);

        return $"{item.GetType()} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        var character = CheckIfCharacterExists(args[0]);

        if (this.pool.Count == 0)
        {
            throw new InvalidOperationException("No items left in pool!");
        }

        var lastItem = pool.Last();

        character.ReceiveItem(lastItem);

        pool.Remove(lastItem);

        return $"{character.Name} picked up {lastItem.GetType().Name}!";
    }

    public string UseItem(string[] args)
    {
        var character = CheckIfCharacterExists(args[0]);
        var item = character.Bag.GetItem(args[1]);

        character.UseItem(item);

        return $"{character.Name} used {item.GetType().Name}.";
    }

    public string UseItemOn(string[] args)
    {
        var giver = CheckIfCharacterExists(args[0]);
        var receiver = CheckIfCharacterExists(args[1]);
        var item = giver.Bag.GetItem(args[2]);

        giver.UseItemOn(item, receiver);

        return $"{giver.Name} used {item.GetType().Name} on {receiver.Name}.";
    }

    public string GiveCharacterItem(string[] args)
    {
        var giver = CheckIfCharacterExists(args[0]);
        var receiver = CheckIfCharacterExists(args[1]);
        var item = giver.Bag.GetItem(args[2]);

        giver.GiveCharacterItem(item, receiver);

        return $"{giver.Name} gave {receiver.Name} {item.GetType()}.";
    }

    public string GetStats()
    {
        var orderedCharacters = this.party
            .OrderByDescending(p => p.IsAlive)
            .ThenByDescending(p => p.Health);

        var output = string.Join(Environment.NewLine, orderedCharacters);
        return output;
    }

    public string Attack(string[] args)
    {
        var attacker = CheckIfCharacterExists(args[0]);
        var receiver = CheckIfCharacterExists(args[1]);
        
        if (!(attacker is IAttackable attackingCharacter))
        {
            throw new ArgumentException($"{attacker.Name} cannot attack!");
        }

        attackingCharacter.Attack(receiver);

        var output = $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! " +
            $"{receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP " +
            $"and {receiver.Armor}/{receiver.BaseArmor} AP left!";

        if (!receiver.IsAlive)
        {
            output += Environment.NewLine + $"{receiver.Name} is dead!";
        }

        return output;
    }

    public string Heal(string[] args)
    {
        var healer = CheckIfCharacterExists(args[0]);
        var receiver = CheckIfCharacterExists(args[1]);

        if (!(healer is IHealable healingCharacter))
        {
            throw new ArgumentException($"{healer.Name} cannot heal!");
        }

        healingCharacter.Heal(receiver);

        return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! " +
            $"{receiver.Name} has {receiver.Health} health now!";
    }

    public string EndTurn(string[] args)
    {
        var aliveCharacters = party.Where(ch => ch.IsAlive).ToList();

        var output = new StringBuilder();

        if (aliveCharacters.Count <= 1)
        {
            this.lastSurviviorRounds++;
        }

        foreach (var character in aliveCharacters)
        {
            var healthBefore = character.Health;
            character.Rest();
            output.AppendLine($"{character.Name} rests ({healthBefore} => {character.Health})");
        }

        return output.ToString().TrimEnd();
    }

    public bool IsGameOver()
    {
        var oneOrZeroSurvivorsLeft = this.party.Count(c => c.IsAlive) <= 1;
        var lastSurviverSurvivedTooLong = this.lastSurviviorRounds > 1;

        return oneOrZeroSurvivorsLeft && lastSurviverSurvivedTooLong;
    }

    private Character CheckIfCharacterExists(string characterName)
    {
        var character = party.FirstOrDefault(x => x.Name == characterName);

        if (character == null)
        {
            throw new ArgumentException($"Character {characterName} not found!");
        }

        return character;
    }

}
