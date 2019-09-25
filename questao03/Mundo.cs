using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using CG_Biblioteca;
using FormasBiblioteca;
using System.Collections.Generic;
using Color = OpenTK.Color;

namespace questao03
{

    public class Mundo : GameWindow
    {
        public static Mundo instance = null;

        public Mundo(int width, int height) : base(width, height) { }

        public static Mundo getInstance()
        {
            if (instance == null)
                instance = new Mundo(600, 600);
            return instance;
        }

        private Camera camera = new Camera();
        protected List<Objeto> objetosLista = new List<Objeto>();
        private bool moverPto = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // GerarLinhas();
            double raio = 100;

            var segmentoRetaA = new SegReta("A", new Ponto4D(0, 0, 0), new Ponto4D(200, 0, 0), Color.Red, 5);
            var segmentoRetaB = new SegReta("B", new Ponto4D(0, 0, 0), new Ponto4D(0, 200, 0), Color.Green, 5);
            var segmentoRetaC = new SegReta("C", new Ponto4D(-100, -100, 0), new Ponto4D(0, 100, 0), Color.Aqua, 5);
            var segmentoRetaD = new SegReta("D", new Ponto4D(0, 100, 0), new Ponto4D(100, -100, 0), Color.Aqua, 5);
            var segmentoRetaE = new SegReta("E", new Ponto4D(-100, -100, 0), new Ponto4D(100, -100, 0), Color.Aqua, 5);
            var circuloA = new Circulo("A", raio, Color.Black, 72, 0, 100, 5);
            var circuloB = new Circulo("B", raio, Color.Black, 72, 100, -100, 5);
            var circuloC = new Circulo("C", raio, Color.Black, 72, -100, -100, 5);

            objetosLista.Add(segmentoRetaA);
            objetosLista.Add(segmentoRetaB);
            objetosLista.Add(segmentoRetaC);
            objetosLista.Add(segmentoRetaD);
            objetosLista.Add(segmentoRetaE);
            objetosLista.Add(circuloA);
            objetosLista.Add(circuloB);
            objetosLista.Add(circuloC);
            GL.ClearColor(Color.Gray);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //GL.Ortho(camera.xmin, camera.xmax, camera.ymin, camera.ymax, camera.zmin, camera.zmax);
            GL.Ortho(-300, 300, -300, 300, -1, 1);

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            for (var i = 0; i < objetosLista.Count; i++)
            {
                objetosLista[i].Desenhar();
            }

            this.SwapBuffers();
        }

        protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Exit();
            else
            if (e.Key == Key.E)
            {
                for (var i = 0; i < objetosLista.Count; i++)
                {
                    objetosLista[i].PontosExibirObjeto();
                }
            }
            else
            if (e.Key == Key.M)
            {
                moverPto = !moverPto;
            }
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            if (moverPto)
            {
                //retanguloB.MoverPtoSupDir(new Ponto4D(e.Position.X, 600 - e.Position.Y, 0));
            }
        }
    }
}