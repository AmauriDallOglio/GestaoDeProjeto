using GestaoDeProjeto.Aplicacao.DML.Tarefas;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeTarefa.Api.Controllers
{
    [Route("api/v1/Tarefa")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TarefaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        public string Conexao()
        {
            return "Ok";
        }


        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<ResultadoOperacao<TarefaIncluirResponse>> Inserir([FromBody] TarefaIncluirRequest request)
        {
            ResultadoOperacao<TarefaIncluirResponse> response = await _mediator.Send(request);
            return response;
        }

        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<ResultadoOperacao<TarefaAlterarResponse>> Alterar([FromBody] TarefaAlterarRequest request)
        {
            ResultadoOperacao<TarefaAlterarResponse> response = await _mediator.Send(request);
            return response;
        }


        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<ActionResult<IEnumerable<TarefaObterTodosResponse>>> ObterTodos([FromQuery] TarefaObterTodosRequest request)
        {
            RetornoPaginadoGenerico<TarefaObterTodosResponse> resultado = await _mediator.Send(request);
            var lista = resultado.Modelos.ToList();
            return Ok(resultado);
        }

    }
}
