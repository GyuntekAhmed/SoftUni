using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length 
        { 
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Height
        {
            get { return height; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                } 

                height = value;
            }
        }

        public double Width
        {
            get { return width; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                width = value;
            }
        }

        public double SurfaceArea()
        {
            double result = 2 * (length * width) + 2 * (length * height) + 2 * (width * height);

            return result;
        }

        public double LateralSurfaceArea()
        {
            double result = 2 * (length * height) + 2 * (width * height);

            return result;
        }

        public double Volume()
        {
            double result = length * width * height;

            return result;
        }
    }
}
