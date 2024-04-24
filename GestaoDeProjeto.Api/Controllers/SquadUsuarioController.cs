using GestaoDeProjeto.Aplicacao.DML.Squads;
using GestaoDeProjeto.Aplicacao.DML.SquadUsuarios;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProjeto.Api.Controllers
{
    [Route("api/v1/SquadUsuario")]
    [ApiController]
    public class SquadUsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SquadUsuarioController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        public string Conexao()
        {
            return "Ok";
        }

        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] SquadUsuarioIncluirRequest request)
        {
            if (ModelState.IsValid)
            {
                ResultadoOperacao<SquadUsuarioIncluirResponse> response = await _mediator.Send(request);
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
