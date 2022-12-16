namespace SpaceStation.Core
{
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Astronauts;
    using Models.Astronauts.Contracts;
    using Models.Planets;
    using Repositories;
    using Models.Mission;
    using Utilities.Messages;

    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private ICollection<IAstronaut> astrToExplore;
        private int exploredPlanetsCount;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            astrToExplore = new List<IAstronaut>();
            exploredPlanetsCount = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                return string.Format(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);

            for (int i = 0; i < items.Length; i++)
            {
                planet.Items.Add(items[i]);
            }

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astrounaut = astronauts.FindByName(astronautName);

            if (astrounaut == null)
            {
                return string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName);
            }

            astronauts.Remove(astrounaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            int deadAstronautsCount = 0;

            var planet = planets.FindByName(planetName);
            Mission mission = new Mission();

            foreach (var astronaut in astronauts.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    astrToExplore.Add(astronaut);
                }
                if(astronaut.Oxygen == 0)
                {
                    deadAstronautsCount++;
                }
            }

            if (astrToExplore.Count == 0)
            {
                return string.Format(ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planet, astrToExplore);
            exploredPlanetsCount++;

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronautsCount);
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{exploredPlanetsCount} planets were explored!")
                .AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb
                    .AppendLine($"Name: {astronaut.Name}")
                    .AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count != 0)
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
                else
                {
                    sb.AppendLine("Bag items: none");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
