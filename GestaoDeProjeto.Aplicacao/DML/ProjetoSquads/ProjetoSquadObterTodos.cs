using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.ProjetoSquads
{
    public class ProjetoSquadObterTodosRequest : IRequest<RetornoPaginadoGenerico<ProjetoSquadObterTodosResponse>>
    {

    }
    public class ProjetoSquadObterTodosResponse
    {
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
 
        public int Id_Projeto { get; set; }
     
        public int Id_Squad { get; set; }
      
        public bool Inativo { get; set; }

    }

    public class ProjetoSquadObterTodosHandler : IRequestHandler<ProjetoSquadObterTodosRequest, RetornoPaginadoGenerico<ProjetoSquadObterTodosResponse>>
    {
        private readonly IProjetoSquadRepositorio _iProjetoSquadRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoSquadObterTodosHandler(IMediator mediator, IMapper mapper, IProjetoSquadRepositorio repository)
        {
            _iProjetoSquadRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<RetornoPaginadoGenerico<ProjetoSquadObterTodosResponse>> Handle(ProjetoSquadObterTodosRequest request, CancellationToken cancellationToken)
        {

            //var filtro = new ProjetoListarTodosFiltro(request);
            //var where = filtro.CriterioWhere;
            //var orderby = filtro.CriterioOrderBy;
            //var include = filtro.Includes;


            //List<Projeto> lista = await _iProjetoRepositorio.ObterTodos(filtro, orderby, false, null, null);

            IEnumerable<ProjetoSquad> lista = await _iProjetoSquadRepositorio.ObterTodosAsync();
            List<ProjetoSquadObterTodosResponse> response = _mapper.Map<List<ProjetoSquadObterTodosResponse>>(lista);
            RetornoPaginadoGenerico<ProjetoSquadObterTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<ProjetoSquadObterTodosResponse>
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
