﻿using System;
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
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public void SurfaceArea()
        {
            double surfaceArea = 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;

            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        }

        public void LateralSurfaceArea() 
        {
            double lateralSurfaceArea = 2 * Length * Height + 2 * Width * Height;

            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
        }

        public void Volume()
        {
            double volume = Length * Width * Height;

            Console.WriteLine($"Volume - {volume:f2}");
        }
    }
}
