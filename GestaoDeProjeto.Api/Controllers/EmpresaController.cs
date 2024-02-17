using GestaoDeProjeto.Aplicacao.Command;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestaoDeProjeto.Api.Controllers
{
    [Route("api/v1/Empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpresaController(IMediator mediator)
        {
            _mediator = mediator;
 
        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        public string Conexao()
        {
            return "Ok";
        }

        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] EmpresaIncluirRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(request);

                if (response.Sucesso)
                {
                    return Ok(response);
                }
                else
                {
                    // Se houver erros no resultado da operação, retorne uma resposta BadRequest
                    return BadRequest(new { Mensagem = response.Mensagem });
                }
            }
            else
            {
                // Se o modelo não for válido, retorne as mensagens de erro de validação
                return BadRequest(ModelState);
            }
        }


        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<IActionResult> ObterTodos([FromQuery] EmpresaObterTodosRequest request)
        {
            RetornoPaginadoGenerico<EmpresaObterTodosResponse> resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

    }
}
