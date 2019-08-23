using Dominio.Calculo;

namespace Servico.Interfaces
{
    public interface ICalculoServico
    {
        JurosCompostosDominio CalculaJurosCompostos(InformacoesCalculoDominio informacoesCalculo);
    }
}
