﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms.Entities
{
    public class BoxingGym : Gym
    {
        private const int capacity = 15;

        public BoxingGym(string name) : base(name, capacity)
        {
        }
    }
}
