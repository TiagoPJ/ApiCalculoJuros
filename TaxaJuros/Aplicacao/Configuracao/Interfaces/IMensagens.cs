using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Configuracao.Interfaces
{
    public interface IMensagens
    {
        IList<string> Erros { get; set; }
        bool PossuiErros { get; }
    }
}
