using GestaoDeProjeto.Aplicacao.Command.Squads;
using GestaoDeProjeto.Aplicacao.Command.Usuarios;
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
    }
}
