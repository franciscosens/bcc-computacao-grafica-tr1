
using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using OpenTK.Input;
using CG_Biblioteca;
using Color = OpenTK.Color;
using FormasBiblioteca;

namespace questao06
{
    class Mundo : GameWindow
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
        //FIXME: estes objetos não devem ser atributos do Mundo

        Spline spline = new Spline();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var segmentoRetaA = new SegReta("A", new Ponto4D(0, 0, 0), new Ponto4D(200, 0, 0), Color.Red, 5);
            var segmentoRetaB = new SegReta("B", new Ponto4D(0, 0, 0), new Ponto4D(0, 200, 0), Color.Green, 5);

            objetosLista.Add(segmentoRetaA);
            objetosLista.Add(segmentoRetaB);
            GL.ClearColor(Color.Gray);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-400, 400, -400, 400, -1, 1);
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

            spline.Desenhar();

            this.SwapBuffers();
        }

        protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Exit();
            if ((e.Key == Key.Number1) || (e.Key == Key.Keypad1))
                this.spline.SelecionarPonto(0);
            if ((e.Key == Key.Number2) || (e.Key == Key.Keypad2))
                this.spline.SelecionarPonto(1);
            if ((e.Key == Key.Number3) || (e.Key == Key.Keypad3))
                this.spline.SelecionarPonto(2);
            if ((e.Key == Key.Number4) || (e.Key == Key.Keypad4))
                this.spline.SelecionarPonto(3);

            if ((e.Key == Key.C) || (e.Key == Key.B) || (e.Key == Key.E) || (e.Key == Key.D))
                this.spline.MoverPontoDeControle(e.Key);

            if ((e.Key == Key.Plus) || (e.Key == Key.KeypadPlus))
                this.spline.AumentarQtdePontos();
            if ((e.Key == Key.Minus) || (e.Key == Key.KeypadMinus))
                this.spline.DiminuirQtdePontos();

            if (e.Key == Key.R)
                this.spline.ReiniciarPontosDeControle();
        }
    }

}
