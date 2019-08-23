using Dominio.Taxa;
using Servico.Interfaces;

namespace Servico.Implementacao
{
    public class TaxaJurosServico : ITaxaJurosServico
    {
        public TaxaJurosDominio RetornaTaxaJuros()
        {
            return new TaxaJurosDominio(1);
        }
    }
}
