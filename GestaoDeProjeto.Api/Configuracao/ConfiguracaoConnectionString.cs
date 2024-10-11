using GestaoDeProjeto.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Api.Configuracao
{
    internal static class ConfiguracaoConnectionString
    {
        public static void CarregaConexaoComBancoDeDados(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var connectionString = configuration["ConnectionStrings:Gravacao"];
            services.AddDbContext<GestaoDeProjetoContexto>(options => options.UseSqlServer(connectionString));

 
        }

    }
}
