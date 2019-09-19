using System;
using System.Drawing;
using CG_Biblioteca;
using OpenTK.Graphics.OpenGL;
using Color = OpenTK.Color;

namespace FormasBiblioteca
{
    public class Circulo : ObjetoAramado
    {
        public readonly double _raio;

        public readonly int _deslocamentoX;
        public readonly int _deslocamentoY;

        /// <summary>
        /// Cria um círculo na cena
        /// </summary>
        /// <param name="raio">Raio</param>
        /// <param name="cor">Cor dos pontos do círculo</param>
        /// <param name="deslocamentoX">Caso necessário deslocar no eixo X utilziar um inteiro</param>
        /// <param name="deslocamentoY">Caso necessário deslocar no eixo Y utilziar um inteiro</param>
        /// <param name="primitivaTamanho">Tamanho dos pontos</param>
        public Circulo(string rotulo, double raio, Color cor, int deslocamentoX = 0, int deslocamentoY = 0, int primitivaTamanho = 4) 
        : base(rotulo, cor, primitivaTamanho, PrimitiveType.Points)
        {
            _raio = raio;
            _deslocamentoX = deslocamentoX;
            _deslocamentoY = deslocamentoY;
            GerarCirculo();
        }

        private void GerarCirculo()
        {
            var matematica = new Matematica();
            double angulo = 0;
            for (int i = 0; i < 72; i = i + 1)
            {
                var pontos = matematica.GerarPtosCirculo(angulo, _raio);
                double x = pontos.X + _deslocamentoX;
                double y = pontos.Y + _deslocamentoY;
                base.PontosAdicionar(new Ponto4D(x, y, 0));
                angulo += 5;
            }
            GL.End();
        }
    }
}
