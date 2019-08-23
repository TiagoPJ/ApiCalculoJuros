using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Calculo
{
    public class InformacoesCalculoDto
    {
        public decimal ValorInicial { get; set; }
        public decimal ValorJuros { get; set; }
        public int Meses { get; set; }
    }
}
