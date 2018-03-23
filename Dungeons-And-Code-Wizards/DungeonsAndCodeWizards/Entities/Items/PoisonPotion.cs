public class PoisonPotion : Item
{
    private const int HitPoints = 20;

    public PoisonPotion()
        : base(weight: 5)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);
        character.DecreaseHelth(HitPoints);
    }
}

