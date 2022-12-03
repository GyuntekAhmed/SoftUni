namespace Formula1.Models
{
    using System;
    using System.Text;

    using Contracts;
    using Utilities;

    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private bool canRace;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidPilot, value));
                }

                fullName = value;
            }
        }

        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }

        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException
                        (string.Format(ExceptionMessages.InvalidCarForPilot, value));
                }

                car = value;
            }
        }

        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }


        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Pilot {fullName} has {numberOfWins} wins.");

            return sb.ToString().TrimEnd();
        }
    }
}
