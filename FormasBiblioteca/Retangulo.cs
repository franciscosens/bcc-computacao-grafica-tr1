using System;
using CG_Biblioteca;

namespace FormasBiblioteca
{
    public class Retangulo : ObjetoAramado
    {
        private Ponto4D ptoInfEsq, ptoSupDir;
        public Retangulo(string rotulo, Ponto4D ptoInfEsq, Ponto4D ptoSupDir) : base(rotulo)
        {
            this.ptoInfEsq = ptoInfEsq;
            this.ptoSupDir = ptoSupDir;
            GerarPtosRetangulo();
            base.PontosAdicionar(ptoInfEsq);
            base.PontosAdicionar(new Ponto4D(ptoSupDir.X, ptoInfEsq.Y));
        }

        private void GerarPtosRetangulo()
        {
            base.PontosRemoverTodos();
            base.PontosAdicionar(ptoSupDir);
            base.PontosAdicionar(new Ponto4D(ptoInfEsq.X, ptoSupDir.Y));
        }

        public void MoverPtoSupDir(Ponto4D ptoMover)
        {
            ptoSupDir = ptoMover;
            GerarPtosRetangulo();
        }
    }
}