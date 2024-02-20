using GestaoDeProjeto.Aplicacao.Command;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProjeto.Api.Controllers
{
    [Route("api/v1/Squad")]
    [ApiController]
    public class SquadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SquadController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        public string Conexao()
        {
            return "Ok";
        }

        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] SquadIncluirRequest request)
        {
            if (ModelState.IsValid)
            {
                ResultadoOperacao<SquadIncluirResponse> response = await _mediator.Send(request);
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
