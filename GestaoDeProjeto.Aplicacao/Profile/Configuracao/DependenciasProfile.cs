using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeProjeto.Aplicacao
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
            cfg.AddProfile<SquadProfile>();
        }
    }
}

