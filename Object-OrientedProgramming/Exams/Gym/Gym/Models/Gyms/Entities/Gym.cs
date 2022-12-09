using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes.Entities;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms.Entities
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidGymName));
                }
            }
        }

        public int Capacity { get; set; }

        public double EquipmentWeight => CalculateEquipmentWeight();

        public ICollection<IEquipment> Equipment => equipments;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count == Capacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughSize));
            }

            athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athletes.FirstOrDefault(a => a == athlete));
        }

        public void AddEquipment(IEquipment equipment)
        {
            equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {Athletes.GetType().Name}:");

            if (athletes.Count == 0)
            {
                sb.AppendLine("No athletes");
            }
            else
            {
                Queue<string> queue = new Queue<string>();

                foreach (var athlete in athletes)
                {
                    queue.Enqueue(athlete.FullName);
                }

                sb.AppendLine(string.Join(", ", queue));
            }

            sb.AppendLine($"Equipment total count: {equipments.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight} grams");

            return sb.ToString().Trim();
        }

        private double CalculateEquipmentWeight()
        {
            double sum = 0;

            foreach (var equipment in equipments)
            {
                sum += equipment.Weight;
            }

            return sum;
        }
    }
}
