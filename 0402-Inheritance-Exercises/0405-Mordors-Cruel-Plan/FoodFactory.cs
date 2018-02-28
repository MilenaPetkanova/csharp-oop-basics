public class FoodFactory
{
    public int CalculateHappiness(string[] foods)
    {
        int happiness = 0;
        foreach (var food in foods)
        {
            switch (food.ToLower())
            {
                case "cram":
                    happiness += new Cram().HappinessPoints;
                    break;
                case "lembas":
                    happiness += new Lembas().HappinessPoints;
                    break;
                case "apple":
                    happiness += new Apple().HappinessPoints;
                    break;
                case "melon":
                    happiness += new Melon().HappinessPoints;
                    break;
                case "honeycake":
                    happiness += new HoneyCake().HappinessPoints;
                    break;
                case "mushrooms":
                    happiness += new Mushrooms().HappinessPoints;
                    break;
                default:
                    int everythingElse = -1;
                    happiness += everythingElse;
                    break;
            }
        }
        return happiness;
    }
}
