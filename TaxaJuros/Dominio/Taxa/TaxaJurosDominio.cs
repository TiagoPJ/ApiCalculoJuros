using System;

namespace Dominio.Taxa
{
    public class TaxaJurosDominio
    {
        public decimal Juros { get; set; }

        public TaxaJurosDominio(decimal juros)
        {
            Juros = Math.Round(juros / 100, 2);
        }
    }
}
