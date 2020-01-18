using System;
using Geometry.Entities.MultipixelObjects;

namespace Geometry.Entities.ComplexObjects
{
    class Light : IComplexObject<LightRay>
    {
        private char Shape;
        private ConsoleColor Color;
        
        public Pixel source { get; set; }

        public ComplexBody<LightRay> Body { get; set; }

        public Light(Pixel lightSource, char shape, ConsoleColor color)
        {
            Shape = shape;
            Color = color;
            Body = new ComplexBody<LightRay>();
            source = lightSource;
        }

        public void CastOn()
        {
            Body.Parts.Clear();
            GetBody();
            Body.Parts.ForEach(r => r.Draw());
            source.Draw();
        }

        private void GetBody()
        {
            foreach (Pixel wall in GameMemory.PerimeterWall.Body.Pixels)
            {
                LightRay ray = new LightRay(source, wall, Shape, Color);
                Body.Parts.Add(ray);
            }
        }
    }
}