﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Geometry
{
    static class Renderer
    {
        public static void Draw2D()
        {
            GameMemory.PerimeterWall?.Unlight();
            GameMemory.Obsticle?.Unlight();
            Console.Clear();
            
            GameMemory.light?.Cast();
            
            GameMemory.PerimeterWall?.Draw();
            GameMemory.Obsticle?.Draw();
            GameMemory.center?.Draw();
            // GameMemory.player.Draw();
        }
    }
}
