using System;
using System.Collections.Generic;

namespace Geometry.Entities
{
    class Pixel
    {
        private static int counter=0;
        public int id;
        public double x;
        public double y;
        public char shape;
        public ConsoleColor color;
        public bool isLit = false;
        public bool excessive = false;
        public bool tested = false;

        public int Xgrid => (int) Math.Round(x);
        public int Ygrid => (int) Math.Round(y);


        public Pixel(double x, double y, char shape, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.shape = shape;
            id = counter;
            counter++;
        }

        public void Draw()
        {
            Console.SetCursorPosition(Xgrid, Ygrid);
            Console.ForegroundColor = color;
            Console.Write(shape);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RotateAround(Pixel otherPixel, double degrees)
        {
            double x_, y_;
            x_ = x * Math.Cos(degrees) - y * Math.Sin(degrees);
            y_ = y * Math.Cos(degrees) - x * Math.Sin(degrees);
            x = x_; y = y_;
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
    }
}