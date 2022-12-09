using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes.Entities
{
    public class Boxer : Athlete
    {
        private const int stamina = 60;
        private int increasesStamina = 15;
        
        public Boxer(string fullName, string motivation, int numberOfMedals)
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
