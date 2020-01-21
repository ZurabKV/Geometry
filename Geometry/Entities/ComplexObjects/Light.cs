using System;
using Geometry.Entities.PrimitiveObjects;

namespace Geometry.Entities.ComplexObjects
{
    class Light : ComplexObject<LightRay>
    {
        public Pixel source { get; set; }

        public Light(Pixel lightSource, char shape, ConsoleColor color) : base(shape, color)
        {
            source = lightSource;
        }

        public void Cast()
        {
            Body.Parts.Clear();
            GetBody();
            // Body.Parts.ForEach(r => r.Draw());
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