using Aplicacao;
using Aplicacao.Calculo;
using Aplicacao.Configuracao;
using AutoMapper;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APICalculaJurosXUnitTest
{
    public class CalculoJurosIntegrationTest
    {
        private readonly TestProvider _testProvider;
        public CalculoJurosIntegrationTest()
        {
            _testProvider = new TestProvider();
        }

        [Fact]
        public async Task CalculaJurosCompostos_Post_ReturnsOkResponse()
        {
            var informacoesCalculo = new InformacoesCalculoDto
            {
                Meses = 5,
                ValorInicial = 100,
                ValorJuros = Convert.ToDecimal(0.01)
            };
            var jsonToPost = JsonConvert.SerializeObject(informacoesCalculo);
            var stringContent = new StringContent(jsonToPost, Encoding.UTF8, "application/json");

            var response = await _testProvider.Client.PostAsync("/Calculo/CalculaJurosCompostos", stringContent);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var jsonRetorno = await response.Content.ReadAsStringAsync();
            var objetoRetorno = JsonConvert.DeserializeObject<ResultadoApi<JurosCompostosDto>>(jsonRetorno);
            objetoRetorno.IsOk.Should().Be(true);
            objetoRetorno.Retorno.Valor.Should().Be("R$105,10");

            _testProvider.Dispose();
        }
    }
}