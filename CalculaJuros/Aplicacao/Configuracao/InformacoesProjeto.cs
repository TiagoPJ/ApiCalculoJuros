namespace Aplicacao.Configuracao
{
    public class InformacoesProjeto
    {
        public string UrlProjeto { get; set; }
        public string UrlIframeProjeto { get; set; }
        public bool HasUrlProjeto { get { return !string.IsNullOrEmpty(UrlProjeto); } }
        public bool HasUrlIframeProjeto { get { return !string.IsNullOrEmpty(UrlIframeProjeto); } }
    }
}
