using System.Collections.Generic;

namespace Geometry.Entities.PrimitiveObjects
{
    class PixelBody
    {
        public List<Pixel> Pixels { get; set; }
        public PixelBody()
        {
            Pixels = new List<Pixel>();
        }
        //public void Add(Pixel pixel)
        //{
        //    Pixels.Add();
        //}
    }
}
