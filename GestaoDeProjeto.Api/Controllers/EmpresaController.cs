using GestaoDeProjeto.Aplicacao.Command;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ResultadoOperacao<EmpresaIncluirResponse>> Inserir([FromBody] EmpresaIncluirRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
