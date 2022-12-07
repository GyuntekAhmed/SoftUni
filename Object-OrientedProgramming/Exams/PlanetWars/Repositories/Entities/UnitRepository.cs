namespace PlanetWars.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;

        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => units;

        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return units.FirstOrDefault(m => m.GetType().Name == name);
        }

        public bool RemoveItem(string name)
            =>units.Remove(units.FirstOrDefault(m => m.GetType().Name == name));
    }
}
