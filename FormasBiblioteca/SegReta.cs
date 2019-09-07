using System.Drawing;
using CG_Biblioteca;
using OpenTK.Graphics.OpenGL;

namespace FormasBiblioteca
{
    public class SegReta : ObjetoAramado
    {

        public SegReta(string rotulo, Ponto4D ponto, Ponto4D ponto2) : base(rotulo)
        {
            base.PontosAdicionar(ponto);
            base.PontosAdicionar(ponto2);
        }
        
        public SegReta(string rotulo, Ponto4D ponto, Ponto4D ponto2, Color cor, float primitivaTamanho) : base(rotulo, cor, primitivaTamanho)
        {
            base.PontosAdicionar(ponto);
            base.PontosAdicionar(ponto2);
        }
    }
}