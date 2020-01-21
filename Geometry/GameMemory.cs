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

        public static Light light = new Light(new Pixel(5, 5, 'O', ConsoleColor.Cyan), '.', ConsoleColor.DarkYellow);
        
        public static Obsticles Obsticle = new Obsticles('D', ConsoleColor.Magenta);
        
        // public  static  Pixel player = new Pixel(30, 10, '%', ConsoleColor.Blue);
        public  static  Pixel center = new Pixel(30, 10, '$', ConsoleColor.Yellow);
        
        public static List<ComplexObject<PrimitiveObject>> visibleComplexObjectsList = new List<ComplexObject<PrimitiveObject>>();
        

        public static void Initialize()
        {
            // Obsticle.AddLine(new Pixel(36, 7, 'O', ConsoleColor.Cyan), new Pixel(36, 12, 'O', ConsoleColor.Cyan));
            Obsticle.AddLine(new Pixel(25, 8, 'O', ConsoleColor.Cyan), new Pixel(25, 16, 'O', ConsoleColor.Cyan));
            // Obsticle.AddCircle(new Pixel(35, 10, 'O', ConsoleColor.Cyan), 6);
            // Obsticle.AddCircle(new Pixel(45, 10, 'O', ConsoleColor.Cyan),4);
            visibleComplexObjectsList.Add(Obsticle);
        }
    }
}