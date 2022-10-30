
using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string backingTehnique;
        private int weight;

        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 },
            {"crispi", 0.9 },
            {"chewy", 1.5 },
            {"homemade", 1.0 },
        };

        public Dough(string flourType, string backingTehnique, int weight)
        {
            FlourType = flourType;
            BackingTehnique = backingTehnique;
            Weight = weight;
        }


        public int Weight
        {
            get { return weight; }
            private set 
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BackingTehnique
        {
            get { return backingTehnique; }
            private set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                backingTehnique = value; 
            }
        }

        public double Calories
            => 2 * Weight 
            * modifiers[FlourType.ToLower()]
            * modifiers[BackingTehnique.ToLower()];

    }
}
