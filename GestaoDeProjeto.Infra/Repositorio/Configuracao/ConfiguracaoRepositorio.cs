using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeProjeto.Infra.Repositorio.Configuracao
{
    public static class ConfiguracaoRepositorio
    {
        public static void DependenciasDoEntity(this IServiceCollection services)
        {
            services.AddInterfaceRepositorio();
        }

        public static IServiceCollection AddInterfaceRepositorio(this IServiceCollection services)
        {

            services.AddTransient<IProjetoRepositorio, ProjetoRepositorio>();
            services.AddScoped<IProjetoRepositorio, ProjetoRepositorio>();
 
            return services;
        }
    }
}
