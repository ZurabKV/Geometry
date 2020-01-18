using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Geometry.Entities.BodyParts;

namespace Geometry.Entities.MultipixelObjects
{
    class Line : MultipixelObject
    {
        public Line(Pixel startPoint, Pixel endPoint, char shape, ConsoleColor color) : base(shape, color)
        {
            AddStraightLine(startPoint, endPoint);
        }

        public override void Draw()
        {
            Body.Pixels.ToList().ForEach(p => p.Draw());
        }

        public void AddStraightLine(Pixel PointA, Pixel PointB)
        {
            float distX = PointB.x - PointA.x;
            float distY = PointB.y - PointA.y;

            float tg = distY / distX; // increment Y by this value for each X step

            float currentY = PointA.y;

            for (float x = PointA.x; x < PointB.x; x++)
            {
                Pixel currentPixel = new Pixel(x, currentY, Shape, Color);
                currentPixel.Draw();
                Body.Pixels.Add(currentPixel);
                currentY += tg;
            }
            Body.Pixels.Add(PointB);
        }
        
        public void AddFuncLine(Pixel PointA, Pixel PointB)
        {
            float distX = PointB.x - PointA.x;
            float distY = PointB.y - PointA.y;

            float tg = distY / distX; // increment Y by this value for each X step

            float currentY = PointA.y;

            for (float x = PointA.x; x < PointB.x; x++)
            {
                Pixel currentPixel = new Pixel(x, currentY, Shape, Color);
                currentPixel.Draw();
                Body.Pixels.Add(currentPixel);
                currentY += tg;
            }
            Body.Pixels.Add(PointB);
        }
    }
}