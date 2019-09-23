#region using
using System.Linq;
using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using CG_Biblioteca;
using FormasBiblioteca;
using System.Collections.Generic;
#endregion

namespace questao07
{

    public class Mundo : GameWindow
    {
        #region Declaracoes
        public static Mundo instance = null;
        private Color corQuadrado;
        private Circulo circuloMaior, circuloMenor;
        private SegReta segmentoRetaQuadradoCima, segmentoRetaQuadradoEsquerda, segmentoRetaQuadradoBaixo, segmentoRetaQuadradoDireita;
        private Camera camera = new Camera();
        protected List<Objeto> objetosLista = new List<Objeto>();
        private bool moverPto = false;
        public Mundo(int width, int height) : base(width, height) { }
        private double raioCirculoMaior = 100;
        #endregion

        #region Singleton
        public static Mundo getInstance()
        {
            if (instance == null)
                instance = new Mundo(600, 600);
            return instance;
        }
        #endregion

        #region  OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            double raio = 100;

            var segmentoRetaA = new SegReta("A", new Ponto4D(0, 20, 0), new Ponto4D(200, 20, 0), Color.Red, 3);
            var segmentoRetaB = new SegReta("B", new Ponto4D(20, 0, 0), new Ponto4D(20, 200, 0), Color.Green, 3);
            var angulosDesejados = new List<double>() { 45, 135, 225, 315 };
            circuloMaior = new Circulo("C", raioCirculoMaior, Color.Black, angulosDesejados, 360, 200, 200, 1, 1);
            circuloMenor = new Circulo("C", 50, Color.Black, 360, 200, 200, 1, 1);

            Ponto4D ponto1 = circuloMaior.pontosDosAngulos[0];
            Ponto4D ponto2 = circuloMaior.pontosDosAngulos[1];
            Ponto4D ponto3 = circuloMaior.pontosDosAngulos[2];
            Ponto4D ponto4 = circuloMaior.pontosDosAngulos[3];
            corQuadrado = Color.Pink;
            segmentoRetaQuadradoCima = new SegReta("p", ponto1, ponto2, corQuadrado, 1);
            segmentoRetaQuadradoEsquerda = new SegReta("p", ponto2, ponto3, corQuadrado, 1);
            segmentoRetaQuadradoBaixo = new SegReta("p", ponto3, ponto4, corQuadrado, 1);
            segmentoRetaQuadradoDireita = new SegReta("p", ponto4, ponto1, corQuadrado, 1);

            circuloMenor.DefinirBoundBox(ponto1, ponto3);

            objetosLista.Add(segmentoRetaQuadradoCima);
            objetosLista.Add(segmentoRetaQuadradoDireita);
            objetosLista.Add(segmentoRetaQuadradoBaixo);
            objetosLista.Add(segmentoRetaQuadradoEsquerda);
            objetosLista.Add(segmentoRetaA);
            objetosLista.Add(segmentoRetaB);
            objetosLista.Add(circuloMenor);
            objetosLista.Add(circuloMaior);
            GL.ClearColor(Color.Gray);
        }
        #endregion

        #region OnAlgumaCoisaFrame
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(camera.xmin, camera.xmax, camera.ymin, camera.ymax, camera.zmin, camera.zmax);
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
        #endregion

        #region  OnAction
        protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Exit();
            else if (e.Key == Key.E)
            {
                for (var i = 0; i < objetosLista.Count; i++)
                {
                    objetosLista[i].PontosExibirObjeto();
                }
            }
            else if (e.Key == Key.M)
            {
                moverPto = !moverPto;
            }
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            if (moverPto)
            {
                string localizacao = circuloMenor.Mover(new Ponto4D(e.Position.X, 600 - e.Position.Y, 0), new Ponto4D(200, 200, 0), raioCirculoMaior);
                if (localizacao == "Dentro")
                {
                    DefinirCorQuadrado(Color.Pink);
                }
                else if (localizacao == "Fora")
                {
                    DefinirCorQuadrado(Color.Cyan);
                }
                else if (localizacao == "Fora Completo")
                {
                    DefinirCorQuadrado(Color.Yellow);
                }
            }
        }
        #endregion

        private void DefinirCorQuadrado(Color cor)
        {
            segmentoRetaQuadradoCima.Cor = cor;
            segmentoRetaQuadradoBaixo.Cor = cor;
            segmentoRetaQuadradoDireita.Cor = cor;
            segmentoRetaQuadradoEsquerda.Cor = cor;
        }

    }
}