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
    static class Input
    {
        public static void AcceptInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            RotateObsticle(GameMemory.light.source, GameMemory.Obsticle, key);
            // ControlPixel(GameMemory.player, key);
            // ControlPixel(GameMemory.light.source, key);
            GameMemory.Obsticle.MoveAround(key);
        }

        
        // private static void RotatePixel(Pixel center, Pixel pixel, ConsoleKeyInfo key)
        // {
        //     switch (key.Key)
        //     {
        //         case ConsoleKey.LeftArrow:
        //             pixel.RotateAround(center, -20);
        //             break;
        //         case ConsoleKey.RightArrow:
        //             pixel.RotateAround(center, 20);
        //             break;
        //     }
        // }
        private static void RotateObsticle(Pixel center, Obsticles obsticle, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    obsticle.RotateAround(center, key, -10);
                    break;
                case ConsoleKey.RightArrow:
                    obsticle.RotateAround(center, key, 10);
                    break;
            }
        }
        // private static void MoveObsticle(Obsticles obsticle, ConsoleKeyInfo key)
        // {
        //     
        // }
    }
}