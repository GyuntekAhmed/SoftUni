using System;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            : base(name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override int Power => 80;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
