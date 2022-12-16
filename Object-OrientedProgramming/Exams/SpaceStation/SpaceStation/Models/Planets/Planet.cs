namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using SpaceStation.Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;
        private List<IPlanet> items;

        public Planet(string name)
        {
            Name = name;
            items = new List<IPlanet>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidPlanetName));
                }

                name = value;
            }
        }

        public ICollection<string> Items => (ICollection<string>)items;
    }
}
