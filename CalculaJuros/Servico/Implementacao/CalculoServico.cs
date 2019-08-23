using Aplicacao.Configuracao.Interfaces;
using Dominio.Calculo;
using Servico.Interfaces;
using System;

namespace Servico.Implementacao
{
    public class CalculoServico : ICalculoServico
    {
        private readonly IMensagens _msgs;

        public CalculoServico(IMensagens msgs) => _msgs = msgs;

        public JurosCompostosDominio CalculaJurosCompostos(InformacoesCalculoDominio informacoesCalculo)
        {
            if (!informacoesCalculo.ValidaMeses)
                _msgs.Erros.Add("A quantidade de meses dever ser maior que ZERO.");

            if (!informacoesCalculo.ValidaValorInicial)
                _msgs.Erros.Add("O Valor inicial dever ser maior que ZERO.");

            double valorFinal = Convert.ToDouble(informacoesCalculo.ValorInicial) *
                                    Math.Pow(1 + Convert.ToDouble(informacoesCalculo.ValorJuros),
                                             Convert.ToDouble(informacoesCalculo.Meses));

            return new JurosCompostosDominio(valorFinal.ToString("C"));
        }
    }
}
