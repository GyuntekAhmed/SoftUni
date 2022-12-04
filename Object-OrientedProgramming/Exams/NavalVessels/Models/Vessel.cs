namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;

        protected Vessel
            (string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            Targets = new List<string>();      
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName, value));
                }

                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }

                captain = value;
            }
        }

        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get; private set; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }

            target.ArmorThickness -= MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            Targets.Add(target.Name);
            Captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string targetsOut = this.Targets.Any() ? String.Join(", ", this.Targets) : "None";

            sb.AppendLine($"- {this.Name}")
             .AppendLine($"*Type: {this.GetType().Name}")
             .AppendLine($"*Armor thickness: {ArmorThickness}")
             .AppendLine($"*Main weapon caliber: {MainWeaponCaliber}")
             .AppendLine($"*Speed: {Speed} knots")
             .AppendLine($"*Targets: {targetsOut}");

            return sb.ToString().TrimEnd();
        }
    }
}
