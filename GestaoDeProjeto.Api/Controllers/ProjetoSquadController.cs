using GestaoDeProjeto.Aplicacao.Command.Projetos;
using GestaoDeProjeto.Aplicacao.DML.ProjetoSquads;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProjeto.Api.Controllers
{
    [Route("api/v1/ProjetoSquad")]
    [ApiController]
    public class ProjetoSquadController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjetoSquadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Conexao"), ActionName("Conexao")]
        public string Conexao()
        {
            return "Ok";
        }

        [HttpPost("Inserir"), ActionName("Inserir")]
        public async Task<ResultadoOperacao<ProjetoSquadIncluirResponse>> Inserir([FromBody] ProjetoSquadIncluirRequest request)
        {
            ResultadoOperacao<ProjetoSquadIncluirResponse> response = await _mediator.Send(request);
            return response;
        }


        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<ResultadoOperacao<ProjetoSquadAlterarResponse>> Alterar([FromBody] ProjetoSquadAlterarRequest request)
        {
            ResultadoOperacao<ProjetoSquadAlterarResponse> response = await _mediator.Send(request);
            return response;
        }
    }
}
