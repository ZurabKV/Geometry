using System;
using System.Linq;
using Geometry.Entities.MultipixelObjects;

namespace Geometry.Entities.BodyParts
{

    abstract class MultipixelObject
    {
        protected char Shape;
        protected ConsoleColor Color;

        public PixelBody Body;

        public MultipixelObject(char shape, ConsoleColor color)
        {
            Shape = shape;
            Color = color;
            Body = new PixelBody();
        }

        public virtual void Draw()
        {
            Body.Pixels.ToList().ForEach(p => p.Draw());
        }
    }
}
