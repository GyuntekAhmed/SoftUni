using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Cocktails.Entities;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Models.Delicacies.Entities;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;

            Booth booth = new Booth(boothId, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth.DelicacyMenu.Models.Any(b => b.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy = null;

            switch (delicacyTypeName)
            {
                case "Gingerbread":
                    delicacy = new Gingerbread(delicacyName);
                    break;
                case "Stolen":
                    delicacy = new Stolen(delicacyName);
                    break;
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != "Hibernation" && cocktailTypeName != "MulledWine")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booth.CocktailMenu.Models.Any
                (b => b.Name == cocktailName && b.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail = null;

            switch (cocktailTypeName)
            {
                case "Hibernation":
                    cocktail = new Hibernation(cocktailName, size);
                    break;
                case "MulledWine":
                    cocktail = new MulledWine(cocktailName, size);
                    break;
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format
                (OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var boothsAvaliable = booths.Models
                .Where(b => !b.IsReserved && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .ToList();

            var availableBooth = boothsAvaliable.FirstOrDefault();

            if (availableBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            availableBooth.ChangeStatus();

            return string.Format
                (OutputMessages.BoothReservedSuccessfully, availableBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            string[] splittedOrder = order.Split("/", StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = splittedOrder[0];
            string itemName = splittedOrder[1];
            int piecesCount = int.Parse(splittedOrder[2]);

            string cockTailSize = string.Empty;

            if (splittedOrder.Length == 4)
                cockTailSize = splittedOrder[3];

            if (itemTypeName != "Gingerbread" && itemTypeName != "Stolen"
                && itemTypeName != "Hibernation" && itemTypeName != "MulledWine")
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (cockTailSize == string.Empty)
            {
                var delicacy = booth.DelicacyMenu.Models
                    .FirstOrDefault(d => d.Name == itemName);

                if (delicacy == null)
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
            }
            else
            {
                var cocktail = booth.CocktailMenu.Models
                    .FirstOrDefault(d => d.Name == itemName);

                if (cocktail == null)
                    return string.Format
                        (OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
            }

            if (cockTailSize == string.Empty)
            {
                var delicacy = booth.DelicacyMenu.Models
                    .FirstOrDefault(d => d.Name == itemName && d.GetType().Name == itemTypeName);

                if (delicacy == null)
                {
                    return string.Format
                        (OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                }

                double priceAmmount = delicacy.Price * piecesCount;
                booth.UpdateCurrentBill(priceAmmount);

                return string.Format
                    (OutputMessages.SuccessfullyOrdered, booth.BoothId, piecesCount, itemName);
            }
            else
            {
                var cocktail = booth.CocktailMenu.Models
                    .FirstOrDefault(d => d.Name == itemName
                    && d.GetType().Name == itemTypeName
                    && d.Size == cockTailSize);

                if (cocktail == null)
                {
                    return string.Format
                        (OutputMessages.CocktailStillNotAdded, cockTailSize, itemName);
                }

                double priceAmmount = cocktail.Price * piecesCount;
                booth.UpdateCurrentBill(priceAmmount);

                return string.Format
                    (OutputMessages.SuccessfullyOrdered, booth.BoothId, piecesCount, itemName);
            }
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            double currentBill = booth.CurrentBill;

            booth.Charge();
            booth.ChangeStatus();

            var sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().Trim();
        }

        public string BoothReport(int boothId)
        {
            var boothToReport = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return boothToReport.ToString();
        }
    }
}
