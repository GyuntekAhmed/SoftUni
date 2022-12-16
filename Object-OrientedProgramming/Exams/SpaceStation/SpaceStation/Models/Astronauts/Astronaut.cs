namespace SpaceStation.Models.Astronauts
{
    using System;

    using Contracts;
    using Bags.Contracts;
    using Utilities.Messages;
    using Bags;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private Backpack backpack;
        private bool canBreath;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            backpack = new Backpack();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidAstronautName, nameof(name)));
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOxygen));
                }

                oxygen = value;
            }
        }

        public bool CanBreath
        {
            get { return canBreath; }
            private set
            {
                if (Oxygen <= 0)
                {
                    value = false;
                }

                value = true;
            }
        }

        public IBag Bag => backpack;

        public virtual void Breath()
        {
            Oxygen -= 10;

            if (Oxygen <= 0)
            {
                Oxygen = 0;
            }
        }
    }
}
