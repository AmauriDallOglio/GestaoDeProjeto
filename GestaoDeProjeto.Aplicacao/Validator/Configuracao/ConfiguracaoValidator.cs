using FluentValidation;
using FluentValidation.AspNetCore;
using GestaoDeProjeto.Aplicacao.Command;
using GestaoDeProjeto.Aplicacao.Command.Projetos;
using GestaoDeProjeto.Dominio.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeProjeto.Aplicacao.Validator.Configuracao
{
    public static class ConfiguracaoValidator
    {
        public static void DependenciasDoValidator(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = RespostaDeValidacao;
            });

            services.AddControllers().AddFluentValidation().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

 
            services.AdicionaInterfaceValidador();
        }


        private static IServiceCollection AdicionaInterfaceValidador(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ProjetoIncluirRequest>, ProjetoIncluirValidator>();

            return services;
        }

        private static IActionResult RespostaDeValidacao(ActionContext context)
        {
            ObjetoRetorno objetoRetorno = new ObjetoRetorno();

            foreach (var keyModelStatePair in context.ModelState)
            {
                var resultado = keyModelStatePair.Value.Errors;
                if (resultado != null && resultado.Count > 0)
                {
                    for (var i = 0; i < resultado.Count; i++)
                    {
                        objetoRetorno.Descricao.Add(GetErrorMessage(resultado[i]));
                    }
                }
            }
            ResultadoOperacao<ObjetoRetorno> resultadoOperacao = new ResultadoOperacao<ObjetoRetorno>();
            resultadoOperacao = resultadoOperacao.RetornaFalha(objetoRetorno, "Ocorreu um ou mais erros de validação.");
            resultadoOperacao.NomeObjeto = ObterNomeObjeto(context);


            BadRequestObjectResult result = new BadRequestObjectResult(resultadoOperacao);

            return result;
        }

        private static string ObterNomeObjeto(ActionContext context)
        {
            string nome = "";
            foreach (var valor in context.ActionDescriptor.RouteValues)
            {
                if (valor.Key == "controller")
                    nome = valor.Value;
            }
            return nome;
        }

        private static string GetErrorMessage(ModelError error)
        {
            return error.ErrorMessage;
        }

        private class ObjetoRetorno
        {
            public List<string> Descricao { get; set; } = new List<string>();
        }
    }
 
}
