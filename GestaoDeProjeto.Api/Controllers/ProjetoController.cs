using GestaoDeProjeto.Aplicacao.Command;
using GestaoDeProjeto.Aplicacao.Command.Projetos;
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
        public async Task<ResultadoOperacao<ProjetoIncluirResponse>> Inserir([FromBody] ProjetoIncluirRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }


        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<ResultadoOperacao<ProjetoAlterarResponse>> Alterar([FromBody] ProjetoAlterarRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }


        [HttpDelete("Excluir"), ActionName("Excluir")]
        public async Task<ResultadoOperacao<ProjetoExcluirResponse>> Excluir([FromBody] ProjetoExcluirRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }


        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<ActionResult<IEnumerable<ProjetoObterTodosResponse>>> ObterTodos([FromQuery] ProjetoObterTodosRequest request)
        {
            RetornoPaginadoGenerico<ProjetoObterTodosResponse> resultado = await _mediator.Send(request);
            var lista = resultado.Modelos.ToList();
            return Ok(resultado);
        }


 


    }
}
