using System;
using System.Collections.Generic;

namespace Geometry.Entities
{
    class Pixel
    {
        public float x;
        public float y;
        public char shape;
        public ConsoleColor color;
        public bool IsLit = false;

        public int Xgrid => (int) Math.Round(x);
        public int Ygrid => (int) Math.Round(y);


        public Pixel(float x, float y, char shape, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.shape = shape;
        }

        public void Draw()
        {
            Console.SetCursorPosition(Xgrid, Ygrid);
            Console.ForegroundColor = color;
            Console.Write(shape);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public List<Pixel> GetSurroundingCells()
        {
            return new List<Pixel>
            {
                new Pixel(x - 1, y - 1, ' ', ConsoleColor.White),
                new Pixel(x, y - 1, ' ', ConsoleColor.White),
                new Pixel(x + 1, y - 1, ' ', ConsoleColor.White),
                new Pixel(x - 1, y, ' ', ConsoleColor.White),
                new Pixel(x + 1, y, ' ', ConsoleColor.White),
                new Pixel(x - 1, y + 1, ' ', ConsoleColor.White),
                new Pixel(x, y + 1, ' ', ConsoleColor.White),
                new Pixel(x + 1, y + 1, ' ', ConsoleColor.White),
            };
        }
        
        public double DistanceToAnotherPixel(Pixel anotherPixel)
        {
            double distance = Math.Sqrt(Math.Pow(anotherPixel.x - x, 2) + Math.Pow(anotherPixel.y - y, 2));
            return distance;
        }
        
        public bool IsNotDiagonalToAnotherNearestPixel(Pixel anotherPixel)
        {
            var distanceToAnotherPixel = DistanceToAnotherPixel(anotherPixel);
            return DistanceToAnotherPixel(anotherPixel) == 1;
        }

        public void Move(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    x--;
                    break;
                case ConsoleKey.RightArrow:
                    x++;
                    break;
                case ConsoleKey.UpArrow:
                    y--;
                    break;
                case ConsoleKey.DownArrow:
                    y++;
                    break;
            }
        }
    }
}