using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry.Entities.BodyParts;

namespace Geometry.Entities.MultipixelObjects
{
    class Walls: MultipixelObject
    {
        private int SizeX;

        private int SizeY;

        private int StartingX;

        private int StartingY;

        public Walls(int sizeX, int sizeY, int startX, int startY, char shape = '#',
            ConsoleColor color = ConsoleColor.White) : base(shape, color)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            StartingX = startX;
            StartingY = startY;
            GenerateSquareBody();
        }
        
        public void Unlight()
        {
            Body.Pixels.ForEach(p=>p.IsLit=false);
        }

        protected void GenerateSquareBody()
        {
            int topBorder = StartingY + 1;
            int bottomBorder = StartingY + SizeY;
            int leftBorder = StartingX + 1;
            int RightBorder = StartingX + SizeX;
        
            for (int cursorY = topBorder; cursorY <= bottomBorder; cursorY++)
            {
                for (int cursorX = leftBorder; cursorX <= RightBorder; cursorX++)
                {
                    if (cursorY == topBorder || cursorY == bottomBorder || cursorX == leftBorder ||
                        cursorX == RightBorder) //checks if cursor is on first or last position
                    {
                        Body.Pixels.Add(new Pixel(cursorX - 1, cursorY - 1, Shape, ConsoleColor.White));
                    }
                }
            }
        }

        protected void GenerateCoordinateBody()
        {
            int topBorder = StartingY + 1;
            int bottomBorder = StartingY + SizeY;
            int leftBorder = StartingX + 1;
            int RightBorder = StartingX + SizeX;

            for (int cursorX = leftBorder; cursorX <= RightBorder; cursorX++)
            {
                Shape = (cursorX-1).ToString().Last();
                if (Shape == '0')
                {
                    Color += 1;
                }
                Pixel pixel = new Pixel(cursorX - 1, topBorder - 1, Shape, Color);
                Body.Pixels.Add(pixel);
            }
            for (int cursorY = topBorder; cursorY <= bottomBorder; cursorY++)
            {
                Shape = (cursorY).ToString().Last();
                if (Shape == '0')
                {
                    Color += 1;
                }
                Pixel pixel = new Pixel( leftBorder - 1, cursorY, Shape, Color);
                Body.Pixels.Add(pixel);
            }
        }
    }
}