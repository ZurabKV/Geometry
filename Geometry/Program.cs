using System;
using System.Collections.Generic;

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
                Renderer.DrawScreen();
                Input.AcceptInput();
            }
        }
    }
}