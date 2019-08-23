using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Calculo
{
    public class JurosCompostosDominio
    {
        public string Valor { get; set; }

        public JurosCompostosDominio(string valorFinal)
        {
            Valor = valorFinal;
        }
    }
}
