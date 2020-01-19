using System;
using Geometry.Entities.PrimitiveObjects;

namespace Geometry.Entities.ComplexObjects
{
    class Obsticles : ComplexObject<PrimitiveObject>
    {
        public Obsticles(char shape, ConsoleColor color) : base(shape, color)
        {
        }

        public void Draw()
        {
            Body.Parts.ForEach(r => r.Draw());
        }
        
        public void Unlight()
        {
            Body.Parts.ForEach(part=>part.Body.Pixels.ForEach(pixel=>pixel.isLit=false));
        }
        
        public void AddLine(Pixel startPoint, Pixel endPoint)
        {
            Body.Parts.Add(new Line(startPoint, endPoint, Shape, Color));
        }
        
        public void AddCircle(Pixel center, double radius)
        {
            Body.Parts.Add(new Circle(center, radius, Shape, Color));
        }
    }
}