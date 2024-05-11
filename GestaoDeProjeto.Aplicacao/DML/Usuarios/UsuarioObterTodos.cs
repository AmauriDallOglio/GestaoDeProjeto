using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Usuarios
{
    public class UsuarioObterTodosRequest : IRequest<RetornoPaginadoGenerico<UsuarioObterTodosResponse>>
    {
        public string? Nome { get; set; }

        public short? Inativo { get; set; }
    }

    public class UsuarioObterTodosResponse
    {
        public int Id { get; set; }
        //public int Id_Empresa { get; set; }
   
        public string Nome { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public byte Situacao { get; set; }
    }

    public class UsuarioObterTodosHandler : IRequestHandler<UsuarioObterTodosRequest, RetornoPaginadoGenerico<UsuarioObterTodosResponse>>
    {
        private readonly IUsuarioRepositorio _iUsuarioRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsuarioObterTodosHandler(IMediator mediator, IMapper mapper, IUsuarioRepositorio repository)
        {
            _iUsuarioRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<RetornoPaginadoGenerico<UsuarioObterTodosResponse>> Handle(UsuarioObterTodosRequest request, CancellationToken cancellationToken)
        {
            var filtro = new UsuarioObterTodosFiltro(request);
            var where = filtro.CriterioWhere;
            var orderby = filtro.CriterioOrderBy;
            var includeProperties = filtro.Includes;

  
            var lista = await _iUsuarioRepositorio.ObterTodosAsync(where, orderby, "", false, null, null, cancellationToken);
 
            List<UsuarioObterTodosResponse> response = _mapper.Map<List<UsuarioObterTodosResponse>>(lista);
            RetornoPaginadoGenerico<UsuarioObterTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<UsuarioObterTodosResponse>
            {
                Modelos = response,
                ItemPorPagina = 1,
                Pagina = 10,
                TotalRegistros = response.Count()
            };
            return await Task.FromResult(retornoPaginado);
        }

       

    }
}
