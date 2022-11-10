namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
            : base(name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override int Power => 100;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
