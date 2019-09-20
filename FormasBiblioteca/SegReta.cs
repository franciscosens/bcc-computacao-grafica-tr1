using System.Drawing;
using CG_Biblioteca;
using OpenTK.Graphics.OpenGL;
using System;

namespace FormasBiblioteca
{
    public class SegReta : ObjetoAramado
    {
        private int _angulo;
        private string metodo;
        private double distancia = 100;
        private Matematica matematica;

        public SegReta(string rotulo, Ponto4D ponto, Ponto4D ponto2) : base(rotulo)
        {
            matematica = new Matematica();
            base.PontosAdicionar(ponto);
            base.PontosAdicionar(ponto2);
        }

        public SegReta(string rotulo, Ponto4D ponto, Ponto4D ponto2, Color cor, float primitivaTamanho, int angulo = 0) : base(rotulo, cor, primitivaTamanho)
        {
            matematica = new Matematica();
            base.PontosAdicionar(ponto);
            base.PontosAdicionar(ponto2);
            this._angulo = angulo;
        }

        public string GetRotulo()
        {
            return base.rotulo;
        }

        public void IncrementarAngulo()
        {
            metodo = "IncrementarAngulo";
            this._angulo = this._angulo > 360 ? 0 : this._angulo + 1;
            // if (this._angulo > 360)this._angulo = 0;
            // else this._angulo++;
            AtualizarPonto();
        }

        public void DecrementarAngulo()
        {
            metodo = "DecrementarAngulo";
            this._angulo = this._angulo <= 0 ? 360 : this._angulo - 1;
            // if (this._angulo <= 0) this._angulo = 360;
            // else this._angulo--;
            AtualizarPonto();
        }

        private void AtualizarPonto(int inc = 0)
        {
            Ponto4D ponto = base.pontosLista[0];
            Ponto4D ponto2 = base.pontosLista[1];

            double x = ponto2.X - ponto.X;
            double y = ponto2.Y - ponto.Y;
            distancia = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            Ponto4D pontoNovo = matematica.GerarPtosCirculo(_angulo, distancia + inc);
            DefinirPonto(ponto, pontoNovo);
        }

        public void Aumentar()
        {
            metodo = "Aumentar";
            AtualizarPonto(1);
        }

        public void Diminuir()
        {
            metodo = "Diminuir";
            AtualizarPonto(-1);
        }

        public void Avancar()
        {
            Ponto4D ponto = base.pontosLista[0];
            Ponto4D ponto2 = base.pontosLista[1];

            Ponto4D pontoNovo = new Ponto4D();
            pontoNovo.X = ponto.X + 1;
            pontoNovo.Y = ponto.Y;

            Ponto4D pontoNovo2 = new Ponto4D();
            pontoNovo2.X = ponto2.X + 1;
            pontoNovo2.Y = ponto2.Y;

            metodo = "Avançar";
            DefinirPonto(pontoNovo, pontoNovo2);
        }

        public void Retornar()
        {
            metodo = "Retornar";
            Ponto4D ponto = base.pontosLista[0];
            ponto.X = ponto.X - 1;
            Ponto4D ponto2 = base.pontosLista[1];
            ponto2.X = ponto2.X - 1;
            DefinirPonto(ponto, ponto2);
        }

        public void DefinirPonto(Ponto4D ponto, Ponto4D ponto2)
        {
            base.PontosRemoverTodos();
            base.PontosAdicionar(ponto);
            base.PontosAdicionar(ponto2);
            Console.Write(metodo);
            for (int i = 30; i >= metodo.Length; i--)
            {
                Console.Write(" ");
            }

            System.Console.WriteLine($"\tPonto: {ponto}\t\tPonto2: {ponto2}\t\tAngulo: {_angulo}");
        }

    }
}