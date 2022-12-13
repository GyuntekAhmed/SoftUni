namespace ChristmasPastryShop.Models.Booths
{
    using System;
    using System.Text;

    using Contracts;
    using Cocktails.Contracts;
    using Delicacies.Contracts;
    using Utilities.Messages;
    using Repositories.Contracts;
    using Repositories;

    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> coctailMenu;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            delicacyMenu = new DelicacyRepository();
            coctailMenu = new CocktailRepository();
            CurrentBill = currentBill;
            Turnover = turnover;
            IsReserved = isReserved;
        }

        public int BoothId
        {
            get { return boothId; }
            private set { boothId = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }

                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => coctailMenu;

        public double CurrentBill
        {
            get { return currentBill; }
            private set { currentBill = value; }
        }

        public double Turnover
        {
            get { return turnover; }
            private set { turnover = value; }
        }

        public bool IsReserved
        {
            get { return isReserved; }
            private set
            {
                isReserved = value;
            }
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }
        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Booth: {BoothId}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Turnover: {Turnover:f2} lv")
                .AppendLine("-Cocktail menu:");

            foreach (var coctail in coctailMenu.Models)
            {
                sb.AppendLine($"--{coctail.ToString()}");
            }

            sb.AppendLine("-Delicacy menu:");

            foreach (var delicacy in delicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
