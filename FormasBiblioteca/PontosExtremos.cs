using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using Color = OpenTK.Color;
using System.Collections.Generic;

namespace FormasBiblioteca
{


    public class PontosExtremos : ObjetoAramado
    {
        private List<Ponto4D> pontos = new List<Ponto4D>();

        private PrimitiveType primitiva;

        public PontosExtremos(string rotulo, PrimitiveType primitivaTipo, List<Ponto4D> pontos): base(rotulo) {
            Primitiva = primitivaTipo;
            this.pontos = pontos;
        }

        protected override void DesenharAramado() {
            GL.Begin(Primitiva);
            GL.Color3(Color.Cyan);
            GL.Vertex3(pontos[0].X, pontos[0].Y, 0);
            GL.Color3(Color.Magenta);
            GL.Vertex3(pontos[1].X, pontos[1].Y, 0);
            GL.Color3(Color.Yellow);
            GL.Vertex3(pontos[2].X, pontos[2].Y, 0);
            GL.Color3(Color.Black);
            GL.Vertex3(pontos[3].X, pontos[3].Y, 0);
            GL.End();
        }

        public PrimitiveType Primitiva{
            get => primitiva;
            set => primitiva = value;
        }
    }
}