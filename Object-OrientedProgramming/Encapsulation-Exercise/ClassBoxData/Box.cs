using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        //        •	Length - double, should not be zero or negative number
        //•	Width - double, should not be zero or negative number
        //•	Height - double, should not be zero or negative number
        public double Length 
        { 
            get { return this.Length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{this.Length} cannot be zero or negative.");
                }
            }
        }

    }
}
