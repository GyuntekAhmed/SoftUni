namespace PlanetWars.Models.MilitaryUnits.Entities
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            Cost = cost;
            enduranceLevel = 1;
        }

        public double Cost
        {
            get { return cost; }
            private set { cost = value; }
        }

        public int EnduranceLevel => enduranceLevel;

        public void IncreaseEndurance()
        {
            if (enduranceLevel == 20)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.EnduranceLevelExceeded));
            }

            enduranceLevel++;
        }
    }
}
