using System;
using Geometry.Entities.BodyParts;
using Geometry.Entities.MultipixelObjects;

namespace Geometry.Entities.ComplexObjects
{
    class Obsticles : IComplexObject<MultipixelObject>
    {
        private char Shape;
        private ConsoleColor Color;

        public ComplexBody<MultipixelObject> Body { get; set; }

        public Obsticles(char shape, ConsoleColor color)
        {
            Shape = shape;
            Color = color;
            Body = new ComplexBody<MultipixelObject>();
        }

        public void Draw()
        {
            Body.Parts.ForEach(r => r.Draw());
        }
        
        public void Unlight()
        {
            Body.Parts.ForEach(part=>part.Body.Pixels.ForEach(pixel=>pixel.IsLit=false));
        }
        
        public void AddLine(Pixel startPoint, Pixel endPoint)
        {
            Body.Parts.Add(new Line(startPoint, endPoint, Shape, Color));
        }
    }
}