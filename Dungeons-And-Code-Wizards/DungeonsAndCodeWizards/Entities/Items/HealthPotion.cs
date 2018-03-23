public class HealthPotion : Item
{
    private const int HitPoints = 20;

    public HealthPotion() 
        : base(weight: 5)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);
        character.GetHealthIncreasement(HitPoints);
    }
}

