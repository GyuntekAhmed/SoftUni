namespace NavalVessels.Models
{
    using System;
    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double Initial_Armor_Thickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (!SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }

            SonarMode = !SonarMode;
        }

        public override void RepairVessel()
        {
            ArmorThickness = Initial_Armor_Thickness;
        }

        public override string ToString()
        {
            string sonarModeOnOff = SonarMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Sonar mode: {sonarModeOnOff}";
        }
    }
}
