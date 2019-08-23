using Aplicacao.Configuracao;
using Aplicacao.Configuracao.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public IMensagens _msgs { get; }

        public BaseController(IMensagens msgs) => _msgs = msgs;

        protected ResultadoApi<T> ResultadoFormatado<T>(T objRetorno)
        {
            if (_msgs.PossuiErros)
            {
                return new ResultadoApi<T>("Ocorreu um erro, operação cancelada", objRetorno, false, _msgs.Erros);
            }
            else
            {
                return new ResultadoApi<T>("Método executado com sucesso", objRetorno, true);
            }
        }
    }
}
