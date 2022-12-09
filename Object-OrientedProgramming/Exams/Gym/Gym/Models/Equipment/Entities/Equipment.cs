﻿using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment.Entities
{
    public abstract class Equipment : IEquipment
    {
        protected Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }

        public double Weight { get; set; }

        public decimal Price { get; set; }
    }
}
