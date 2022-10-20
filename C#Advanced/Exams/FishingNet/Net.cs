using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get => Fish.Count; }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) ||
                fish.Length <= 0 ||
                fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if (Fish.Count + 1 > Capacity)
            {
                return "Fishing net is full.";
            }
            Fish.Add(fish);

            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var fish = this.Fish.FirstOrDefault(e => e.Weight == weight);
            if (fish != null)
            {
                return this.Fish.Remove(fish);
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            var fishByType = Fish.FirstOrDefault(x => x.FishType == fishType);

            return fishByType;
        }

        public Fish GetBiggestFish()
        {
            var longestFish = this.Fish.Max(e => e.Length);
            var fish = this.Fish.FirstOrDefault(e => e.Length == longestFish);
            return fish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            foreach (var item in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
