using Geometry.Entities.BodyParts;

namespace Geometry.Entities.ComplexObjects
{
    /// <summary>
    ///  defines complex objects which consist of multiple multipixel objects
    /// </summary>
    /// <typeparam name="T">Multipixel</typeparam>
    interface IComplexObject<T> where T: MultipixelObject
    {
        public ComplexBody<T> Body { get; set; }
    }
}