using System.Collections.Generic;
using Geometry.Entities.PrimitiveObjects;

namespace Geometry.Entities.ComplexObjects
{
    class ComplexBody<T> where T: PrimitiveObject
    {
        public List<T> Parts { get; set; } // 1 part consists of 1 multipixel object which in turn consist of several pixels
        public ComplexBody()
        {
            Parts = new List<T>();
        }
    }
}
