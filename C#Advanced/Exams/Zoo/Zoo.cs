using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.Animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => Animals.Count;

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (Animals.Count == 0)
            {
                Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
            if (Animals.Capacity < Count)
            {
                return "The zoo is full.";
            }
            else
            {
                Animals.Add(animal);
            }
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;

            for (int i = 0; i < Animals.Count; i++)
            {
                var currentAnimal = Animals[i];

                if (currentAnimal.Species == species)
                {
                    Animals.Remove(currentAnimal);
                    count++;
                    i--;
                }
            }

            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsByDiet = new List<Animal>();

            foreach (var animal in Animals)
            {
                if (animal.Diet == diet)
                {
                    animalsByDiet.Add(animal);
                }
            }

            return animalsByDiet.ToList();
        }
        public Animal GetAnimalByWeight(double weight)
        {
            var animalByWeight = Animals.First(x => x.Weight == weight);

            return animalByWeight;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (var animal in Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
