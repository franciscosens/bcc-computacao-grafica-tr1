using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using CG_Biblioteca;
using OpenTK.Graphics.OpenGL;

namespace FormasBiblioteca
{
    public class Circulo : ObjetoAramado
    {
        public readonly double _raio;
        private Matematica matematica = new Matematica();
        public readonly int _deslocamentoX;
        public readonly int _deslocamentoY;

        public readonly int _quantidadePontos;
        public readonly int _angulo;
        public List<Ponto4D> pontosDosAngulos = new List<Ponto4D>();
        private List<Ponto4D> pontos = new List<Ponto4D>();
        private readonly List<double> _angulosDesejados;

        /// <summary>
        /// Cria um círculo na cena
        /// </summary>
        /// <param name="raio">Raio</param>
        /// <param name="cor">Cor dos pontos do círculo</param>
        /// <param name="deslocamentoX">Caso necessário deslocar no eixo X utilziar um inteiro</param>
        /// <param name="deslocamentoY">Caso necessário deslocar no eixo Y utilziar um inteiro</param>
        /// <param name="primitivaTamanho">Tamanho dos pontos</param>        
        public Circulo(string rotulo, double raio, Color cor, int quantidadePontos = 72, int deslocamentoX = 0, int deslocamentoY = 0, int primitivaTamanho = 4, int angulo = 5)
        : base(rotulo, cor, primitivaTamanho, PrimitiveType.Points)
        {
            _raio = raio;
            _deslocamentoX = deslocamentoX;
            _deslocamentoY = deslocamentoY;
            _quantidadePontos = quantidadePontos;
            _angulo = angulo;
            GerarCirculo();
        }

        public Circulo(string rotulo, double raio, Color cor, List<double> angulos, int quantidadePontos = 72, int deslocamentoX = 0, int deslocamentoY = 0, int primitivaTamanho = 4, int angulo = 5)
       : base(rotulo, cor, primitivaTamanho, PrimitiveType.Points)
        {
            _raio = raio;
            _deslocamentoX = deslocamentoX;
            _deslocamentoY = deslocamentoY;
            _quantidadePontos = quantidadePontos;
            _angulo = angulo;
            _angulosDesejados = angulos;
            GerarCirculo();
        }

        public void DefinirBoundBox(Ponto4D pontoMin, Ponto4D pontoMax)
        {
            base.bBox.Atribuir(pontoMin, pontoMax);
        }

        private void GerarCirculo()
        {
            double angulo = 0;
            Ponto4D deslocamento = new Ponto4D(_deslocamentoX, _deslocamentoY, 0);

            for (int i = 0; i < _quantidadePontos; i = i + 1)
            {
                var ponto = matematica.GerarPtosCirculo(angulo, _raio, deslocamento);

                if (_angulosDesejados != null && _angulosDesejados.Count != 0 && (_angulosDesejados.FirstOrDefault(valor => valor == angulo) != 0))
                {
                    var anguloD = _angulosDesejados.FirstOrDefault(valor => valor == angulo);
                    pontosDosAngulos.Add(ponto);
                }
                pontos.Add(ponto);
                angulo += _angulo;
            }
            base.PontosAdicionar(pontos);
            GL.End();
        }

        public string Mover(Ponto4D distancia, Ponto4D pontoCirculoMaior, double raioCirculoMaior)
        {

            double angulo = 0;
            foreach (Ponto4D ponto in pontos)
            {
                var pontoNovo = matematica.GerarPtosCirculo(angulo, _raio, distancia);
                ponto.X = pontoNovo.X;
                ponto.Y = pontoNovo.Y;
                angulo += _angulo;
            }
            return TratarColisao(distancia, pontoCirculoMaior, raioCirculoMaior);
        }

        private string TratarColisao(Ponto4D pontoQuadrado, Ponto4D pontoCirculoMaior, double raioCirculoMaior)
        {
            var boundBox = base.bBox;
            if (pontoQuadrado.X > boundBox.obterMenorX || pontoQuadrado.X < boundBox.obterMaiorX || pontoQuadrado.Y > boundBox.obterMenorY || pontoQuadrado.Y < boundBox.obterMaiorY)
            {
                double x1 = pontoCirculoMaior.X, x2 = pontoQuadrado.X, y1 = pontoCirculoMaior.Y, y2 = pontoQuadrado.Y;
                if (Math.Sqrt(Math.Pow(((x2 - x1)), 2) + Math.Pow(((y2 - y1)), 2)) > raioCirculoMaior)
                {
                    return "Fora Completo";
                }
                return "Fora";
            }
            else
            {

                return "Dentro";
            }
        }
    }
}