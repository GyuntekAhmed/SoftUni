using WildFarm.Models.Animals;

namespace WildFarm.Models.Interfaces
{
    public interface IFeline : IMammal
    {
        string Breed { get; }
    }
}