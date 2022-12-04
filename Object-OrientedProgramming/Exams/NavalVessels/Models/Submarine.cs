namespace NavalVessels.Models
{
    using System;
    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double Initial_Armor_Thickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed, double armorThickness) : base(name, mainWeaponCaliber, speed, armorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (!SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }

            SubmergeMode = !SubmergeMode;
        }

        public override void RepairVessel()
        {
            ArmorThickness = Initial_Armor_Thickness;
        }

        public override string ToString()
        {
            string subModeOnOff = SubmergeMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $"*Submerge mode: {subModeOnOff}";
        }
    }
}
