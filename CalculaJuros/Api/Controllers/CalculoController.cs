using Aplicacao.Calculo;
using Aplicacao.Configuracao;
using Aplicacao.Configuracao.Interfaces;
using AutoMapper;
using Dominio.Calculo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servico.Interfaces;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class CalculoController : BaseController
    {
        private readonly ICalculoServico _calculoServico;

        public CalculoController(ICalculoServico calculoServico, IMensagens msgs) : base(msgs) => _calculoServico = calculoServico;

        /// <summary>
        /// Faz o cálculo de juros compostos de acordo com os parâmetros informados.
        /// </summary>
        /// <param name="informacoesCalculo">Contém valor inicial, juros e quantidade de meses</param>
        [HttpPost]
        public ResultadoApi<JurosCompostosDto> CalculaJurosCompostos([FromBody] InformacoesCalculoDto informacoesCalculo)
        {
            var retorno = _calculoServico.CalculaJurosCompostos(Mapper.Map<InformacoesCalculoDominio>(informacoesCalculo));
            return ResultadoFormatado(Mapper.Map<JurosCompostosDto>(retorno));
        }
    }
}