using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry.Entities.PrimitiveObjects
{
    class Circle : PrimitiveObject
    {
        private Pixel centeral;
        private double radius;

        public Circle(Pixel centeral, double radius, char shape, ConsoleColor color) : base(shape, color)
        {
            this.centeral = centeral;
            this.radius = radius / 2;
            GenerateBody();
        }

        private void GenerateBody()
        {
            double y;
            for (double x = centeral.x - radius; x <= centeral.x + radius; x += 0.4)
            {
                y = (Math.Sqrt(Math.Pow(radius, 2) - Math.Pow((x - centeral.x), 2)) * 0.40 + centeral.y);
                Body.Pixels.Add(new Pixel(x, y, Shape, Color));
                y -= 2 * (y - centeral.y);
                Body.Pixels.Add(new Pixel(x, y, Shape, Color));
            }

            Optimize();
        }

        /// <summary>
        /// deletes all excessive pixels
        /// </summary>
        public void Optimize()
        {
            for (int i = Body.Pixels.Count-1; i >= 0; i--)
            {
                for (int j = Body.Pixels.Count-1; j >= 0; j--)
                {
                    if (Body.Pixels[i].Xgrid == Body.Pixels[j].Xgrid && Body.Pixels[i].Ygrid == Body.Pixels[j].Ygrid && Body.Pixels[i].id != Body.Pixels[j].id && Body.Pixels[j].tested ==false)
                    {
                        Body.Pixels.First(p=>p.id==Body.Pixels[j].id).excessive=true;
                    }
                    Body.Pixels.First(p=>p.id==Body.Pixels[i].id).tested=true;
                }
            }

            Body.Pixels.RemoveAll(p=>p.excessive);
        }

        // public void Optimize()
        // {
        //     foreach (Pixel pixelA in Body.Pixels)
        //     {
        //         foreach (var pixelB in Body.Pixels.Select((value, i) => new { i, value }))
        //         {
        //             if (pixelA?.Xgrid == pixelB?.value.Xgrid && pixelA?.Ygrid == pixelB?.value.Ygrid&&pixelA?.id!=pixelB?.value.id)
        //             {
        //                 Body.Pixels[pixelB.i].excessive=true;
        //             }
        //         }
        //     }
        //     foreach (var pixel in Body.Pixels.Select((value, i) => new { i, value }))
        //     {
        //         if (pixel.value.excessive)
        //         {
        //             Body.Pixels.RemoveAt(pixel.i);
        //         }
        //     }
        // }
    }
}