using Api.Controllers;
using Aplicacao;
using Aplicacao.Calculo;
using Aplicacao.Configuracao;
using Aplicacao.Configuracao.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servico.Implementacao;
using Servico.Interfaces;
using System;

namespace ApiCalculaJurosMSTest
{
    [TestClass]
    public class InformacoesProjetoTest
    {
        private readonly InformacoesProjetoController _informacoesProjetoController;
        private readonly IInformacoesProjetoServico _informacoesProjetoServico;
        private readonly IMensagens _msgs;
        private InformacoesProjeto _informacoesProjeto => RetornaInformacoesProjeto();
        public InformacoesProjetoTest()
        {
            AdapterDtoDomain.MapperRegister();            
            _msgs = new Mensagens();
            _informacoesProjetoServico = new InformacoesProjetoServico(_informacoesProjeto, _msgs);
            _informacoesProjetoController = new InformacoesProjetoController(_informacoesProjetoServico, _msgs);
        }

        [TestMethod]
        public void InformacoesProjetoTest_retornarUrlProjeto()
        {
            var resultado = _informacoesProjetoController.ObterInformacoesProjeto();

            Assert.IsTrue(resultado.Retorno.HasUrlProjeto);
        }

        [TestMethod]
        public void InformacoesProjetoTest_retornarUrlIframeProjeto()
        {
            var resultado = _informacoesProjetoController.ObterInformacoesProjeto();

            Assert.IsTrue(resultado.Retorno.HasUrlIframeProjeto);
        }

        [TestMethod]
        public void InformacoesProjetoTest_validarUrlProjeto()
        {
            var resultado = _informacoesProjetoController.ObterInformacoesProjeto();
            Uri uriResult;

            Assert.IsTrue(Uri.TryCreate(resultado.Retorno.UrlProjeto, UriKind.RelativeOrAbsolute, out uriResult));
        }

        private static InformacoesProjeto RetornaInformacoesProjeto()
        {
            return new InformacoesProjeto()
            {
                UrlProjeto = "https://github.com/",
                UrlIframeProjeto = "//cdn.iframe.ly"
            };
        }
    }
}
