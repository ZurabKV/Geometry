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
        public static void DrawScreen()
        {
            GameMemory.PerimeterWall.Draw();
        }
    }
}
