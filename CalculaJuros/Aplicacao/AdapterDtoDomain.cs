using Aplicacao.Calculo;
using AutoMapper;
using Dominio.Calculo;

namespace Aplicacao
{
    public class AdapterDtoDomain
    {
        private static object _thisLock = new object();
        private static bool _initialized = false;

        public AdapterDtoDomain()
        {
        }

        public static void MapperRegister()
        {
            // This will ensure one thread can access to this static initialize call
            // and ensure the mapper is reseted before initialized
            lock (_thisLock)
            {
                if (!_initialized)
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<InformacoesCalculoDto, InformacoesCalculoDominio>()
                        .ForMember(dom => dom.ValidaMeses, opt => opt.Ignore())
                        .ForMember(dom => dom.ValidaValorInicial, opt => opt.Ignore()).ReverseMap();
                    });
                    _initialized = true;
                }
            }           
        }
    }
}
