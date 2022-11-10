namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name)
            : base(name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override int Power => 80;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
