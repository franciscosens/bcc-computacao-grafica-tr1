﻿using System;
using OpenTK;

namespace questao03
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new Mundo(600, 600);
            window.Run(1.0 / 60.0);
        }
    }
}
