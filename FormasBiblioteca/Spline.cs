using OpenTK.Graphics.OpenGL;
using CG_Biblioteca;
using System.Collections.Generic;
using Color = OpenTK.Color;
using OpenTK.Input;

namespace FormasBiblioteca
{
    public class Spline
    {
        private List<Ponto4D> pontos = new List<Ponto4D>();

        List<Ponto4D> pontosSpline = new List<Ponto4D>();

        private short pontoSelecionado = 0;

        private double contPontosDeControle;

        private SegReta segReta;

        public Spline()
        {
            this.init();
        }

        public void init()
        {
            this.pontos = new List<Ponto4D>
      {
        new Ponto4D(-100, -100),
        new Ponto4D(-100, 100),
        new Ponto4D(100, 100),
        new Ponto4D(100, -100),
      };

            this.contPontosDeControle = 15;
            this.pontosSpline = ObterSpline();
        }

        public void Desenhar()
        {
            GL.PointSize(10);

            Ponto4D ultimoPonto = null;

            for (var i = 0; i < this.pontos.Count; i++)
            {
                Ponto4D ponto = this.pontos[i];

                GL.Begin(PrimitiveType.Points);
                GL.Color3(i == this.pontoSelecionado ? Color.Red : Color.Black);
                GL.Vertex2(ponto.X, ponto.Y);
                GL.End();

                if (ultimoPonto != null)
                {
                    segReta = new SegReta($"{i}", new Ponto4D(ultimoPonto.X, ultimoPonto.Y), new Ponto4D(ponto.X, ponto.Y), Color.Cyan, 3);
                    segReta.Desenhar();
                }

                ultimoPonto = ponto;
            }

            this.DesenharSpline();
        }

        private void DesenharSpline()
        {
            Ponto4D ultimoPontoSpline = null;

            foreach (Ponto4D pontoSpline in this.pontosSpline)
            {
                if (ultimoPontoSpline != null)
                {
                    segReta = new SegReta("Spline", new Ponto4D(ultimoPontoSpline.X, ultimoPontoSpline.Y), new Ponto4D(pontoSpline.X, pontoSpline.Y), Color.Yellow, 3);
                    segReta.Desenhar();
                }
                ultimoPontoSpline = pontoSpline;
            }
        }

        private List<Ponto4D> ObterSpline()
        {
            List<Ponto4D> pontosSpline = new List<Ponto4D>();

            for (int i = 0; i <= this.contPontosDeControle; i++)
            {
                double t = (1 / this.contPontosDeControle) * i;
                pontosSpline.Add(this.ObterPontoSpline(t));
            }

            return pontosSpline;
        }

        private Ponto4D ObterPontoSpline(double t)
        {
            double p0p1X = CalcularSpline(pontos[0].X, pontos[1].X, t);
            double p0p1Y = CalcularSpline(pontos[0].Y, pontos[1].Y, t);

            double p1p2X = CalcularSpline(pontos[1].X, pontos[2].X, t);
            double p1p2Y = CalcularSpline(pontos[1].Y, pontos[2].Y, t);

            double p2p3X = CalcularSpline(pontos[2].X, pontos[3].X, t);
            double p2p3Y = CalcularSpline(pontos[2].Y, pontos[3].Y, t);

            double p0p1p2X = CalcularSpline(p0p1X, p1p2X, t);
            double p0p1p2Y = CalcularSpline(p0p1Y, p1p2Y, t);

            double p1p2p3X = CalcularSpline(p1p2X, p2p3X, t);
            double p1p2p3Y = CalcularSpline(p1p2Y, p2p3Y, t);

            double p0p1p2p3X = CalcularSpline(p0p1p2X, p1p2p3X, t);
            double p0p1p2p3Y = CalcularSpline(p0p1p2Y, p1p2p3Y, t);

            return new Ponto4D(p0p1p2p3X, p0p1p2p3Y);
        }

        private double CalcularSpline(double A, double B, double t)
        {
            return A + (B - A) * t;
        }

        public void SelecionarPonto(short indexPonto)
        {
            this.pontoSelecionado = indexPonto;
        }

        public void MoverPontoDeControle(Key key)
        {
            double deslocamentoX = 0;
            double deslocamentoY = 0;

            if (Key.C.Equals(key))
                deslocamentoY = 1;
            if (Key.B.Equals(key))
                deslocamentoY = -1;
            if (Key.E.Equals(key))
                deslocamentoX = -1;
            if (Key.D.Equals(key))
                deslocamentoX = 1;

            Ponto4D ponto = this.ObterPontoSelecionado();
            ponto.X = ponto.X + deslocamentoX;
            ponto.Y = ponto.Y + deslocamentoY;

            this.pontosSpline = ObterSpline();
        }

        private Ponto4D ObterPontoSelecionado()
        {
            return this.pontos[this.pontoSelecionado];
        }

        public void AumentarQtdePontos()
        {
            this.contPontosDeControle++;

            this.pontosSpline = ObterSpline();
        }

        public void DiminuirQtdePontos()
        {
            if (this.contPontosDeControle > 1)
                this.contPontosDeControle--;

            this.pontosSpline = ObterSpline();
        }

        public void ReiniciarPontosDeControle()
        {
            this.init();
        }

    }
}
