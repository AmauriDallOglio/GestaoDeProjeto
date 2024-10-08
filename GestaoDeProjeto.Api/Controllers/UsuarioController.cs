using GestaoDeProjeto.Aplicacao.DML.Usuarios;
using GestaoDeProjeto.Dominio.Entidade;
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

        [HttpPut("Alterar"), ActionName("Alterar")]
        public async Task<ResultadoOperacao<UsuarioAlterarResponse>> Alterar([FromBody] UsuarioAlterarRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }


        [HttpDelete("Excluir"), ActionName("Excluir")]
        public async Task<ResultadoOperacao<UsuarioExcluirResponse>> Excluir([FromBody] UsuarioExcluirRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }


        [HttpGet("ObterTodos"), ActionName("ObterTodos")]
        public async Task<ActionResult<IEnumerable<UsuarioObterTodosResponse>>> ObterTodos([FromQuery] UsuarioObterTodosRequest request)
        {
            RetornoPaginadoGenerico<UsuarioObterTodosResponse> resultado = await _mediator.Send(request);
            var lista = resultado.Modelos.ToList();
            return Ok(resultado);
        }




        [HttpGet]
        public ActionResult<ResultadoOperacao<Usuario>> GetModelos(int pagina = 1, int itensPorPagina = 10)
        {
            try
            {
                var totalRegistros = 10; // Total de registros, geralmente você obteria isso do banco de dados

                var modelos = new List<Usuario>
            {
                new Usuario { Id = 1, Nome = "string", Cargo = "string", Email = "string", Telefone = "string", Situacao = 0 },
                new Usuario { Id = 2, Nome = "string", Cargo = "string", Email = "string", Telefone = "string", Situacao = 0 },
                new Usuario { Id = 10, Nome = "Amauri 8", Cargo = "Programador 8", Email = "amauri@programador8", Telefone = "999330002", Situacao = 0 },
                new Usuario { Id = 9, Nome = "Amauri 7", Cargo = "Programador 7", Email = "amauri@programador7", Telefone = "999330002", Situacao = 0 },
                new Usuario { Id = 8, Nome = "Amauri 6", Cargo = "Programador 6", Email = "amauri@programador6", Telefone = "999330002", Situacao = 0 },
                new Usuario { Id = 7, Nome = "Amauri 5", Cargo = "Programador 5", Email = "amauri@programador5", Telefone = "999330002", Situacao = 0 },
                new Usuario { Id = 6, Nome = "Amauri 4", Cargo = "Programador 4", Email = "amauri@programador4", Telefone = "999330002", Situacao = 0 },
                new Usuario { Id = 5, Nome = "Amauri 3", Cargo = "Programador 3", Email = "amauri@programador3", Telefone = "999330002", Situacao = 0 },
                new Usuario { Id = 4, Nome = "Amauri 2", Cargo = "Programador 2", Email = "amauri@programador2", Telefone = "999330001", Situacao = 0 },
                new Usuario { Id = 3, Nome = "Amauri 1", Cargo = "Programador 1", Email = "amauri@programador1", Telefone = "999331234", Situacao = 0 }
            };

        

                return Ok(modelos);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here)
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
