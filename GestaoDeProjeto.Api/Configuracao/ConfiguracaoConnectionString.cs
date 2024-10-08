using GestaoDeProjeto.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Api.Configuracao
{
    internal static class ConfiguracaoConnectionString
    {
        public static void CarregaConexaoComBancoDeDados(this IServiceCollection services, IConfigurationRoot configuration)
        {
            //var connectionString = configuration["ConnectionStrings:ConexaoPadrao"];
            //services.AddDbContext<GestaoDeProjetoContexto>(options => options.UseSqlServer(connectionString));

            string connectionString = "Server=SERVER;Database=GestaoDeProjeto;Trusted_Connection=True;Encrypt=False";
            services.AddDbContext<GestaoDeProjetoContexto>(options => options.UseSqlServer(connectionString));
        }

    }
}
