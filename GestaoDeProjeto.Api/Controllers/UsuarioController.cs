using GestaoDeProjeto.Aplicacao.DML.Usuarios;
using GestaoDeProjeto.Aplicacao.DML.Usuarios;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProjeto.Api.Controllers
{
    [Route("api/v1/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        public string Conexao()
        {
            return "Ok";
        }

        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] UsuarioIncluirRequest request)
        {
            if (ModelState.IsValid)
            {
                ResultadoOperacao<UsuarioIncluirResponse> response = await _mediator.Send(request);
                if (response.Sucesso)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(new { Mensagem = response.Mensagem });
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<ResultadoOperacao<UsuarioAlterarResponse>> Alterar([FromBody] UsuarioAlterarRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }


        [HttpDelete("Excluir"), ActionName("Excluir")]
        public async Task<ResultadoOperacao<UsuarioExcluirResponse>> Excluir([FromBody] UsuarioExcluirRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }


        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<ActionResult<IEnumerable<UsuarioObterTodosResponse>>> ObterTodos([FromQuery] UsuarioObterTodosRequest request)
        {
            RetornoPaginadoGenerico<UsuarioObterTodosResponse> resultado = await _mediator.Send(request);
            var lista = resultado.Modelos.ToList();
            return Ok(resultado);
        }



    }
}
