﻿using GestaoDeProjeto.Aplicacao.DML.Squads;
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

        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<ResultadoOperacao<SquadAlterarResponse>> Alterar([FromBody] SquadAlterarRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }


        [HttpPut("Excluir"), ActionName("Excluir")]
        public async Task<ResultadoOperacao<SquadExcluirResponse>> Excluir([FromBody] SquadExcluirRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }


        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<ActionResult<IEnumerable<SquadObterTodosResponse>>> ObterTodos([FromQuery] SquadObterTodosRequest request)
        {
            RetornoPaginadoGenerico<SquadObterTodosResponse> resultado = await _mediator.Send(request);
            var lista = resultado.Modelos.ToList();
            return Ok(resultado);
        }




        [HttpGet("ObterCombo"), ActionName("ObterCombo")]
        public async Task<ActionResult<SquadComboResponse>> ObterCombo([FromQuery] SquadComboRequest request)
        {
            List<SquadComboResponse> resultado = await _mediator.Send(request);

            return Ok(resultado);
        }



    }
}
