using Api.Controllers;
using Aplicacao;
using Aplicacao.Configuracao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servico.Implementacao;
using System;

namespace ApiTaxaJurosMSTest
{
    [TestClass]
    public class TaxaTest
    {
        private readonly TaxaController _taxaController;
        public TaxaTest()
        {
            AdapterDtoDomain.MapperRegister();
            _taxaController = new TaxaController(new TaxaJurosServico(), new Mensagens());
        }

        [TestMethod]
        public void TaxaTest_retornarOkTrue()
        {
            var resultado = _taxaController.ObterTaxaJuros();

            Assert.IsTrue(resultado.IsOk);
        }

        [TestMethod]
        [DataRow("0,01")]
        public void TaxaTest_retornarValorTaxa(string valorTaxa)
        {
            var resultado = _taxaController.ObterTaxaJuros();
       
            Assert.AreEqual(Convert.ToDecimal(valorTaxa), resultado.Retorno.Juros);
        }

        [TestMethod]
        public void TaxaTest_retornarValorTaxaMaiorQueZero()
        {
            var resultado = _taxaController.ObterTaxaJuros();

            Assert.IsTrue(resultado.Retorno.Juros > 0);
        }
    }
}
