using GestaoDeProjeto.Infra.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Api.Configuracao
{
    internal static class ConfiguracaoConnectionString
    {
        public static void CarregaConexaoComBancoDeDados(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var connectionString = configuration["ConnectionStrings:Gravacao"];
            services.AddDbContext<GestaoDeProjetoContexto>(options => options.UseSqlServer(connectionString));
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Conexão bem-sucedida!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar: {ex.Message}");
            }

        }

    }
}
