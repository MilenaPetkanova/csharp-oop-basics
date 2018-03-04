using System;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private string corps;

    public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public string Corps
    {
        get => this.corps;
        private set
        {
            if (!value.Equals("Airforces") && !value.Equals("Marines"))
            {
                this.corps = null;
            }
            else
            {
                this.corps = value;
            }
        }
    }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine +  $"Corps: {this.corps}"; 
    }
}