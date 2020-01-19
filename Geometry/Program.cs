using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false; //todo: move to config

            GameMemory.Initialize();
            
            while (true)
            {
                Renderer.Draw2D();
                Thread.Sleep(100);
                Console.WriteLine(GameMemory.Obsticle.Body.Parts.First().Body.Pixels.Count);
                Input.AcceptInput();
            }
        }
    }
}