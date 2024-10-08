using AutoMapper;
using GestaoDeProjeto.Aplicacao.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeProjeto.Aplicacao.Configuracao
{
    public static class DependenciasProfile
    {
        public static void ConfigureAutoMapperProfile(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                Injetar(cfg);
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void Injetar(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<EmpresaProfile>();
            cfg.AddProfile<ProjetoProfile>();
            cfg.AddProfile<ProjetoSquadProfile>();
            cfg.AddProfile<SquadProfile>();
            cfg.AddProfile<SquadUsuarioProfile>();
            cfg.AddProfile<UsuarioProfile>();
            cfg.AddProfile<TarefaProfile>();
        }
    }
}

