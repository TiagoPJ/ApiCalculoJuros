using System;

namespace Dominio.Calculo
{
    public class InformacoesCalculoDominio
    {
        public decimal ValorInicial { get; set; }

        public decimal ValorJuros { get; set; }

        public int Meses { get; set; }

        public bool ValidaValorInicial => this.ValorInicial > 0;
        public bool ValidaMeses => this.Meses > 0;
    }
}
