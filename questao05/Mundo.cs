using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using CG_Biblioteca;
using FormasBiblioteca;
using System.Collections.Generic;
using Color = OpenTK.Color;

namespace questao05
{

    public class Mundo : GameWindow
    {
        private SegReta _segReta;
        public const double Distancia = 5, DistanciaAngulo = 1;
        public static Mundo instance = null;

        private Matematica matematica;
        private double raio = 100;
        private int angulo = 45;

        public Mundo(int width, int height) : base(width, height)
        {
            matematica = new Matematica();
        }

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

            var segmentoRetaA = new SegReta("A", new Ponto4D(0, 0, 0), new Ponto4D(200, 0, 0), Color.Red, 5);
            var segmentoRetaB = new SegReta("B", new Ponto4D(0, 0, 0), new Ponto4D(0, 200, 0), Color.Green, 5);
            _segReta = new SegReta("C", new Ponto4D(0, 0, 0), Color.Black, 5, angulo);

            objetosLista.Add(segmentoRetaA);
            objetosLista.Add(segmentoRetaB);
            objetosLista.Add(_segReta);
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


        protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Exit();
            else
            if (e.Key == Key.W || e.Key == Key.Q || e.Key == Key.Z || e.Key == Key.X || e.Key == Key.A || e.Key == Key.S)
            {
                for (var i = 0; i < objetosLista.Count; i++)
                {
                    if (objetosLista[i] is SegReta)
                    {
                        var reta = (SegReta)objetosLista[i];
                        if (reta.GetRotulo() == "C")
                        {
                            switch (e.Key)
                            {
                                case Key.Q:
                                    // AlterarPosicao(Distancia * -1, ref reta);
                                    _segReta.Retornar();
                                    break;
                                case Key.W:
                                    // AlterarPosicao(Distancia, ref reta);
                                    _segReta.Avancar();
                                    break;
                                case Key.Z:
                                    // AlterarZoom(Distancia * -1, ref reta);
                                    _segReta.Diminuir();
                                    break;
                                case Key.X:
                                    // AlterarZoom(Distancia, ref reta);
                                    _segReta.Aumentar();
                                    break;
                                case Key.A:
                                    // Rotacionar(DistanciaAngulo * -1, ref reta);
                                    _segReta.DecrementarAngulo();
                                    break;
                                case Key.S:
                                    // Rotacionar(DistanciaAngulo, ref reta);
                                    _segReta.IncrementarAngulo();
                                    break;
                            }
                        }
                    }
                    //objetosLista[i].PontosExibirObjeto();
                }
            }
            else
            if (e.Key == Key.M)
            {
                moverPto = !moverPto;
            }
        }

        // private void Rotacionar(double adicional, ref SegReta reta)
        // {
        //     System.Console.WriteLine(angulo);
        //     if (angulo + adicional >= 360)
        //     {
        //         angulo = 0;
        //     }
        //     else if (angulo + adicional <= 0)
        //     {
        //         angulo = 360;
        //     }
        //     else
        //     {
        //         angulo += adicional;
        //     }


        //     var pontoNovo = matematica.GerarPtosCirculo(angulo, raio); ;
        //     reta.DefinirPonto(reta.ponto, pontoNovo);
        //     // reta.ponto2.X = pontoNovo.X;
        //     // reta.ponto2.Y = pontoNovo.Y;
        // }

        // private void AlterarPosicao(double adicional, ref SegReta reta)
        // {
        //     // reta.ponto.X = reta.ponto.X + adicional;
        //     // reta.ponto2.X = reta.ponto2.X + adicional;
        //     var ponto1 = reta.ponto;
        //     ponto1.X = ponto1.X + adicional;
        //     var ponto2 = reta.ponto2;
        //     ponto2.X = ponto2.X + adicional;
        //     reta.DefinirPonto(ponto1, ponto2);
        // }

        // private void AlterarZoom(double adicional, ref SegReta reta)
        // {

        //     raio += adicional;
        //     var pontoNovo = matematica.GerarPtosCirculo(angulo, raio);
        //     // reta.ponto2.X = pontoNovo.X;
        //     // reta.ponto2.Y = pontoNovo.Y;
        //     reta.DefinirPonto(reta.ponto, pontoNovo);
        // }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            if (moverPto)
            {
                //retanguloB.MoverPtoSupDir(new Ponto4D(e.Position.X, 600 - e.Position.Y, 0));
            }
        }
    }
}