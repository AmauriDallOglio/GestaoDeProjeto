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

    }
}
