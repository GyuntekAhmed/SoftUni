namespace NavalVessels.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;
    using Models;
    using Utilities.Messages;
    using Repositories;
    using Repositories.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<IVessel> vessels;
        private readonly ICollection<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new HashSet<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            captains.Add(captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel
            (string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            var existVessel = vessels.FindByName(name);

            if (existVessel != null)
            {
                return string.Format
                    (OutputMessages.VesselIsAlreadyManufactured, existVessel.GetType().Name, name);
            }

            IVessel produceVessel;

            if (vesselType == "Submarine")
            {
                produceVessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                produceVessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }

            vessels.Add(produceVessel);

            return
                string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);

            return string.Format
                (OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.First(c => c.FullName == captainFullName);

            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType() == typeof(Battleship))
            {
                Battleship battleship = (Battleship)vessel;

                battleship.ToggleSonarMode();

                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                Submarine submarine = (Submarine)vessel;

                submarine.ToggleSubmergeMode();

                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = vessels.FindByName(attackingVesselName);

            if (attackingVessel == null)
            {
                string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            IVessel defendingVessel = vessels.FindByName(defendingVesselName);

            if (defendingVessel == null)
            {
                string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (defendingVessel.ArmorThickness == 0)
            {
                string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(defendingVessel);

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }
    }
}
