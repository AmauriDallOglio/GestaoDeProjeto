using GestaoDeProjeto.Api.Util;
using GestaoDeProjeto.Dominio.Util;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GestaoDeProjeto.Api.Configuracao
{
    public class MiddlewareHttp
    {
        private readonly RequestDelegate _next;
      
        private readonly RequestLocalizationOptions _localizationOptions;

        public MiddlewareHttp(RequestDelegate next,   IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _next = next;
   
            _localizationOptions = localizationOptions.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
       


                bool versaoInformada = context.Request.Path.Value.Contains("/v1/", StringComparison.OrdinalIgnoreCase);
                if (!versaoInformada)
                {
                    RetornoErroJson(context, StatusCodes.Status403Forbidden, "ErroAcessoNegado", "VersaoApi");
                    return;
                }
                else
                {
                    var possuiToken = context.Request.Headers.ContainsKey("Authorization");
                    if (possuiToken)
                    {
                        var tokenInformado = context.Request.Headers["Authorization"].ToString();
                        if (!tokenInformado.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                        {
                            RetornoErroJson(context, StatusCodes.Status400BadRequest, "ErroAcessoNegado", "BearerNaoInformado");
                            return;
                        }
                        else
                        {
                            var token = tokenInformado.Substring("Bearer ".Length).Trim();
 
                        }
                    }
                }
                await _next(context);
            }
            catch (TaskCanceledException ex)
            {
                RetornoErroJson(context, StatusCodes.Status500InternalServerError, "ErroCancellationToken", ex.Message + ex.InnerException?.Message ?? "");
                return;
            }
            catch (KeyNotFoundException ex)
            {
                RetornoErroJson(context, StatusCodes.Status404NotFound, "ErroAcessoNegado", ex.Message + ex.InnerException?.Message ?? "");
                return;
            }
            catch (DbUpdateException ex)
            {
                RetornoErroJson(context, StatusCodes.Status404NotFound, "ErroAcessoNegado", ex.Message + ex.InnerException?.Message ?? "");
                return;
            }
            catch (Exception ex)
            {
                if (ex.InnerException is SqlException sqlEx)
                {
                    SqlErrorCollection errors = sqlEx.Errors;
                    foreach (SqlError error in errors)
                    {
                        RetornoErroJson(context, error.Number, error.Number + " / " + error.Server + " / " + "Erro_ChaveDuplicada", ex.Message + ex.InnerException?.Message ?? "");
                    }
                    return;
                }
                else if (ex.Message.Equals("Value cannot be null. (Parameter 'entity')"))
                {
                    RetornoErroJson(context, StatusCodes.Status500InternalServerError, "ErroIdNaoExistente", ex.Message);
                }
                else
                    RetornoErroJson(context, StatusCodes.Status500InternalServerError, "ErroAcessoNegado", ex.Message + ex.InnerException?.Message ?? "");
                return;
            }

        }


        private void RetornoErroJson(HttpContext context, int statusCode, string message, string detail)
        {
            string nomeObjeto = RetornaNomeObjeto(context.Request);
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";
            MiddlewareHttpErro retornoErroOperacao = new MiddlewareHttpErro() { Status = statusCode, Detalhe = detail };
            var resultadoOperacao = ResultadoOperacao<MiddlewareHttpErro>.GeraFalhaAsync(retornoErroOperacao, message, nomeObjeto);
            var errorDetailsJson = JsonSerializer.Serialize(resultadoOperacao);
            context.Response.WriteAsync(errorDetailsJson);
        }

        private string RetornaNomeObjeto(HttpRequest request)
        {
            var path = request.Path;
            string[] caminhos = path.ToString().Split("/");
            return caminhos.Length == 5 ? caminhos[3] : "";
        }
    }
}
