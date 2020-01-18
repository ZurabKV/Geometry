using System.Collections.Generic;
using Geometry.Entities.BodyParts;
using Geometry.Entities.MultipixelObjects;

namespace Geometry.Entities.ComplexObjects
{
    class ComplexBody<T> where T: MultipixelObject
    {
        public List<T> Parts { get; set; } // 1 part consists of 1 multipixel object which in turn consist of several pixels
        public ComplexBody()
        {
            Parts = new List<T>();
        }
    }
}
