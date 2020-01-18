using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry.Entities;

namespace Geometry
{
    static class Input
    {
        public static void AcceptInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            ControlPixel(GameMemory.light.source, key);
        }

        private static void ControlPixel(Pixel pixel, ConsoleKeyInfo key)
        {
            
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    pixel.x--;
                    break;
                case ConsoleKey.RightArrow:
                    pixel.x++;
                    break;
                case ConsoleKey.UpArrow:
                    pixel.y--;
                    break;
                case ConsoleKey.DownArrow:
                    pixel.y++;
                    break;
            }
        }
    }
}