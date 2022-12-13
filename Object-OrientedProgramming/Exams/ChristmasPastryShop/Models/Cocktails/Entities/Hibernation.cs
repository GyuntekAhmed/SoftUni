﻿namespace ChristmasPastryShop.Models.Cocktails.Entities
{
    public class Hibernation : Cocktail
    {
        private const double price = 10.50;

        public Hibernation(string cocktailName, string size) : base(cocktailName, size, price)
        {
        }
    }
}
