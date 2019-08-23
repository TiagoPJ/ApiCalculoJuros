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
    public class CalculoTest
    {
        private readonly CalculoController _calculoController;
        private readonly ICalculoServico _calculoServico;
        private readonly IMensagens _msgs;
        public CalculoTest()
        {
            AdapterDtoDomain.MapperRegister();            
            _msgs = new Mensagens();
            _calculoServico = new CalculoServico(_msgs);
            _calculoController = new CalculoController(_calculoServico, _msgs);
        }

        [TestMethod]
        [DataRow("100", "0,01", 5)]
        [DataRow("200", "0,01", 10)]
        [DataRow("400", "0,01", 15)]
        public void CalculoTest_retornarOkTrue(string valorInicial, string juros, int meses)
        {
            var resultado = _calculoController.CalculaJurosCompostos(RetornaInformacoesCalculo(valorInicial, juros, meses));

            Assert.IsTrue(resultado.IsOk);
        }


        [TestMethod]
        [DataRow("100", "0,01", 5, "105,10")]
        [DataRow("0", "0,01", 5, "0,00")]
        [DataRow("0", "0,01", 0, "0,00")]
        public void CalculoTest_retornarValorFinalIgualAoValorComparar(string valorInicial, string juros, int meses, string valorComparar)
        {
            var resultado = _calculoController.CalculaJurosCompostos(RetornaInformacoesCalculo(valorInicial, juros, meses));

            Assert.AreEqual(Convert.ToDouble(valorComparar).ToString("C"), resultado.Retorno.Valor);
        }

        private static InformacoesCalculoDto RetornaInformacoesCalculo(string valorInicial, string juros, int meses)
        {
            return new InformacoesCalculoDto()
            {
                ValorInicial = Convert.ToDecimal(valorInicial),
                ValorJuros = Convert.ToDecimal(juros),
                Meses = meses
            };
        }
    }
}
