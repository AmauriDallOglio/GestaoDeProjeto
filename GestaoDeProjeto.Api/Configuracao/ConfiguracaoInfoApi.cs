using Microsoft.OpenApi.Models;

namespace GestaoDeProjeto.Api.Configuracao
{
    internal static class ConfiguracaoInfoApi
    {
        public static void InformacaoCabecalhoApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Projeto.API",
                    Description = "API CRUD para gestão de projetos",
                    TermsOfService = new Uri("https://example.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Amauri Dall'Oglio",
                        Email = "amauridalloglio@gmail.com",
                        Url = new Uri("https://github.com/amauridalloglio"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Informações de licença",
                        Url = new Uri("https://example.com/"),
                    }
                });
            });
        }
    }
}
