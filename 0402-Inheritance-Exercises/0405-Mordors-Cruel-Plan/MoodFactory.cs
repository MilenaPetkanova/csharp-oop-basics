public class MoodFactory
{
    public string GenerateMood(int happiness)
    {
        if (happiness < -5)
        {
            return new Angry().CurrentMood;
        }
        else if (happiness >= -5 && happiness <= 0)
        {
            return new Sad().CurrentMood;
        }
        else if (happiness >= 1 && happiness <= 15)
        {
            return new Happy().CurrentMood;
        }
        else
        {
            return new JavaScript().CurrentMood;
        }
    }
}