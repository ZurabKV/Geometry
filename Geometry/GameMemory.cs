using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry.Entities;
using Geometry.Entities.ComplexObjects;
using Geometry.Entities.PrimitiveObjects;

namespace Geometry
{
    static class GameMemory
    {
        public static Walls PerimeterWall = new Walls(60, 20, 0, 0, '#', ConsoleColor.DarkCyan);

        public static Light light = new Light(new Pixel(25, 5, 'O', ConsoleColor.Cyan), '.', ConsoleColor.DarkYellow);
        
        public static Obsticles Obsticle = new Obsticles('D', ConsoleColor.Magenta);
        
        public static List<ComplexObject<PrimitiveObject>> visibleComplexObjectsList = new List<ComplexObject<PrimitiveObject>>();
        

        public static void Initialize()
        {
            // Obsticle.AddLine(new Pixel(40, 5, 'O', ConsoleColor.Cyan), new Pixel(40, 15, 'O', ConsoleColor.Cyan));
            // Obsticle.AddLine(new Pixel(14, 18, 'O', ConsoleColor.Cyan), new Pixel(30, 10, 'O', ConsoleColor.Cyan));
            Obsticle.AddCircle(new Pixel(30, 10, 'O', ConsoleColor.Cyan),30);
            // Obsticle.AddCircle(new Pixel(45, 10, 'O', ConsoleColor.Cyan),4);
            visibleComplexObjectsList.Add(Obsticle);
        }
    }
}