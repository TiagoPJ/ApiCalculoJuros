using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiTaxaJurosXUniTest
{
    public class TaxaIntegrationTest
    {
        private readonly TestProvider _testProvider;
        public TaxaIntegrationTest()
        {
            _testProvider = new TestProvider();
        }

        [Fact]
        public async Task ObterTaxaJuros_Get_ReturnsOkResponse()
        {
            var response = await _testProvider.Client.GetAsync("/ObterTaxaJuros");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
