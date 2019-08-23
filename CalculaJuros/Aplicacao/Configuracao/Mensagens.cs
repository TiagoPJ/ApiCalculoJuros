using Aplicacao.Configuracao.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Configuracao
{
    public class Mensagens : IMensagens
    {
        public IList<string> Erros { get; set; }

        public Mensagens()
        {
            Erros = new List<string>();
        }

        public bool PossuiErros => Erros.Any();
    }
}
