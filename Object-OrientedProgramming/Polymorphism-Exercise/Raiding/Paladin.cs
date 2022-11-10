using System;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
            : base(name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override int Power => 100;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
