using System;

public class CharacterFactory
{
    public Character CreateCharacter(string faction, string characterType, string name)
    {
        if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
        {
            throw new ArgumentException($"Invalid faction \"{faction}\"!");
        }

        Character character;
        switch (characterType)
        {
            case "Warrior":
                character = new Warrior(name, parsedFaction);
                break;
            case "Cleric":
                character = new Cleric(name, parsedFaction);
                break;
            default:
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
        }

        return character;
    }
}

