using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry.Entities;
using Geometry.Entities.BodyParts;
using Geometry.Entities.ComplexObjects;
using Geometry.Entities.MultipixelObjects;

namespace Geometry
{
    static class GameMemory
    {
        public static Walls PerimeterWall = new Walls(60, 20, 0, 0, '#', ConsoleColor.DarkCyan);

        public static Light light = new Light(new Pixel(5, 5, 'O', ConsoleColor.Cyan), '.', ConsoleColor.DarkYellow);
        
        public static Obsticles Obsticle = new Obsticles('D', ConsoleColor.Magenta);
        
        public static List<IComplexObject<MultipixelObject>> visibleComplexObjectsList = new List<IComplexObject<MultipixelObject>>();
        

        public static void Initialize()
        {
            Obsticle.AddLine(new Pixel(40, 5, 'O', ConsoleColor.Cyan), new Pixel(40, 15, 'O', ConsoleColor.Cyan));
            visibleComplexObjectsList.Add(Obsticle);
        }
    }
}