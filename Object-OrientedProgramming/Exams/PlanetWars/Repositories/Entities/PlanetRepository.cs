namespace PlanetWars.Repositories.Entities
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => planets;

        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return planets.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        => planets.Remove(planets.FirstOrDefault(x => x.Name == name));
    }
}
