namespace SpaceStation.Models.Astronauts
{
    using System;

    using Contracts;
    using Bags.Contracts;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        //private List<IBag> bags;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            //bags = new List<IBag>();
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

        public bool CanBreath { get; private set; }

        public IBag Bag { get; set; }

        public virtual void Breath()
        {
            Oxygen -= 10;

            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
    }
}
