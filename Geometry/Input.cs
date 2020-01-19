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
                case ConsoleKey.A:
                    pixel.x--;
                    break;
                case ConsoleKey.D:
                    pixel.x++;
                    break;
                case ConsoleKey.W:
                    pixel.y--;
                    break;
                case ConsoleKey.S:
                    pixel.y++;
                    break;
            }
        }
    }
}