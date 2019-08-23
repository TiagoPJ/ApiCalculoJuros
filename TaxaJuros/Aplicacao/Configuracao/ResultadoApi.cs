using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Configuracao
{
    public class ResultadoApi<T>
    {
        public T Retorno  { get; set; }
        public bool IsOk { get; set; }
        public string Mensagem { get; set; }
        public IList<string> Erros { get; set; }

        public ResultadoApi(string mensagem, T retorno, bool isOk, IList<string> erros = null)
        {
            Retorno = retorno;
            IsOk = isOk;
            Mensagem = mensagem;
            Erros = erros;
        }
    }
}
