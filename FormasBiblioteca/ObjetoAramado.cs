using System;
using System.Collections.Generic;
using CG_Biblioteca;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using Color = OpenTK.Color;

namespace FormasBiblioteca
{
    public class ObjetoAramado : Objeto
    {
        protected List<Ponto4D> pontosLista = new List<Ponto4D>();
        public Color Cor { get; set; }

        public ObjetoAramado(string rotulo, Color cor, float primitivaTamanho) : base(rotulo)
        {
            this.Cor = cor;
            base.PrimitivaTamanho = primitivaTamanho;
        }

        public ObjetoAramado(string rotulo, Color cor, float primitivaTamanho, PrimitiveType primitivaTipo) : base(rotulo)
        {
            this.Cor = cor;
            base.PrimitivaTipo = primitivaTipo;
            base.PrimitivaTamanho = primitivaTamanho;
        }

        public ObjetoAramado(string rotulo) : base(rotulo)
        {
            Cor = Color.Black;
        }

        protected override void DesenharAramado()
        {
            if (base.PrimitivaTipo == PrimitiveType.Points)
            {
                GL.PointSize(base.PrimitivaTamanho);
            }
            else
            {
                GL.LineWidth(base.PrimitivaTamanho);
            }
            GL.Color3(Cor);
            GL.Begin(base.PrimitivaTipo);
            foreach (Ponto4D pto in pontosLista)
            {
                GL.Vertex2(pto.X, pto.Y);
            }
            GL.End();
        }
        protected void PontosAdicionar(List<Ponto4D> pontos)
        {
            foreach (Ponto4D ponto in pontos)
            {
                pontosLista.Add(ponto);
            }
        }

        protected void PontosAdicionar(Ponto4D pto)
        {
            pontosLista.Add(pto);
        }

        protected void PontosRemoverTodos()
        {
            pontosLista.Clear();
        }

        protected override void PontosExibir()
        {
            Console.WriteLine("__ Objeto: " + base.rotulo);
            for (var i = 0; i < pontosLista.Count; i++)
            {
                Console.WriteLine("P" + i + "[" + pontosLista[i].X + "," + pontosLista[i].Y + "," + pontosLista[i].Z + "," + pontosLista[i].W + "]");
            }
        }
    }
}