using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using CG_Biblioteca;

namespace questao02
{

    public class Mundo : GameWindow
    {
        public Mundo(int width, int height) : base(width, height) { }

        private double left = -300;
        private double right = 300;
        private double bottom = -300;
        private double top = 300;
        private double zoomIn = -1;
        private double zoomOut = 1;


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Gray);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(left, right, bottom, top, zoomIn, zoomOut);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GerarLinhas();
            GerarCirculo();
            this.SwapBuffers();
        }

        private void GerarCirculo()
        {
            var matematica = new Matematica();
            double raio = 100;

            GL.PointSize(4);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.Yellow);

            double angulo = 0;
            for (int i = 0; i < 72; i = i + 1)
            {
                var pontos = matematica.GerarPtosCirculo(angulo, raio);
                GL.Vertex2(pontos.X, pontos.Y);
                angulo += 5;
            }
            GL.End();
        }

        private void GerarLinhas()
        {
            GL.LineWidth(5);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex2(0, 0); GL.Vertex2(200, 0);
            GL.Color3(Color.Green);
            GL.Vertex2(0, 0); GL.Vertex2(0, 200);
            GL.End();
        }


        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Alt && e.Key == Key.F4)
            {
                Environment.Exit(0);
            }


            switch (e.Key)
            {
                case Key.E:
                case Key.A:
                    left += 5;
                    right += 5;
                    break;
                case Key.D:
                    left -= 5;
                    right -= 5;
                    break;
                case Key.C:
                case Key.W:
                    top -= 5;
                    bottom -= 5;
                    break;
                case Key.S:
                case Key.B:
                    top += 5;
                    bottom += 5;
                    break;
                case Key.Number1:
                case Key.I:
                    break;
                case Key.Number2:
                case Key.O:
                    break;
            }
        }



    }
}