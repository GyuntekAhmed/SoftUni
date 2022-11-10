namespace Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        string Name;
         public virtual int Power { get; private set; }

        public virtual string CastAbility()
        {
            return "";
        }
    }
}
