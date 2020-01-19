using System;
using Geometry.Entities.PrimitiveObjects;

namespace Geometry.Entities.ComplexObjects
{
    /// <summary>
    ///  defines complex objects which consist of multiple multipixel objects
    /// </summary>
    /// <typeparam name="T">Multipixel</typeparam>
    class ComplexObject<T> where T: PrimitiveObject
    {
        protected char Shape;
        protected ConsoleColor Color;
        public ComplexBody<T> Body { get; set; }

        public ComplexObject(char shape, ConsoleColor color)
        {
            Shape = shape;
            Color = color;
            Body = new ComplexBody<T>();
        }
    }
}