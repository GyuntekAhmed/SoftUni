﻿namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;

    using Astronauts.Contracts;
    using Contracts;
    using Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.Oxygen != 0)
                {
                    foreach (var item in planet.Items)
                    {
                        astronaut.Breath();
                        astronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);

                        if (astronaut.Oxygen == 0)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
