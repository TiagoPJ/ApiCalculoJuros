using Api.Controllers;
using Aplicacao.Configuracao;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Options;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace APICalculaJurosXUnitTest
{
    public class InformacoesProjetoTest
    {
        private readonly TestProvider _testProvider;
        public InformacoesProjetoTest()
        {
            _testProvider = new TestProvider();
        }

        [Fact]
        public async Task InformacoesProjeto_Get_ReturnsOkResponse()
        {
            var settings = new InformacoesProjeto()
            {
                UrlProjeto = "https://github.com/",
                UrlIframeProjeto = "//cdn.iframe.ly"
            };

            IOptions<InformacoesProjeto> appSettingsOptions = Options.Create(settings);

            var response = await _testProvider.Client.GetAsync("/InformacoesProjeto/ObterInformacoesProjeto");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            _testProvider.Dispose();
        }
    }
}
