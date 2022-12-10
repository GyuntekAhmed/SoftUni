namespace Gym.Core
{
    using System;
    using System.Collections.Generic;

    using Repositories;
    using Contracts;
    using Models.Gyms.Contracts;
    using Gym.Models.Gyms.Entities;
    using Gym.Utilities.Messages;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Equipment.Entities;

    public class Controller : IController
    {
        private EquipmentRepository equipments;
        private List<IGym> gyms;

        public Controller()
        {
            equipments = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if(gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidGymType));
            }

            gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;

            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidEquipmentType));
            }

            equipments.Add(equipment);

            return string.Format(OutputMessages.SuccessfullyAdded,equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            throw new NotImplementedException();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            throw new NotImplementedException();
        }

        public string EquipmentWeight(string gymName)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string TrainAthletes(string gymName)
        {
            throw new NotImplementedException();
        }
    }
}
