using Aplicacao.Configuracao.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Servico.Interfaces;
using Aplicacao.Configuracao;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class InformacoesProjetoController : BaseController
    {
        private readonly IInformacoesProjetoServico _iInformacoesProjetoServico;

        public InformacoesProjetoController(IInformacoesProjetoServico iInformacoesProjetoServico, IMensagens msgs) : base(msgs) => _iInformacoesProjetoServico = iInformacoesProjetoServico;

        /// <summary>
        /// Retorna as informações do projeto no GitHub.
        /// </summary>
        [HttpGet]
        public ResultadoApi<InformacoesProjeto> ObterInformacoesProjeto()
        {
           return ResultadoFormatado(_iInformacoesProjetoServico.ObterInformacoesProjeto());
        }
    }
}