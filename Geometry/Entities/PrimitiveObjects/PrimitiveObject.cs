﻿using System;
using System.Linq;

namespace Geometry.Entities.PrimitiveObjects
{

    abstract class PrimitiveObject
    {
        protected char Shape;
        protected ConsoleColor Color;

        public PixelBody Body;

        public PrimitiveObject(char shape, ConsoleColor color)
        {
            Shape = shape;
            Color = color;
            Body = new PixelBody();
        }

        public virtual void Draw()
        {
            Body.Pixels.Where(p=>p.isLit==true).ToList().ForEach(p => p.Draw());
        }

        public void RotateAround(Pixel center, double degrees)
        {
            Body.Pixels.ForEach(p=>p.RotateAround(center, degrees));
        }
        
        public void MoveAround(ConsoleKeyInfo key)
        {
            Body.Pixels.ForEach(p=>p.MovePixel(key));
        }
    }
}
