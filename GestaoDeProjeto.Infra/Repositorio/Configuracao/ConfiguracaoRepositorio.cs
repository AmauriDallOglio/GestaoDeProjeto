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
            services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
            services.AddScoped<IProjetoRepositorio, ProjetoRepositorio>();
            services.AddScoped<IProjetoSquadRepositorio, ProjetoSquadRepositorio>();
            services.AddScoped<ISquadRepositorio, SquadRepositorio>();
            services.AddScoped<ISquadUsuarioRepositorio, SquadUsuarioRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
 

            return services;
        }
    }
}
