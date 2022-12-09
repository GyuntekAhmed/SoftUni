using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes.Entities
{
    public class Weightlifter : Athlete
    {
        private const int stamina = 50;
        private int increasesStamina = 10;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, stamina)
        {
        }

        public override void Exercise()
        {
            Stamina += increasesStamina;

            if (Stamina > 100)
            {
                Stamina = 100;

                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStamina));
            }
        }
    }
}
