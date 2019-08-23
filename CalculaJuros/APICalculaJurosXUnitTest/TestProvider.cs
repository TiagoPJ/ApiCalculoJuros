using Api;
using Aplicacao;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace APICalculaJurosXUnitTest
{
    public class TestProvider
    {
        private TestServer server;

        public HttpClient Client { get; private set; }

        public TestProvider()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
            //Mapper.Reset();
            //AdapterDtoDomain.MapperRegister();
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
