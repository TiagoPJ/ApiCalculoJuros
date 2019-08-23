using Aplicacao.Configuracao;
using Aplicacao.Configuracao.Interfaces;
using Servico.Interfaces;

namespace Servico.Implementacao
{
    public class InformacoesProjetoServico : IInformacoesProjetoServico
    {
        private readonly IMensagens _msgs;

        private InformacoesProjeto _informacoesProjeto;

        public InformacoesProjetoServico(InformacoesProjeto informacoesProjeto, IMensagens msgs)
        {
            _msgs = msgs;
            _informacoesProjeto = informacoesProjeto;
        }

        public InformacoesProjeto ObterInformacoesProjeto()
        {
            if (!_informacoesProjeto.HasUrlIframeProjeto)
                _msgs.Erros.Add("Não foi informado a url de iframe para do projeto na APICalculaJuros.");

            if (!_informacoesProjeto.HasUrlProjeto)
                _msgs.Erros.Add("Não foi informado a url do github do projeto na APICalculaJuros.");

            return !_msgs.PossuiErros ? _informacoesProjeto : null;
        }
    }
}
