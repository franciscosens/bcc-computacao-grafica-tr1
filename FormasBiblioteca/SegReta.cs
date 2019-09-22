using System.Drawing;
using CG_Biblioteca;
using OpenTK.Graphics.OpenGL;
using System;
using Color = OpenTK.Color;

namespace FormasBiblioteca
{
    public class SegReta : ObjetoAramado
    {
        private Ponto4D ponto, ponto2;
        private int _raio;
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
            this._raio = 100;
        }

        public SegReta(string rotulo, Ponto4D ponto, Color cor, float primitivaTamanho, int angulo = 0) : base(rotulo, cor, primitivaTamanho)
        {
            this.ponto = ponto;
            this._angulo = angulo;
            this._raio = 100;
            matematica = new Matematica();
            ponto2 = matematica.GerarPtosCirculo(angulo, _raio, ponto);
            base.PontosAdicionar(ponto);
            base.PontosAdicionar(ponto2);
        }

        public string GetRotulo()
        {
            return base.rotulo;
        }

        public void IncrementarAngulo()
        {
            metodo = "IncrementarAngulo";
            this._angulo = this._angulo > 360 ? 0 : this._angulo + 1;
            var pontoNovo = matematica.GerarPtosCirculo(_angulo, _raio, ponto);
            ponto2.X = pontoNovo.X;
            ponto2.Y = pontoNovo.Y;

            Log();
        }

        public void DecrementarAngulo()
        {
            metodo = "DecrementarAngulo";
            this._angulo = this._angulo <= 0 ? 360 : this._angulo - 1;
            var pontoNovo = matematica.GerarPtosCirculo(_angulo, _raio, ponto);
            ponto2.X = pontoNovo.X;
            ponto2.Y = pontoNovo.Y;
            Log();
        }

        public void Aumentar()
        {
            metodo = "Aumentar";
            _raio++;
            var pontoNovo = matematica.GerarPtosCirculo(_angulo, _raio, ponto);
            ponto2.X = pontoNovo.X;
            ponto2.Y = pontoNovo.Y;
            Log();
        }

        public void Diminuir()
        {
            metodo = "Diminuir";
            _raio--;
            var pontoNovo = matematica.GerarPtosCirculo(_angulo, _raio, ponto);
            ponto2.X = pontoNovo.X;
            ponto2.Y = pontoNovo.Y;
            Log();
        }

        public void Avancar()
        {

            ponto.X++;
            ponto2.X++;
            metodo = "Avançar";
            Log();
        }

        public void Retornar()
        {
            ponto.X--;
            ponto2.X--;
            metodo = "Avançar";
            Log();
        }

        public void Log()
        {
            Console.Write(metodo);
            for (int i = 30; i >= metodo.Length; i--)
            {
                Console.Write(" ");
            }

            System.Console.WriteLine($"\tPonto: {ponto}\t\tPonto2: {ponto2}\t\tAngulo: {_angulo}");
        }

    }
}