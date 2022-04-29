using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width,int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public int Width { get; set; }

        public int Height { get; set; }
        public void Draw()
        {
            for (int row = 0; row < Width; row++)
            {
                for (int col = 0; col < Height; col++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

    }
}

