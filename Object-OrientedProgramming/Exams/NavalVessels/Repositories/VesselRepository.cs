
namespace NavalVessels.Repositories
{
    using System;
    using System.Collections.Generic;
     
    using Models.Contracts;
    using Contracts;
    using System.Linq;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> vessels;

        public VesselRepository()
        {
            vessels = new HashSet<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models
            => (IReadOnlyCollection<IVessel>) vessels;

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public bool Remove(IVessel model)
        {
            return vessels.Remove(model);
        }

        public IVessel FindByName(string name)
        {
            return vessels.FirstOrDefault(v => v.Name == name);
        }
    }
}
