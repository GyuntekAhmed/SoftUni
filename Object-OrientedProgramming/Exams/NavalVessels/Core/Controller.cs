namespace NavalVessels.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using Repositories;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            var captain = captains.Any(c => c.FullName == fullName);

            if (captain)
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            throw new NotImplementedException();
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            throw new NotImplementedException();
        }

        public string CaptainReport(string captainFullName)
        {
            throw new NotImplementedException();
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            throw new NotImplementedException();
        }

        public string ServiceVessel(string vesselName)
        {
            throw new NotImplementedException();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            throw new NotImplementedException();
        }

        public string VesselReport(string vesselName)
        {
            throw new NotImplementedException();
        }
    }
}
