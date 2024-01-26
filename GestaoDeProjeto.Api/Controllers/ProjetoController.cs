using GestaoDeProjeto.Aplicacao.Negocio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProjeto.Api.Controllers
{
    [Route("api/v1/Projeto")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjetoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        public string Conexao()
        {
            return "Ok";
        }

        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<ResultadoOperacao<ProjetoIncluirResponse>> Inserir([FromBody] ProjetoIncluirRequest dadosEntrada)
        {
            var response = await _mediator.Send(dadosEntrada);
            return response;
        }

        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<ActionResult<IEnumerable<ProjetoObterTodosResponse>>> ObterTodos([FromQuery] ProjetoObterTodosRequest dadosEntrada)
        {
            RetornoPaginadoGenerico<ProjetoObterTodosResponse> resultado = await _mediator.Send(dadosEntrada);
            var lista = resultado.Modelos.ToList();
            return Ok(lista);
        }


 


    }
}
