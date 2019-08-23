using Aplicacao.Configuracao;
using Aplicacao.Configuracao.Interfaces;
using Aplicacao.Taxa;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Servico.Interfaces;
namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("/[action]")]
    public class TaxaController: BaseController
    {
        private readonly ITaxaJurosServico _taxaJurosServico;

        public TaxaController(ITaxaJurosServico taxaJurosServico, IMensagens msgs) : base(msgs) => _taxaJurosServico = taxaJurosServico;

        /// <summary>
        /// Faz o retorno da taxa de juros de 0.01 fixo
        /// </summary>
        /// <returns>Retorna valor da taxa de juros</returns>
        [HttpGet]
        public ResultadoApi<TaxaJurosDto> ObterTaxaJuros()
        {
            return ResultadoFormatado(Mapper.Map<TaxaJurosDto>(_taxaJurosServico.RetornaTaxaJuros()));
        }
    }
}