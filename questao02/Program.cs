using System;
using OpenTK;

namespace questao02
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(600, 600);
            window.Run(1.0 / 60.0);
        }
    }
}
